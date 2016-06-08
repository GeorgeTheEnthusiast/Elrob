using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    using Elrob.Common.DataAccess;

    public class OrderContentItemModel : IOrderContentItemModel
    {
        private readonly IOrderContentConverter _orderContentConverter;
        private readonly IMaterialConverter _materialConverter;
        private readonly IPlaceConverter _placeConverter;

        private ISessionFactory _sessionFactory;

        public OrderContentItemModel( 
            IOrderContentConverter orderContentConverter, IMaterialConverter materialConverter, IPlaceConverter placeConverter, ISessionFactory sessionFactory)
        {
            if (orderContentConverter == null) throw new ArgumentNullException(nameof(orderContentConverter));
            if (materialConverter == null) throw new ArgumentNullException(nameof(materialConverter));
            if (placeConverter == null) throw new ArgumentNullException(nameof(placeConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _orderContentConverter = orderContentConverter;
            _materialConverter = materialConverter;
            _placeConverter = placeConverter;
            this._sessionFactory = sessionFactory;
        }

        public void AddOrderContnt(dto.OrderContent orderContent)
        {
            var domain = _orderContentConverter.Convert(orderContent);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
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

        public List<dto.Material> GetAllMaterials()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Elrob.Common.Domain.Material>()
                    .List()
                    .ToList();

                var dto = _materialConverter.Convert(domain);

                return dto;
            }
        }

        public List<dto.Place> GetAllPlaces()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Elrob.Common.Domain.Place>()
                    .List()
                    .ToList();

                var dto = _placeConverter.Convert(domain);

                return dto;
            }
        }
    }
}
