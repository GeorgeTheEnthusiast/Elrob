using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Implementations
{
    public class OrderProgressConverter : IOrderProgressConverter
    {
        private IMapper _mapper;

        public OrderProgressConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Domain.OrderProgress, OrderProgress>();
                x.CreateMap<Domain.User, User>();
                x.CreateMap<Domain.OrderContent, OrderContent>();
                x.CreateMap<Domain.Group, Group>();
                x.CreateMap<Domain.Order, Order>();
                x.CreateMap<Domain.Place, Place>();
                x.CreateMap<Domain.Material, Material>();
                x.CreateMap<Domain.Permission, Permission>();
                x.CreateMap<OrderProgress, Domain.OrderProgress>();
                x.CreateMap<User, Domain.User>();
                x.CreateMap<OrderContent, Domain.OrderContent>();
                x.CreateMap<Group, Domain.Group>();
                x.CreateMap<Order, Domain.Order>();
                x.CreateMap<Place, Domain.Place>();
                x.CreateMap<Material, Domain.Material>();
                x.CreateMap<Permission, Domain.Permission>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<OrderProgress> Convert(List<Domain.OrderProgress> input)
        {
            return _mapper.Map<List<OrderProgress>>(input);
        }

        public Domain.OrderProgress Convert(OrderProgress input)
        {
            return _mapper.Map<Domain.OrderProgress>(input);
        }
    }
}