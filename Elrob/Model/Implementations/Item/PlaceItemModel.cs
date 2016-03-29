using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class PlaceItemModel : IPlaceItemModel
    {
        private readonly IPlaceConverter _placeConverter;

        public PlaceItemModel( 
            IPlaceConverter placeConverter)
        {
            if (placeConverter == null) throw new ArgumentNullException("placeConverter");
            _placeConverter = placeConverter;
        }

        public void AddPlace(dto.Place place)
        {
            var domain = _placeConverter.Convert(place);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
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

        public bool IsPlaceExist(string placeName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Place>()
                    .Where(x => x.Name == placeName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
