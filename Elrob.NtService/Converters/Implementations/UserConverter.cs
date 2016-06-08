using UserDto = Elrob.NtService.Dto.User;
using UserDomain = Elrob.Common.Domain.User;
using GroupDto = Elrob.NtService.Dto.Group;
using GroupDomain = Elrob.Common.Domain.Group;
using PermissionDto = Elrob.NtService.Dto.Permission;
using PermissionDomain = Elrob.Common.Domain.Permission;
using CardDto = Elrob.NtService.Dto.Card;
using CardDomain = Elrob.Common.Domain.Card;

namespace Elrob.NtService.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.NtService.Converters.Interfaces;

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

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public UserDto Convert(UserDomain input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<UserDto>(input);
        }

        public List<UserDto> Convert(List<UserDomain> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<UserDto>>(input);
        }

        public UserDomain Convert(UserDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<UserDomain>(input);
        }
    }
}
