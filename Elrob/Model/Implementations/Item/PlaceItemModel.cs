using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class PlaceItemModel : IPlaceItemModel
    {
        private readonly IPlaceConverter _placeConverter;

        private ISessionFactory _sessionFactory;

        public PlaceItemModel( 
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

        public void AddPlace(dto.Place place)
        {
            var domain = _placeConverter.Convert(place);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
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

        public bool IsPlaceExist(string placeName)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Place>()
                    .Where(x => x.Name == placeName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
