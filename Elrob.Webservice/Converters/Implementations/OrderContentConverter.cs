using dto = Elrob.Webservice.Dto;
using domain = Elrob.Common.Domain;

namespace Elrob.Webservice.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.Webservice.Converters.Interfaces;

    public class OrderContentConverter : IOrderContentConverter
    {
        private readonly IMapper _mapper;

        public OrderContentConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<dto.OrderContent, domain.OrderContent>();
                x.CreateMap<dto.Order, domain.Order>();
                x.CreateMap<dto.Material, domain.Material>();
                x.CreateMap<dto.Place, domain.Place>();

                x.CreateMap<domain.OrderContent, dto.OrderContent>();
                x.CreateMap<domain.Order, dto.Order>();
                x.CreateMap<domain.Material, dto.Material>();
                x.CreateMap<domain.Place, dto.Place>();

                x.CreateMap<dto.OrderContent, dto.OrderContent>();
                x.CreateMap<dto.Order, dto.Order>();
                x.CreateMap<dto.Material, dto.Material>();
                x.CreateMap<dto.Place, dto.Place>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<domain.OrderContent> Convert(List<dto.OrderContent> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<domain.OrderContent>>(input);
        }

        public List<dto.OrderContent> Convert(List<domain.OrderContent> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<dto.OrderContent>>(input);
        }

        public domain.OrderContent Convert(dto.OrderContent input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<domain.OrderContent>(input);
        }

        public dto.OrderContent Clone(dto.OrderContent source, dto.OrderContent destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }
            return this._mapper.Map<dto.OrderContent, dto.OrderContent>(source, destination);
        }
    }
}
