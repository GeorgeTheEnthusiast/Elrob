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

        public OrderItemModel( 
            IOrderConverter orderConverter)
        {
            if (orderConverter == null) throw new ArgumentNullException("orderConverter");

            _orderConverter = orderConverter;
        }

        public void AddOrder(dto.Order order)
        {
            var domain = _orderConverter.Convert(order);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
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

        public bool IsOrderExist(dto.Order order)
        {
            using (var session = NHibernateHelper.OpenSession())
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
