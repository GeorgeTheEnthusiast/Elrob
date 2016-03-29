using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Main;
using NHibernate.Criterion;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class OrderContentModel : IOrderContentModel
    {
        private readonly IOrderContentConverter _orderContentConverter;

        public OrderContentModel( 
            IOrderContentConverter orderContentConverter)
        {
            if (orderContentConverter == null) throw new ArgumentNullException("orderContentConverter");

            _orderContentConverter = orderContentConverter;
        }

        public List<dto.OrderContent> GetOrderContent(int orderId, int placeId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var orderContentDomain = session.QueryOver<Domain.OrderContent>()
                 .Where(x => x.Order.Id == orderId
                     && x.Place.Id == placeId)
                 .List()
                 .ToList();

                var progressDomain = session.QueryOver<Domain.OrderProgress>()
                    .Where(x => x.OrderContent.IsIn(orderContentDomain))
                    .List()
                    .ToList();

                var dto = _orderContentConverter.Convert(orderContentDomain);

                foreach (var orderContent in dto)
                {
                    orderContent.Completed = progressDomain
                        .Where(x => x.OrderContent.Id == orderContent.Id)
                        .Sum(x => x.Completed);
                }

                return dto;
            }
        }

        public List<dto.OrderContent> GetOrderContent(int orderId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var orderContentDomain = session.QueryOver<Domain.OrderContent>()
                 .Where(x => x.Order.Id == orderId)
                 .List()
                 .ToList();

                var progressDomain = session.QueryOver<Domain.OrderProgress>()
                    .Where(x => x.OrderContent.IsIn(orderContentDomain))
                    .List()
                    .ToList();

                var dto = _orderContentConverter.Convert(orderContentDomain);

                foreach (var orderContent in dto)
                {
                    orderContent.Completed = progressDomain
                        .Where(x => x.OrderContent.Id == orderContent.Id)
                        .Sum(x => x.Completed);
                }

                return dto;
            }
        }

        public void AddOrderContent(dto.OrderContent orderContent)
        {
            var domain = _orderContentConverter.Convert(orderContent);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void DeleteOrderContent(dto.OrderContent orderContent)
        {
            var orderDomain = _orderContentConverter.Convert(orderContent);

            using (var session = NHibernateHelper.OpenSession())
            {
                var domainOrderContent = session.QueryOver<domain.OrderContent>()
                    .Where(x => x.Id == orderDomain.Id)
                    .SingleOrDefault();

                session.Delete(domainOrderContent);
                session.Flush();
            }
        }

        public void UpdateOrderContent(dto.OrderContent orderContent)
        {
            var domain = _orderContentConverter.Convert(orderContent);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
