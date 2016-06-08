namespace Elrob.Webservice.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.Webservice.Converters.Interfaces;
    using dto = Elrob.Webservice.Dto;
    using domain = Elrob.Common.Domain;

    public class PlaceConverter : IPlaceConverter
    {
        private IMapper _mapper;

        public PlaceConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<domain.Place, dto.Place>();
                x.CreateMap<dto.Place, domain.Place>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<dto.Place> Convert(List<domain.Place> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<dto.Place>>(input);
        }

        public domain.Place Convert(dto.Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return this._mapper.Map<domain.Place>(place);
        }

        public dto.Place Convert(domain.Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return this._mapper.Map<dto.Place>(place);
        }
    }
}