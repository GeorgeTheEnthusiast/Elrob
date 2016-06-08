using System.Collections.Generic;
using OrderDto = Elrob.Terminal.Dto.Order;
using OrderDomain = Elrob.Common.Domain.Order;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IOrderConverter
    {
        OrderDomain Convert(OrderDto input);

        List<OrderDto> Convert(List<OrderDomain> orders);
    }
}
