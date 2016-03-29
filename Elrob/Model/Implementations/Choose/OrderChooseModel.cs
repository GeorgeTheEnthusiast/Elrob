using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Choose;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Choose
{
    public class OrderChooseModel : IOrderChooseModel
    {
        private readonly IOrderConverter _orderConverter;

        public OrderChooseModel( 
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
    }
}
