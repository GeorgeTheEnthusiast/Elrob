using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Choose;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Choose
{
    using Elrob.Common.DataAccess;

    public class OrderContentChooseModel : IOrderContentChooseModel
    {
        private readonly IOrderContentConverter _orderContentConverter;

        private ISessionFactory _sessionFactory;

        public OrderContentChooseModel( 
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

        public List<dto.OrderContent> GetOrderContentsByOrderAndPlace(dto.Order order, dto.Place place)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Elrob.Common.Domain.OrderContent>()
                     .Where(x => x.Order.Id == order.Id)
                     .And(x => x.Place.Id == place.Id)
                     .List()
                     .ToList();

                var dto = _orderContentConverter.Convert(domain);

                return dto;
            }
        }

        public List<dto.OrderContent> GetOrderContentsByOrder(dto.Order order)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Elrob.Common.Domain.OrderContent>()
                    .Where(x => x.Order.Id == order.Id)
                    .List()
                    .ToList();

                var dto = _orderContentConverter.Convert(domain);

                return dto;
            }
        }
    }
}
