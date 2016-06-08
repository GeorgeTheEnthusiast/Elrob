namespace Elrob.Webservice.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.Webservice.Converters.Interfaces;
    using dto = Elrob.Webservice.Dto;
    using domain = Elrob.Common.Domain;

    public class PermissionConverter : IPermissionConverter
    {
        private IMapper _mapper;

        public PermissionConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<domain.Permission, dto.Permission>();

                x.CreateMap<dto.Permission, domain.Permission>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<dto.Permission> Convert(List<domain.Permission> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<dto.Permission>>(input);
        }

        public List<domain.Permission> Convert(List<dto.Permission> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<domain.Permission>>(input);
        }
    }
}