using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Main;
using NHibernate.Criterion;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Common.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    using Elrob.Common.DataAccess;

    public class OrderContentModel : IOrderContentModel
    {
        private readonly IOrderContentConverter _orderContentConverter;

        private ISessionFactory _sessionFactory;

        public OrderContentModel( 
            IOrderContentConverter orderContentConverter, ISessionFactory sessionFactory)
        {
            if (orderContentConverter == null) throw new ArgumentNullException(nameof(orderContentConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _orderContentConverter = orderContentConverter;
            this._sessionFactory = sessionFactory;
        }

        public List<dto.OrderContent> GetOrderContent(int orderId, int placeId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var orderContentDomain = session.QueryOver<Elrob.Common.Domain.OrderContent>()
                 .Where(x => x.Order.Id == orderId
                     && x.Place.Id == placeId)
                 .List()
                 .ToList();

                var progressDomain = session.QueryOver<Elrob.Common.Domain.OrderProgress>()
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
            using (var session = _sessionFactory.OpenSession())
            {
                var orderContentDomain = session.QueryOver<Elrob.Common.Domain.OrderContent>()
                 .Where(x => x.Order.Id == orderId)
                 .List()
                 .ToList();

                var progressDomain = session.QueryOver<Elrob.Common.Domain.OrderProgress>()
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

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void DeleteOrderContent(dto.OrderContent orderContent)
        {
            var orderDomain = _orderContentConverter.Convert(orderContent);

            using (var session = _sessionFactory.OpenSession())
            {
                var domainOrderContent = session.QueryOver<Elrob.Common.Domain.OrderContent>()
                    .Where(x => x.Id == orderDomain.Id)
                    .SingleOrDefault();

                session.Delete(domainOrderContent);
                session.Flush();
            }
        }

        public void UpdateOrderContent(dto.OrderContent orderContent)
        {
            var domain = _orderContentConverter.Convert(orderContent);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
