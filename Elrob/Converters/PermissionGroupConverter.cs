using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDto = Elrob.Terminal.Dto.User;
using UserDomain = Elrob.Terminal.Domain.User;
using GroupDto = Elrob.Terminal.Dto.Group;
using GroupDomain = Elrob.Terminal.Domain.Group;
using PermissionGroupDto = Elrob.Terminal.Dto.PermissionGroup;
using PermissionGroupDomain = Elrob.Terminal.Domain.PermissionGroup;
using AutoMapper;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters
{
    public class PermissionGroupConverter : IPermissionGroupConverter
    {
        private IMapper _mapper;

        public PermissionGroupConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<PermissionGroup, PermissionGroupDomain>();
                x.CreateMap<Permission, Domain.Permission>();
                x.CreateMap<Group, Domain.Group>();

                x.CreateMap<PermissionGroupDomain, PermissionGroup>();
                x.CreateMap<Domain.Permission, Permission>();
                x.CreateMap<Domain.Group, Group>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<PermissionGroup> Convert(List<Domain.PermissionGroup> input)
        {
            return _mapper.Map<List<PermissionGroup>>(input);
        }

        public List<Domain.PermissionGroup> Convert(List<PermissionGroup> input)
        {
            return _mapper.Map<List<Domain.PermissionGroup>>(input);
        }

        public PermissionGroupDomain Convert(PermissionGroup input)
        {
            return _mapper.Map<PermissionGroupDomain>(input);
        }
    }
}
