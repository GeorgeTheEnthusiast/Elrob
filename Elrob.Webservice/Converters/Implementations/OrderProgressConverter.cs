namespace Elrob.Webservice.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.Webservice.Converters.Interfaces;
    using dto = Elrob.Webservice.Dto;
    using domain = Elrob.Common.Domain;

    public class OrderProgressConverter : IOrderProgressConverter
    {
        private IMapper _mapper;

        public OrderProgressConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<domain.OrderProgress, dto.OrderProgress>();
                x.CreateMap<domain.User, dto.User>();
                x.CreateMap<domain.OrderContent, dto.OrderContent>();
                x.CreateMap<domain.Group, dto.Group>();
                x.CreateMap<domain.Order, dto.Order>();
                x.CreateMap<domain.Place, dto.Place>();
                x.CreateMap<domain.Material, dto.Material>();
                x.CreateMap<domain.Permission, dto.Permission>();
                x.CreateMap<domain.Card, dto.Card>();

                x.CreateMap<dto.OrderProgress, domain.OrderProgress>();
                x.CreateMap<dto.User, domain.User>();
                x.CreateMap<dto.OrderContent, domain.OrderContent>();
                x.CreateMap<dto.Group, domain.Group>();
                x.CreateMap<dto.Order, domain.Order>();
                x.CreateMap<dto.Place, domain.Place>();
                x.CreateMap<dto.Material, domain.Material>();
                x.CreateMap<dto.Permission, domain.Permission>();
                x.CreateMap<dto.Card, domain.Card>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<dto.OrderProgress> Convert(List<domain.OrderProgress> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<dto.OrderProgress>>(input);
        }

        public domain.OrderProgress Convert(dto.OrderProgress input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<domain.OrderProgress>(input);
        }
    }
}