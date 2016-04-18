using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class OrderModel : IOrderModel
    {
        private readonly IOrderConverter _orderConverter;

        public OrderModel( 
            IOrderConverter orderConverter)
        {
            if (orderConverter == null) throw new ArgumentNullException("orderConverter");

            _orderConverter = orderConverter;
        }

        public List<dto.Order> GetAllOrders()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Order>()
                    .List()
                    .ToList();

                var dto = _orderConverter.Convert(domain);

                return dto;
            }
        }

        public void AddOrder(dto.Order order)
        {
            var domain = _orderConverter.Convert(order);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void DeleteOrder(dto.Order orderDto)
        {
            var orderDomain = _orderConverter.Convert(orderDto);

            using (var session = NHibernateHelper.OpenSession())
            {
                var orderContent = session.QueryOver<domain.OrderContent>()
                    .Where(x => x.Order.Id == orderDomain.Id)
                    .List()
                    .ToList();

                foreach (var content in orderContent)
                {
                    var orderProgress = session.QueryOver<domain.OrderProgress>()
                    .Where(x => x.OrderContent.Id == content.Id)
                    .List()
                    .ToList();

                    foreach (var progress in orderProgress)
                    {
                        session.Delete(progress);
                    }

                    session.Delete(content);
                }
                
                var order = session.QueryOver<domain.Order>()
                    .Where(x => x.Id == orderDomain.Id)
                    .SingleOrDefault();

                session.Delete(order);
                session.Flush();
            }
        }

        public void UpdateOrder(dto.Order order)
        {
            var domain = _orderConverter.Convert(order);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public List<dto.Order> GetOrdersWithProgressByPlace(int placeId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domainOrder = session.QueryOver<Domain.Order>()
                    .List()
                    .ToList();

                var domainOrderContent = session.QueryOver<domain.OrderContent>()
                    .Where(x => x.Place.Id == placeId)
                    .List()
                    .ToList();

                var domainOrderProgress = session.QueryOver<domain.OrderProgress>()
                    .List()
                    .ToList();

                var list = (from o in domainOrder
                    join c in domainOrderContent on o.Id equals c.Order.Id into oc
                    from ocResult in oc.DefaultIfEmpty(new domain.OrderContent())
                    join p in domainOrderProgress on ocResult.Id equals p.OrderContent.Id into ocp
                    from ocpResult in ocp.DefaultIfEmpty(new domain.OrderProgress())
                            select new { o, ocResult, ocpResult } into allTables
                    group allTables by new { allTables.o.Id, allTables.o.Name } into allTablesGrouped
                    let toCompleteSum = allTablesGrouped.Sum(x => x.ocResult.ToComplete)
                    let completedSum = allTablesGrouped.Sum(x => x.ocpResult.Completed)
                    let completedPercentage =  completedSum * 100 / (toCompleteSum == 0 ? 1 : toCompleteSum)
                    select new dto.Order()
                    {
                        Id = allTablesGrouped.Key.Id,
                        Name = allTablesGrouped.Key.Name,
                        PercentageProgress = completedPercentage
                    }
                )
                    .ToList();

                return list;
            }
        }

        public List<dto.Order> GetOrdersWithProgress()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domainOrder = session.QueryOver<Domain.Order>()
                    .List()
                    .ToList();

                var domainOrderContent = session.QueryOver<domain.OrderContent>()
                    .List()
                    .ToList();

                var domainOrderProgress = session.QueryOver<domain.OrderProgress>()
                    .List()
                    .ToList();

                var list = (from o in domainOrder
                            join c in domainOrderContent on o.Id equals c.Order.Id into oc
                            from ocResult in oc.DefaultIfEmpty(new domain.OrderContent())
                            join p in domainOrderProgress on ocResult.Id equals p.OrderContent.Id into ocp
                            from ocpResult in ocp.DefaultIfEmpty(new domain.OrderProgress())
                            select new { o, ocResult, ocpResult } into allTables
                            group allTables by new { allTables.o.Id, allTables.o.Name } into allTablesGrouped
                            let toCompleteSum = allTablesGrouped.Sum(x => x.ocResult.ToComplete)
                            let completedSum = allTablesGrouped.Sum(x => x.ocpResult.Completed)
                            let completedPercentage = completedSum * 100 / (toCompleteSum == 0 ? 1 : toCompleteSum)
                            select new dto.Order()
                            {
                                Id = allTablesGrouped.Key.Id,
                                Name = allTablesGrouped.Key.Name,
                                PercentageProgress = completedPercentage
                            }
                )
                    .ToList();

                return list;
            }
        }
    }
}
