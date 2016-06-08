namespace Elrob.NtService.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.NtService.Converters.Interfaces;
    using Elrob.NtService.Dto;

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

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<Place> Convert(List<Elrob.Common.Domain.Place> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<Place>>(input);
        }

        public Elrob.Common.Domain.Place Convert(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return this._mapper.Map<Elrob.Common.Domain.Place>(place);
        }

        public Place Convert(Elrob.Common.Domain.Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return this._mapper.Map<Place>(place);
        }
    }
}