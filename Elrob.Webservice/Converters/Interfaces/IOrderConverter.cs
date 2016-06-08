using OrderDto = Elrob.Webservice.Dto.Order;
using OrderDomain = Elrob.Common.Domain.Order;

namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IOrderConverter
    {
        OrderDomain Convert(OrderDto input);

        List<OrderDto> Convert(List<OrderDomain> orders);
    }
}
