using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class OrderPreviewModel : IOrderPreviewModel
    {
        private readonly IPlaceConverter _placeConverter;
        private readonly IMaterialConverter _materialConverter;
        private readonly IOrderContentConverter _orderContentConverter;
        private readonly IOrderConverter _orderConverter;

        public OrderPreviewModel(IPlaceConverter placeConverter, 
            IMaterialConverter materialConverter,
            IOrderContentConverter orderContentConverter,
            IOrderConverter orderConverter)
        {
            if (placeConverter == null) throw new ArgumentNullException("placeConverter");
            if (materialConverter == null) throw new ArgumentNullException("materialConverter");
            if (orderContentConverter == null) throw new ArgumentNullException("orderContentConverter");
            if (orderConverter == null) throw new ArgumentNullException("orderConverter");

            _placeConverter = placeConverter;
            _materialConverter = materialConverter;
            _orderContentConverter = orderContentConverter;
            _orderConverter = orderConverter;
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

        public void SaveOrder(dto.Order order, List<dto.OrderContent> orderContent)
        {
            var orderDomain = _orderConverter.Convert(order);

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        orderDomain = session.Merge(orderDomain);
                        var orderContentDomain = _orderContentConverter.Convert(orderContent);

                        foreach (var content in orderContentDomain)
                        {
                            content.Order = orderDomain;

                            var existedMaterial = session.QueryOver<domain.Material>()
                                .Where(x => x.Name == content.Material.Name)
                                .SingleOrDefault();

                            if (existedMaterial != null)
                            {
                                content.Material = existedMaterial;
                            }
                            else
                            {
                                content.Material.Id = (int)session.Save(content.Material);
                            }

                            var existedPlace = session.QueryOver<domain.Place>()
                                .Where(x => x.Name == content.Place.Name)
                                .SingleOrDefault();

                            if (existedPlace != null)
                            {
                                content.Place = existedPlace;
                            }
                            else
                            {
                                content.Place.Id = (int)session.Save(content.Place);
                            }
                            
                            session.Save(content);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw;
                    }
                 
                    transaction.Commit();
                }
            }
        }

        public bool IsOrderExist(string orderName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Order>()
                    .Where(x => x.Name == orderName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
