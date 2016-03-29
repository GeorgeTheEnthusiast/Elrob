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
    public class PermissionConverter : IPermissionConverter
    {
        private IMapper _mapper;

        public PermissionConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Domain.Permission, Permission>();
                x.CreateMap<Domain.Group, Group>();

                x.CreateMap<Permission, Domain.Permission>();
                x.CreateMap<Group, Domain.Group>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<Permission> Convert(List<Domain.Permission> input)
        {
            return _mapper.Map<List<Permission>>(input);
        }

        public List<Domain.Permission> Convert(List<Permission> input)
        {
            return _mapper.Map<List<Domain.Permission>>(input);
        }
    }
}