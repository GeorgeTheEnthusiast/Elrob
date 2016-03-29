using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class PlaceModel : IPlaceModel
    {
        private readonly IPlaceConverter _placeConverter;

        public PlaceModel( 
            IPlaceConverter placeConverter)
        {
            if (placeConverter == null) throw new ArgumentNullException("placeConverter");

            _placeConverter = placeConverter;
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

        public void AddPlace(dto.Place place)
        {
            var domain = _placeConverter.Convert(place);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public bool DeletePlace(dto.Place place)
        {
            var domain = _placeConverter.Convert(place);

            using (var session = NHibernateHelper.OpenSession())
            {
                var existInOrderContentCount = session.QueryOver<domain.OrderContent>()
                    .Where(x => x.Place.Id == domain.Id)
                    .RowCount();

                if (existInOrderContentCount > 0)
                {
                    return false;
                }

                session.Delete(domain);
                session.Flush();

                return true;
            }
        }

        public void UpdatePlace(dto.Place place)
        {
            var domain = _placeConverter.Convert(place);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
