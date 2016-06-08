using System.Collections.Generic;
using CardDto = Elrob.Terminal.Dto.Card;
using CardDomain = Elrob.Common.Domain.Card;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface ICardConverter
    {
        List<CardDto> Convert(List<CardDomain> input);

        CardDomain Convert(CardDto input);
    }
}
