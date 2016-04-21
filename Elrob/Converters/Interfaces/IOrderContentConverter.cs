using System.Collections.Generic;
using OrderContentDto = Elrob.Terminal.Dto.OrderContent;
using OrderContentDomain = Elrob.Terminal.Domain.OrderContent;
using OrderContentWebservice = Elrob.Terminal.Service_References.ExcelServiceServiceReference.OrderContent;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IOrderContentConverter
    {
        OrderContentDto Convert(OrderContentWebservice input);

        List<OrderContentDto> Convert(List<OrderContentWebservice> input);

        List<OrderContentDomain> Convert(List<OrderContentDto> input);

        List<OrderContentDto> Convert(List<OrderContentDomain> input);

        OrderContentDomain Convert(OrderContentDto input);

        OrderContentDto Clone(OrderContentDto source, OrderContentDto destination);
    }
}
