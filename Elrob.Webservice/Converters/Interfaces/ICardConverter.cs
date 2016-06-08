using CardDto = Elrob.Webservice.Dto.Card;
using CardDomain = Elrob.Common.Domain.Card;

namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface ICardConverter
    {
        List<CardDto> Convert(List<CardDomain> input);

        CardDomain Convert(CardDto input);
    }
}
