using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

    public class PlaceConverter : IPlaceConverter
    {
        private IMapper _mapper;

        public PlaceConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Elrob.Common.Domain.Place, Place>();
                x.CreateMap<Place, Elrob.Common.Domain.Place>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<Place> Convert(List<Elrob.Common.Domain.Place> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<Place>>(input);
        }

        public Elrob.Common.Domain.Place Convert(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return _mapper.Map<Elrob.Common.Domain.Place>(place);
        }
    }
}