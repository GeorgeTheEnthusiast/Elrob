using System;
using System.Collections.Generic;
using AutoMapper;
using Elrob.Terminal.Converters.Interfaces;
using CardDto = Elrob.Terminal.Dto.Card;
using CardDomain = Elrob.Terminal.Domain.Card;

namespace Elrob.Terminal.Converters.Implementations
{
    public class CardConverter : ICardConverter
    {
        private IMapper _mapper;

        public CardConverter()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<CardDomain, CardDto>();
                x.CreateMap<CardDto, CardDomain>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public List<CardDto> Convert(List<CardDomain> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return _mapper.Map<List<CardDto>>(input);
        }

        public CardDomain Convert(CardDto input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return _mapper.Map<CardDomain>(input);
        }
    }
}