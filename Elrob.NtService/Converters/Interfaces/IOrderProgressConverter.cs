using OrderProgressDto = Elrob.NtService.Dto.OrderProgress;
using OrderProgressDomain = Elrob.NtService.Domain.OrderProgress;

namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IOrderProgressConverter
    {
        List<OrderProgressDto> Convert(List<OrderProgressDomain> input);

        OrderProgressDomain Convert(OrderProgressDto input);
    }
}
