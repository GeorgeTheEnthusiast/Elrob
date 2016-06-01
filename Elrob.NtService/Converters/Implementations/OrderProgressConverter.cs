namespace Elrob.NtService.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.NtService.Converters.Interfaces;
    using Elrob.NtService.Dto;

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
                x.CreateMap<Domain.Card, Card>();

                x.CreateMap<OrderProgress, Domain.OrderProgress>();
                x.CreateMap<User, Domain.User>();
                x.CreateMap<OrderContent, Domain.OrderContent>();
                x.CreateMap<Group, Domain.Group>();
                x.CreateMap<Order, Domain.Order>();
                x.CreateMap<Place, Domain.Place>();
                x.CreateMap<Material, Domain.Material>();
                x.CreateMap<Permission, Domain.Permission>();
                x.CreateMap<Card, Domain.Card>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<OrderProgress> Convert(List<Domain.OrderProgress> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<OrderProgress>>(input);
        }

        public Domain.OrderProgress Convert(OrderProgress input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<Domain.OrderProgress>(input);
        }
    }
}