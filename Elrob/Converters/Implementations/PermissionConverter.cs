using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

    public class PermissionConverter : IPermissionConverter
    {
        private IMapper _mapper;

        public PermissionConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Elrob.Common.Domain.Permission, Permission>();
                //x.CreateMap<Elrob.Common.Domain.Group, Group>();

                x.CreateMap<Permission, Elrob.Common.Domain.Permission>();
                //x.CreateMap<Group, Elrob.Common.Domain.Group>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<Permission> Convert(List<Elrob.Common.Domain.Permission> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<Permission>>(input);
        }

        public List<Elrob.Common.Domain.Permission> Convert(List<Permission> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<Elrob.Common.Domain.Permission>>(input);
        }
    }
}