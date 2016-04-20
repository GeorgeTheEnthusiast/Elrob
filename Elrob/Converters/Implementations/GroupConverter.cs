using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using GroupDto = Elrob.Terminal.Dto.Group;
using GroupDomain = Elrob.Terminal.Domain.Group;
using PermissionDto = Elrob.Terminal.Dto.Permission;
using PermissionDomain = Elrob.Terminal.Domain.Permission;

namespace Elrob.Terminal.Converters.Implementations
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
