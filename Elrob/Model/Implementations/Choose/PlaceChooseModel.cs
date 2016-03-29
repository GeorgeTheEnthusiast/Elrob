using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Choose;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Choose
{
    public class PlaceChooseModel : IPlaceChooseModel
    {
        private readonly IPlaceConverter _placeConverter;

        public PlaceChooseModel( 
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
    }
}
