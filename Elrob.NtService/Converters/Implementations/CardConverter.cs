using CardDto = Elrob.NtService.Dto.Card;
using CardDomain = Elrob.NtService.Domain.Card;

namespace Elrob.NtService.Converters.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Elrob.NtService.Converters.Interfaces;

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

            this._mapper = mapperConfiguration.CreateMapper();
        }

        public List<CardDto> Convert(List<CardDomain> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return this._mapper.Map<List<CardDto>>(input);
        }

        public CardDomain Convert(CardDto input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return this._mapper.Map<CardDomain>(input);
        }
    }
}