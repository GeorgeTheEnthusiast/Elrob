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
    public class PlaceModel : IPlaceModel
    {
        private readonly IPlaceConverter _placeConverter;

        private ISessionFactory _sessionFactory;

        public PlaceModel( 
            IPlaceConverter placeConverter, ISessionFactory sessionFactory)
        {
            if (placeConverter == null) throw new ArgumentNullException(nameof(placeConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _placeConverter = placeConverter;
            this._sessionFactory = sessionFactory;
        }

        public List<dto.Place> GetAllPlaces()
        {
            using (var session = _sessionFactory.OpenSession())
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

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
            }
        }

        public bool DeletePlace(dto.Place place)
        {
            var domain = _placeConverter.Convert(place);

            using (var session = _sessionFactory.OpenSession())
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

            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
