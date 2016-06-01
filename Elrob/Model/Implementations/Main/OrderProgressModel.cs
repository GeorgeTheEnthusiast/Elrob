using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class OrderProgressModel : IOrderProgressModel
    {
        private readonly IOrderProgressConverter _orderProgressConverter;
        private readonly IOrderContentConverter _orderContentConverter;

        private ISessionFactory _sessionFactory;

        public OrderProgressModel( 
            IOrderProgressConverter orderProgressConverter,
            IOrderContentConverter orderContentConverter, ISessionFactory sessionFactory)
        {
            if (orderProgressConverter == null) throw new ArgumentNullException(nameof(orderProgressConverter));
            if (orderContentConverter == null) throw new ArgumentNullException(nameof(orderContentConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _orderProgressConverter = orderProgressConverter;
            _orderContentConverter = orderContentConverter;
            this._sessionFactory = sessionFactory;
        }

        public List<dto.OrderProgress> GetOrderContentProgressById(int orderContentId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Domain.OrderProgress>()
                    .Where(x => x.OrderContent.Id == orderContentId)
                    .List()
                    .ToList();

                var dto = _orderProgressConverter.Convert(domain);

                return dto;
            }
        }

        public List<dto.OrderContent> GetOrderContent(int orderId, int placeId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Domain.OrderContent>()
                    .Where(x => x.Order.Id == orderId)
                    .And(x => x.Place.Id == placeId)
                    .List()
                    .ToList();

                var dto = _orderContentConverter.Convert(domain);

                return dto;
            }
        }

        public List<dto.OrderContent> GetOrderContent(int orderId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Domain.OrderContent>()
                    .Where(x => x.Order.Id == orderId)
                    .List()
                    .ToList();

                var dto = _orderContentConverter.Convert(domain);

                return dto;
            }
        }

        public void DeleteOrderProgress(dto.OrderProgress orderProgress)
        {
            var domain = _orderProgressConverter.Convert(orderProgress);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Delete(domain);
                session.Flush();
            }
        }
    }
}
