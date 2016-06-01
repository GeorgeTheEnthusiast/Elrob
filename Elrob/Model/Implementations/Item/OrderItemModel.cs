using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class OrderItemModel : IOrderItemModel
    {
        private readonly IOrderConverter _orderConverter;

        private ISessionFactory _sessionFactory;

        public OrderItemModel( 
            IOrderConverter orderConverter, ISessionFactory sessionFactory)
        {
            if (orderConverter == null) throw new ArgumentNullException(nameof(orderConverter));

            _orderConverter = orderConverter;
            this._sessionFactory = sessionFactory;
        }

        public void AddOrder(dto.Order order)
        {
            var domain = _orderConverter.Convert(order);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateOrder(dto.Order order)
        {
            var domain = _orderConverter.Convert(order);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public bool IsOrderExist(dto.Order order)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Order>()
                    .Where(x => x.Name == order.Name)
                    .And(x => x.Id != order.Id)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
