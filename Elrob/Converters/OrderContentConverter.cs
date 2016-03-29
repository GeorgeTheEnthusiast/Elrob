using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderContentDto = Elrob.Terminal.Dto.OrderContent;
using OrderContentDomain = Elrob.Terminal.Domain.OrderContent;
using OrderContentWebservice = Elrob.Terminal.ExcelServiceServiceReference.OrderContent;
using OrderDto = Elrob.Terminal.Dto.Order;
using OrderDomain = Elrob.Terminal.Domain.Order;
using OrderWebservice = Elrob.Terminal.ExcelServiceServiceReference.Order;
using MaterialDto = Elrob.Terminal.Dto.Material;
using MaterialDomain = Elrob.Terminal.Domain.Material;
using MaterialWebservice = Elrob.Terminal.ExcelServiceServiceReference.Material;
using PlaceWebservice = Elrob.Terminal.ExcelServiceServiceReference.Place;
using DomainEntities = Elrob.Terminal.Domain;
using AutoMapper;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters
{
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
            return _mapper.Map<OrderContentDto>(input);
        }

        public List<OrderContentDto> Convert(List<OrderContentWebservice> input)
        {
            return _mapper.Map<List<OrderContentDto>>(input);
        }

        public List<OrderContentDomain> Convert(List<OrderContentDto> input)
        {
            return _mapper.Map<List<OrderContentDomain>>(input);
        }

        public List<OrderContentDto> Convert(List<OrderContentDomain> input)
        {
            return _mapper.Map<List<OrderContentDto>>(input);
        }

        public OrderContentDomain Convert(OrderContentDto input)
        {
            return _mapper.Map<OrderContentDomain>(input);
        }

        public OrderContent Clone(OrderContent source, OrderContent destination)
        {
            return _mapper.Map<OrderContent, OrderContent>(source, destination);
        }
    }
}
