using MaterialDto = Elrob.NtService.Dto.Material;
using MaterialDomain = Elrob.Common.Domain.Material;

namespace Elrob.NtService.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.NtService.Converters.Interfaces;

    public class MaterialConverter : IMaterialConverter
    {
        private IMapper _mapper;

        public MaterialConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<MaterialDomain, MaterialDto>();
                x.CreateMap<MaterialDto, MaterialDomain>();
            });

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<MaterialDto> Convert(List<MaterialDomain> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<List<MaterialDto>>(input);
        }

        public MaterialDomain Convert(MaterialDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return this._mapper.Map<MaterialDomain>(input);
        }
    }
}