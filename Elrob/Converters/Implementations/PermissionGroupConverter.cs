using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;
using PermissionGroupDomain = Elrob.Common.Domain.PermissionGroup;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

    public class PermissionGroupConverter : IPermissionGroupConverter
    {
        private IMapper _mapper;

        public PermissionGroupConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<PermissionGroup, PermissionGroupDomain>();
                x.CreateMap<Permission, Elrob.Common.Domain.Permission>();
                x.CreateMap<Group, Elrob.Common.Domain.Group>();

                x.CreateMap<PermissionGroupDomain, PermissionGroup>();
                x.CreateMap<Elrob.Common.Domain.Permission, Permission>();
                x.CreateMap<Elrob.Common.Domain.Group, Group>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<PermissionGroup> Convert(List<Elrob.Common.Domain.PermissionGroup> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<PermissionGroup>>(input);
        }

        public List<Elrob.Common.Domain.PermissionGroup> Convert(List<PermissionGroup> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<Elrob.Common.Domain.PermissionGroup>>(input);
        }

        public PermissionGroupDomain Convert(PermissionGroup input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<PermissionGroupDomain>(input);
        }
    }
}
