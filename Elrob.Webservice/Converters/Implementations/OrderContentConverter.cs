using OrderContentDto = Elrob.Webservice.Dto.OrderContent;
using OrderContentDomain = Elrob.Webservice.Domain.OrderContent;
using OrderDto = Elrob.Webservice.Dto.Order;
using OrderDomain = Elrob.Webservice.Domain.Order;
using MaterialDto = Elrob.Webservice.Dto.Material;
using MaterialDomain = Elrob.Webservice.Domain.Material;
using Place = Elrob.Webservice.Dto.Place;

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
                x.CreateMap<OrderContentDto, OrderContentDomain>();
                x.CreateMap<OrderDto, OrderDomain>();
                x.CreateMap<MaterialDto, MaterialDomain>();
                x.CreateMap<Place, Domain.Place>();

                x.CreateMap<OrderContentDomain, OrderContentDto>();
                x.CreateMap<OrderDomain, OrderDto>();
                x.CreateMap<MaterialDomain, MaterialDto>();
                x.CreateMap<Domain.Place, Place>();

                x.CreateMap<OrderContentDto, OrderContentDto>();
                x.CreateMap<OrderDto, OrderDto>();
                x.CreateMap<MaterialDto, MaterialDto>();
                x.CreateMap<Place, Place>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<OrderContentDomain> Convert(List<OrderContentDto> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<OrderContentDomain>>(input);
        }

        public List<OrderContentDto> Convert(List<OrderContentDomain> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<OrderContentDto>>(input);
        }

        public OrderContentDomain Convert(OrderContentDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<OrderContentDomain>(input);
        }

        public OrderContentDto Clone(OrderContentDto source, OrderContentDto destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }
            return this._mapper.Map<OrderContentDto, OrderContentDto>(source, destination);
        }
    }
}
