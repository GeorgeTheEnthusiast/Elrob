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
    public class OrderContentItemModel : IOrderContentItemModel
    {
        private readonly IOrderContentConverter _orderContentConverter;
        private readonly IMaterialConverter _materialConverter;
        private readonly IPlaceConverter _placeConverter;

        public OrderContentItemModel( 
            IOrderContentConverter orderContentConverter, IMaterialConverter materialConverter, IPlaceConverter placeConverter)
        {
            if (orderContentConverter == null) throw new ArgumentNullException("orderContentConverter");
            if (materialConverter == null) throw new ArgumentNullException("materialConverter");
            if (placeConverter == null) throw new ArgumentNullException("placeConverter");

            _orderContentConverter = orderContentConverter;
            _materialConverter = materialConverter;
            _placeConverter = placeConverter;
        }

        public void AddOrderContnt(dto.OrderContent orderContent)
        {
            var domain = _orderContentConverter.Convert(orderContent);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateOrderContent(dto.OrderContent orderContent)
        {
            var domain = _orderContentConverter.Convert(orderContent);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public List<dto.Material> GetAllMaterials()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Material>()
                    .List()
                    .ToList();

                var dto = _materialConverter.Convert(domain);

                return dto;
            }
        }

        public List<dto.Place> GetAllPlaces()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Place>()
                    .List()
                    .ToList();

                var dto = _placeConverter.Convert(domain);

                return dto;
            }
        }
    }
}
