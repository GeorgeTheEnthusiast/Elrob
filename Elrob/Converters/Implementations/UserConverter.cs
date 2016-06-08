using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using UserDto = Elrob.Terminal.Dto.User;
using UserDomain = Elrob.Common.Domain.User;
using GroupDto = Elrob.Terminal.Dto.Group;
using GroupDomain = Elrob.Common.Domain.Group;
using PermissionDto = Elrob.Terminal.Dto.Permission;
using PermissionDomain = Elrob.Common.Domain.Permission;
using CardDto = Elrob.Terminal.Dto.Card;
using CardDomain = Elrob.Common.Domain.Card;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

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
                x.CreateMap<CardDomain, CardDto>();

                x.CreateMap<UserDto, UserDomain>();
                x.CreateMap<GroupDto, GroupDomain>();
                x.CreateMap<PermissionDto, PermissionDomain>();
                x.CreateMap<CardDto, CardDomain>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public UserDto Convert(UserDomain input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<UserDto>(input);
        }

        public List<UserDto> Convert(List<UserDomain> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<UserDto>>(input);
        }

        public UserDomain Convert(UserDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<UserDomain>(input);
        }
    }
}
