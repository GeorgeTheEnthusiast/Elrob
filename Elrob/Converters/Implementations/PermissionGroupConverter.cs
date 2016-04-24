using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;
using PermissionGroupDomain = Elrob.Terminal.Domain.PermissionGroup;

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
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<PermissionGroup>>(input);
        }

        public List<Domain.PermissionGroup> Convert(List<PermissionGroup> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<Domain.PermissionGroup>>(input);
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
