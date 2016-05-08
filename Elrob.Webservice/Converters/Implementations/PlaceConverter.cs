namespace Elrob.Webservice.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.Webservice.Converters.Interfaces;
    using Elrob.Webservice.Dto;

    public class PlaceConverter : IPlaceConverter
    {
        private IMapper _mapper;

        public PlaceConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Domain.Place, Place>();
                x.CreateMap<Place, Domain.Place>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<Place> Convert(List<Domain.Place> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<Place>>(input);
        }

        public Domain.Place Convert(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return this._mapper.Map<Domain.Place>(place);
        }

        public Place Convert(Domain.Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return this._mapper.Map<Place>(place);
        }
    }
}