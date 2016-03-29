using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDto = Elrob.Terminal.Dto.User;
using UserDomain = Elrob.Terminal.Domain.User;
using GroupDto = Elrob.Terminal.Dto.Group;
using GroupDomain = Elrob.Terminal.Domain.Group;
using PermissionDto = Elrob.Terminal.Dto.Permission;
using PermissionDomain = Elrob.Terminal.Domain.Permission;
using AutoMapper;

namespace Elrob.Terminal.Converters
{
    public class GroupConverter : IGroupConverter
    {
        private IMapper _mapper;

        public GroupConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<GroupDomain, GroupDto>();
                x.CreateMap<PermissionDomain, PermissionDto>();

                x.CreateMap<GroupDto, GroupDomain>();
                x.CreateMap<PermissionDto, PermissionDomain>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<GroupDto> Convert(List<GroupDomain> input)
        {
            return _mapper.Map<List<GroupDto>>(input);
        }

        public GroupDomain Convert(GroupDto group)
        {
            return _mapper.Map<GroupDomain>(group);
        }
    }
}
