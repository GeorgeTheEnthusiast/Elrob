using CardDto = Elrob.NtService.Dto.Card;
using CardDomain = Elrob.NtService.Domain.Card;

namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface ICardConverter
    {
        List<CardDto> Convert(List<CardDomain> input);

        CardDomain Convert(CardDto input);
    }
}
