using OrderContentDto = Elrob.Webservice.Dto.OrderContent;
using OrderContentDomain = Elrob.Common.Domain.OrderContent;

namespace Elrob.Webservice.Converters.Interfaces
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
