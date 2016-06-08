using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    using Elrob.Common.DataAccess;

    public class OrderProgressItemModel : IOrderProgressItemModel
    {
        private readonly IOrderProgressConverter _orderProgressConverter;

        private ISessionFactory _sessionFactory;

        public OrderProgressItemModel( 
            IOrderProgressConverter orderProgressConverter, ISessionFactory sessionFactory)
        {
            if (orderProgressConverter == null) throw new ArgumentNullException(nameof(orderProgressConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _orderProgressConverter = orderProgressConverter;
            this._sessionFactory = sessionFactory;
        }

        public void AddOrderProgress(dto.OrderProgress orderProgress)
        {
            var domain = _orderProgressConverter.Convert(orderProgress);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateOrderProgress(dto.OrderProgress orderProgress)
        {
            var domain = _orderProgressConverter.Convert(orderProgress);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
