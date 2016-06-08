using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using OrderContentDto = Elrob.Terminal.Dto.OrderContent;
using OrderContentDomain = Elrob.Common.Domain.OrderContent;
using OrderContentWebservice = Elrob.Terminal.ExcelServiceServiceReference.OrderContent;
using OrderDto = Elrob.Terminal.Dto.Order;
using OrderDomain = Elrob.Common.Domain.Order;
using OrderWebservice = Elrob.Terminal.ExcelServiceServiceReference.Order;
using MaterialDto = Elrob.Terminal.Dto.Material;
using MaterialDomain = Elrob.Common.Domain.Material;
using MaterialWebservice = Elrob.Terminal.ExcelServiceServiceReference.Material;
using PlaceWebservice = Elrob.Terminal.ExcelServiceServiceReference.Place;
using DomainEntities = Elrob.Common.Domain;
using Place = Elrob.Terminal.Dto.Place;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

    public class OrderContentConverter : IOrderContentConverter
    {
        private readonly IMapper _mapper;

        public OrderContentConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<OrderContentWebservice, OrderContentDto>();
                x.CreateMap<OrderWebservice, OrderDto>();
                x.CreateMap<MaterialWebservice, MaterialDto>();
                x.CreateMap<PlaceWebservice, Place>();

                x.CreateMap<OrderContentDto, OrderContentDomain>();
                x.CreateMap<OrderDto, OrderDomain>();
                x.CreateMap<MaterialDto, MaterialDomain>();
                x.CreateMap<Place, DomainEntities.Place>();

                x.CreateMap<OrderContentDomain, OrderContentDto>();
                x.CreateMap<OrderDomain, OrderDto>();
                x.CreateMap<MaterialDomain, MaterialDto>();
                x.CreateMap<DomainEntities.Place, Place>();

                x.CreateMap<OrderContentDto, OrderContentDto>();
                x.CreateMap<OrderDto, OrderDto>();
                x.CreateMap<MaterialDto, MaterialDto>();
                x.CreateMap<Place, Place>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public OrderContentDto Convert(OrderContentWebservice input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<OrderContentDto>(input);
        }

        public List<OrderContentDto> Convert(List<OrderContentWebservice> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<OrderContentDto>>(input);
        }

        public List<OrderContentDomain> Convert(List<OrderContentDto> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<OrderContentDomain>>(input);
        }

        public List<OrderContentDto> Convert(List<OrderContentDomain> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<OrderContentDto>>(input);
        }

        public OrderContentDomain Convert(OrderContentDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<OrderContentDomain>(input);
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
            return _mapper.Map<OrderContentDto, OrderContentDto>(source, destination);
        }
    }
}
