using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

    public class OrderProgressConverter : IOrderProgressConverter
    {
        private IMapper _mapper;

        public OrderProgressConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Elrob.Common.Domain.OrderProgress, OrderProgress>();
                x.CreateMap<Elrob.Common.Domain.User, User>();
                x.CreateMap<Elrob.Common.Domain.OrderContent, OrderContent>();
                x.CreateMap<Elrob.Common.Domain.Group, Group>();
                x.CreateMap<Elrob.Common.Domain.Order, Order>();
                x.CreateMap<Elrob.Common.Domain.Place, Place>();
                x.CreateMap<Elrob.Common.Domain.Material, Material>();
                x.CreateMap<Elrob.Common.Domain.Permission, Permission>();
                x.CreateMap<Elrob.Common.Domain.Card, Card>();

                x.CreateMap<OrderProgress, Elrob.Common.Domain.OrderProgress>();
                x.CreateMap<User, Elrob.Common.Domain.User>();
                x.CreateMap<OrderContent, Elrob.Common.Domain.OrderContent>();
                x.CreateMap<Group, Elrob.Common.Domain.Group>();
                x.CreateMap<Order, Elrob.Common.Domain.Order>();
                x.CreateMap<Place, Elrob.Common.Domain.Place>();
                x.CreateMap<Material, Elrob.Common.Domain.Material>();
                x.CreateMap<Permission, Elrob.Common.Domain.Permission>();
                x.CreateMap<Card, Elrob.Common.Domain.Card>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<OrderProgress> Convert(List<Elrob.Common.Domain.OrderProgress> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<OrderProgress>>(input);
        }

        public Elrob.Common.Domain.OrderProgress Convert(OrderProgress input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<Elrob.Common.Domain.OrderProgress>(input);
        }
    }
}