namespace Elrob.Webservice.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.Webservice.Converters.Interfaces;
    using dto = Elrob.Webservice.Dto;
    using domain = Elrob.Common.Domain;

    public class PermissionGroupConverter : IPermissionGroupConverter
    {
        private IMapper _mapper;

        public PermissionGroupConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<dto.PermissionGroup, domain.PermissionGroup>();
                x.CreateMap<dto.Permission, domain.Permission>();
                x.CreateMap<dto.Group, domain.Group>();

                x.CreateMap<domain.PermissionGroup, dto.PermissionGroup>();
                x.CreateMap<domain.Permission, dto.Permission>();
                x.CreateMap<domain.Group, dto.Group>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<dto.PermissionGroup> Convert(List<domain.PermissionGroup> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<dto.PermissionGroup>>(input);
        }

        public List<domain.PermissionGroup> Convert(List<dto.PermissionGroup> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<domain.PermissionGroup>>(input);
        }

        public domain.PermissionGroup Convert(dto.PermissionGroup input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<domain.PermissionGroup>(input);
        }
    }
}
