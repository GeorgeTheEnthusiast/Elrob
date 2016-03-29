using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProgressDto = Elrob.Terminal.Dto.OrderProgress;
using OrderProgressDomain = Elrob.Terminal.Domain.OrderProgress;

namespace Elrob.Terminal.Converters
{
    public interface IOrderProgressConverter
    {
        List<OrderProgressDto> Convert(List<OrderProgressDomain> input);

        OrderProgressDomain Convert(OrderProgressDto input);
    }
}
