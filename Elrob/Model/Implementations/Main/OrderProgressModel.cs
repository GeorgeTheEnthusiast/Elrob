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

        public OrderProgressModel( 
            IOrderProgressConverter orderProgressConverter)
        {
            if (orderProgressConverter == null) throw new ArgumentNullException("orderProgressConverter");

            _orderProgressConverter = orderProgressConverter;
        }

        public List<dto.OrderProgress> GetOrderContentProgressById(int orderContentId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.OrderProgress>()
                    .Where(x => x.OrderContent.Id == orderContentId)
                    .List()
                    .ToList();

                var dto = _orderProgressConverter.Convert(domain);

                return dto;
            }
        }

        public void DeleteOrderProgress(dto.OrderProgress orderProgress)
        {
            var domain = _orderProgressConverter.Convert(orderProgress);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Delete(domain);
                session.Flush();
            }
        }
    }
}
