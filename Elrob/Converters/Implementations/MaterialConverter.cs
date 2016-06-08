using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using MaterialDto = Elrob.Terminal.Dto.Material;
using MaterialDomain = Elrob.Common.Domain.Material;

namespace Elrob.Terminal.Converters.Implementations
{
    using System;

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

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<MaterialDto> Convert(List<MaterialDomain> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<List<MaterialDto>>(input);
        }

        public MaterialDomain Convert(MaterialDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return _mapper.Map<MaterialDomain>(input);
        }
    }
}