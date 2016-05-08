using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Controllers
{
    using System.Collections.ObjectModel;

    using Elrob.Webservice.Converters.Interfaces;
    using Elrob.Webservice.Domain;
    using Elrob.Webservice.Dto;

    using FluentNHibernate.Utils;

    using NHibernate.Criterion;
    using NHibernate.SqlCommand;
    using NHibernate.Transform;

    public class DailyReportController : IDailyReportController
    {
        private readonly IPlaceConverter _placeConverter;

        public DailyReportController(IPlaceConverter placeConverter)
        {
            if (placeConverter == null)
            {
                throw new ArgumentNullException(nameof(placeConverter));
            }
            this._placeConverter = placeConverter;
        }

        public Dictionary<Dto.Place, List<DailyReport>> GetDailyReport(WeekRange weekRange)
        {
            var result = new Dictionary<Dto.Place, List<DailyReport>>();

            using (var session = NHibernateHelper.OpenSession())
            {
                Domain.OrderContent orderContentAlias = null;
                Domain.Order orderAlias = null;
                Domain.OrderProgress orderProgressAlias = null;
                Domain.Place placeAlias = null;

                var places = session.QueryOver<Domain.Place>()
                    .List()
                    .ToList();

                var orderContents =
                    session.QueryOver(() => orderContentAlias)
                        .JoinAlias(() => orderContentAlias.Place, () => placeAlias, JoinType.RightOuterJoin)
                        .JoinAlias(() => orderContentAlias.Order, () => orderAlias)
                        .WhereRestrictionOn(() => orderAlias.StartDate)
                        .IsBetween(weekRange.StartDate)
                        .And(weekRange.EndDate)
                        .List()
                        .ToList();
                
                var orderProgresses =
                    session.QueryOver(() => orderProgressAlias)
                        .JoinAlias(() => orderProgressAlias.OrderContent, () => orderContentAlias)
                        .WhereRestrictionOn(() => orderProgressAlias.OrderContent.Id)
                        .IsIn(orderContents.Select(x => x.Id).ToArray())
                        .List()
                        .ToList();
                
                var resultWithPercentages = (from o in orderContents
                              join p in orderProgresses on o.Id equals p.OrderContent.Id into joinedOP
                              from pp in joinedOP.DefaultIfEmpty(new Domain.OrderProgress())
                              select new { OrderContent = o, OrderProgress = pp } into newSelect
                              group newSelect by new
                            {
                                newSelect.OrderContent.Place,
                                newSelect.OrderContent.DocumentNumber,
                                newSelect.OrderContent.Name
                            } into progressesGrouped

                              let toCompleteSum = progressesGrouped.Sum(x => x.OrderContent.ToComplete)
                              let completedSum = progressesGrouped.Sum(x => x.OrderProgress.Completed)
                              let completedPercentage = completedSum * 100 / (toCompleteSum == 0 ? 1 : toCompleteSum)
                              select new DailyReport
                            {
                                PlaceName = progressesGrouped.Key.Place.Name,
                                OrderContentName = progressesGrouped.Key.Name,
                                OrderContentDocumentNumber = progressesGrouped.Key.DocumentNumber,
                                PercentageProgress = completedPercentage
                            })
                              .OrderBy(x => x.PlaceName)
                              .ThenBy(x => x.OrderContentDocumentNumber)
                              .ThenBy(x => x.OrderContentName)
                              .ToList();

                var defaultDailyReport = new DailyReport();

                var groupedResult = (from p in places
                            join dr in resultWithPercentages.DefaultIfEmpty(defaultDailyReport) on p.Name equals dr.PlaceName into drJoined
                            select new { Place = p, DailyReport = drJoined.ToList() }).ToList();

                foreach (var row in groupedResult)
                {
                    var placeDto = _placeConverter.Convert(row.Place);

                    result[placeDto] = row.DailyReport;
                }

                return result;
            }
        }
    }
}