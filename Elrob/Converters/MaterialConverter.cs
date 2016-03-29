using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderContentDto = Elrob.Terminal.Dto.OrderContent;
using OrderContentDomain = Elrob.Terminal.Domain.OrderContent;
using OrderContentWebservice = Elrob.Terminal.ExcelServiceServiceReference.OrderContent;
using OrderDto = Elrob.Terminal.Dto.Order;
using OrderDomain = Elrob.Terminal.Domain.Order;
using OrderWebservice = Elrob.Terminal.ExcelServiceServiceReference.Order;
using MaterialDto = Elrob.Terminal.Dto.Material;
using MaterialDomain = Elrob.Terminal.Domain.Material;
using MaterialWebservice = Elrob.Terminal.ExcelServiceServiceReference.Material;
using AutoMapper;

namespace Elrob.Terminal.Converters
{
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
            return _mapper.Map<List<MaterialDto>>(input);
        }

        public MaterialDomain Convert(MaterialDto input)
        {
            return _mapper.Map<MaterialDomain>(input);
        }
    }
}