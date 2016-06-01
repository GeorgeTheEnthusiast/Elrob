using OrderDto = Elrob.NtService.Dto.Order;
using OrderDomain = Elrob.NtService.Domain.Order;

namespace Elrob.NtService.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.NtService.Converters.Interfaces;

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

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public OrderDomain Convert(OrderDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<OrderDomain>(input);
        }

        public List<OrderDto> Convert(List<OrderDomain> orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }
            return this._mapper.Map<List<OrderDto>>(orders);
        }
    }
}
