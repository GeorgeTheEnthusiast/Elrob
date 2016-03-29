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
using AutoMapper;

namespace Elrob.Terminal.Converters
{
    public class OrderConverter : IOrderConverter
    {
        private IMapper _mapper;

        public OrderConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<OrderDto, OrderDomain>();
                x.CreateMap<OrderDomain, OrderDto>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public OrderDomain Convert(OrderDto input)
        {
            return _mapper.Map<OrderDomain>(input);
        }

        public List<OrderDto> Convert(List<OrderDomain> orders)
        {
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
