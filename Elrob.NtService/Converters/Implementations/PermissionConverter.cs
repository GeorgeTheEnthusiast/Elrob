namespace Elrob.NtService.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.NtService.Converters.Interfaces;
    using Elrob.NtService.Dto;

    public class PermissionConverter : IPermissionConverter
    {
        private IMapper _mapper;

        public PermissionConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Elrob.Common.Domain.Permission, Permission>();

                x.CreateMap<Permission, Elrob.Common.Domain.Permission>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<Permission> Convert(List<Elrob.Common.Domain.Permission> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<Permission>>(input);
        }

        public List<Elrob.Common.Domain.Permission> Convert(List<Permission> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<Elrob.Common.Domain.Permission>>(input);
        }
    }
}