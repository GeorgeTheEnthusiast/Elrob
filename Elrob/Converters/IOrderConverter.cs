using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDto = Elrob.Terminal.Dto.Order;
using OrderDomain = Elrob.Terminal.Domain.Order;
using OrderWebservice = Elrob.Terminal.ExcelServiceServiceReference.Order;

namespace Elrob.Terminal.Converters
{
    public interface IOrderConverter
    {
        OrderDomain Convert(OrderDto input);

        List<OrderDto> Convert(List<OrderDomain> orders);
    }
}
