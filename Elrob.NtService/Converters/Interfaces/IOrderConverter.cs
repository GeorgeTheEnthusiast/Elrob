using OrderDto = Elrob.NtService.Dto.Order;
using OrderDomain = Elrob.Common.Domain.Order;

namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IOrderConverter
    {
        OrderDomain Convert(OrderDto input);

        List<OrderDto> Convert(List<OrderDomain> orders);
    }
}
