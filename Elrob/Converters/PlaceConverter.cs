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
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters
{
    public class PlaceConverter : IPlaceConverter
    {
        private IMapper _mapper;

        public PlaceConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Domain.Place, Place>();
                x.CreateMap<Place, Domain.Place>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<Place> Convert(List<Domain.Place> input)
        {
            return _mapper.Map<List<Place>>(input);
        }

        public Domain.Place Convert(Place place)
        {
            return _mapper.Map<Domain.Place>(place);
        }
    }
}