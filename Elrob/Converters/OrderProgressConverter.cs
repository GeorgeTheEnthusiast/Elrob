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
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters
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