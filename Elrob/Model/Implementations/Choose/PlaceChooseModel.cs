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
    using Elrob.Common.DataAccess;

    public class PlaceChooseModel : IPlaceChooseModel
    {
        private readonly IPlaceConverter _placeConverter;

        private ISessionFactory _sessionFactory;

        public PlaceChooseModel( 
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
                var domain = session.QueryOver<Elrob.Common.Domain.Place>()
                    .List()
                    .ToList();

                var dto = _placeConverter.Convert(domain);

                return dto;
            }
        }
    }
}
