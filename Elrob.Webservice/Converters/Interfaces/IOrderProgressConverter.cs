using OrderProgressDto = Elrob.Webservice.Dto.OrderProgress;
using OrderProgressDomain = Elrob.Webservice.Domain.OrderProgress;

namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IOrderProgressConverter
    {
        List<OrderProgressDto> Convert(List<OrderProgressDomain> input);

        OrderProgressDomain Convert(OrderProgressDto input);
    }
}
