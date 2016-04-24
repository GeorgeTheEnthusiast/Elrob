using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using OrderDto = Elrob.Terminal.Dto.Order;
using OrderDomain = Elrob.Terminal.Domain.Order;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

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
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<OrderDomain>(input);
        }

        public List<OrderDto> Convert(List<OrderDomain> orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
