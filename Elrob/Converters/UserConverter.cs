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
    public class UserConverter : IUserConverter
    {
        private IMapper _mapper;

        public UserConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserDomain, UserDto>();
                x.CreateMap<GroupDomain, GroupDto>();
                x.CreateMap<PermissionDomain, PermissionDto>();

                x.CreateMap<UserDto, UserDomain>();
                x.CreateMap<GroupDto, GroupDomain>();
                x.CreateMap<PermissionDto, PermissionDomain>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public UserDto Convert(UserDomain input)
        {
            return _mapper.Map<UserDto>(input);
        }

        public List<UserDto> Convert(List<UserDomain> input)
        {
            return _mapper.Map<List<UserDto>>(input);
        }

        public UserDomain Convert(UserDto input)
        {
            return _mapper.Map<UserDomain>(input);
        }
    }
}
