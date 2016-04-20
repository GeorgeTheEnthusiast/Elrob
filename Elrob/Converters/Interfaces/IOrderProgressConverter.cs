using System.Collections.Generic;
using OrderProgressDto = Elrob.Terminal.Dto.OrderProgress;
using OrderProgressDomain = Elrob.Terminal.Domain.OrderProgress;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IOrderProgressConverter
    {
        List<OrderProgressDto> Convert(List<OrderProgressDomain> input);

        OrderProgressDomain Convert(OrderProgressDto input);
    }
}
