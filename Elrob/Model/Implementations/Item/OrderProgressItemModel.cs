using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class OrderProgressItemModel : IOrderProgressItemModel
    {
        private readonly IOrderProgressConverter _orderProgressConverter;

        public OrderProgressItemModel( 
            IOrderProgressConverter orderProgressConverter)
        {
            if (orderProgressConverter == null) throw new ArgumentNullException("orderProgressConverter");

            _orderProgressConverter = orderProgressConverter;
        }

        public void AddOrderProgress(dto.OrderProgress orderProgress)
        {
            var domain = _orderProgressConverter.Convert(orderProgress);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateOrderProgress(dto.OrderProgress orderProgress)
        {
            var domain = _orderProgressConverter.Convert(orderProgress);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
