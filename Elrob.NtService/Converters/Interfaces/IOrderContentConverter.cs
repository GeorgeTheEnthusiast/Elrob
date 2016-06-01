using OrderContentDto = Elrob.NtService.Dto.OrderContent;
using OrderContentDomain = Elrob.NtService.Domain.OrderContent;

namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IOrderContentConverter
    {
        List<OrderContentDomain> Convert(List<OrderContentDto> input);

        List<OrderContentDto> Convert(List<OrderContentDomain> input);

        OrderContentDomain Convert(OrderContentDto input);

        OrderContentDto Clone(OrderContentDto source, OrderContentDto destination);
    }
}
