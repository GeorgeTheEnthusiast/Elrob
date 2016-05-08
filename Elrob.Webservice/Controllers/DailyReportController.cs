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
        public List<DailyReport> GetDailyReport(WeekRange weekRange)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Domain.OrderContent orderContentAlias = null;
                Domain.Order orderAlias = null;
                Domain.OrderProgress orderProgressAlias = null;
                Domain.Place placeAlias = null;

                var orderContents =
                    session.QueryOver(() => orderContentAlias)
                        .JoinAlias(() => orderContentAlias.Place, () => placeAlias, JoinType.RightOuterJoin)
                        .JoinAlias(() => orderContentAlias.Order, () => orderAlias)
                        .WhereRestrictionOn(() => orderAlias.StartDate)
                        .IsBetween(weekRange.StartDate.AddDays(-1))
                        .And(weekRange.EndDate.AddDays(1))
                        .List()
                        .ToList();

                var orderProgresses =
                    session.QueryOver(() => orderProgressAlias)
                        .JoinAlias(() => orderProgressAlias.OrderContent, () => orderContentAlias)
                        .WhereRestrictionOn(() => orderProgressAlias.OrderContent.Id)
                        .IsIn(orderContents.Select(x => x.Id).ToArray())
                        .List()
                        .ToList();
                
                var result = (from o in orderContents
                              join p in orderProgresses on o.Id equals p.OrderContent.Id into joinedOP
                              from pp in joinedOP.DefaultIfEmpty(new Domain.OrderProgress())
                              select new { OrderContent = o, OrderProgress = pp } into newSelect
                              group newSelect by new
                            {
                                newSelect.OrderContent.Order,
                                newSelect.OrderContent,
                                newSelect.OrderContent.Place
                            } into progressesGrouped

                              let toCompleteSum = progressesGrouped.Sum(x => x.OrderContent.ToComplete)
                              let completedSum = progressesGrouped.Sum(x => x.OrderProgress.Completed)
                              let completedPercentage = completedSum * 100 / (toCompleteSum == 0 ? 1 : toCompleteSum)
                              select new DailyReport
                            {
                                OrderName = progressesGrouped.Key.Order.Name,
                                PlaceName = progressesGrouped.Key.OrderContent.Place.Name,
                                OrderContentName = progressesGrouped.Key.OrderContent.Name,
                                OrderContentDocumentNumber = progressesGrouped.Key.OrderContent.DocumentNumber,
                                PercentageProgress = completedPercentage
                            })
                              .OrderBy(x => x.PlaceName)
                              .ThenBy(x => x.OrderContentDocumentNumber)
                              .ThenBy(x => x.OrderContentName)
                              .ToList();

                return result;
            }
        }
    }
}