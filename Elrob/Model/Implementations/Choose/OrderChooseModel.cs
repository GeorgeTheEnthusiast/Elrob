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
    public class OrderChooseModel : IOrderChooseModel
    {
        private readonly IOrderConverter _orderConverter;

        private ISessionFactory _sessionFactory;

        public OrderChooseModel( 
            IOrderConverter orderConverter, ISessionFactory sessionFactory)
        {
            if (orderConverter == null) throw new ArgumentNullException("orderConverter");
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _orderConverter = orderConverter;
            this._sessionFactory = sessionFactory;
        }

        public List<dto.Order> GetAllOrders()
        {
            using (var session = _sessionFactory.OpenSession())
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
