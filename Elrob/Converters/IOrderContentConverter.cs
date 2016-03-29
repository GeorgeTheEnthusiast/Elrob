using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderContentDto = Elrob.Terminal.Dto.OrderContent;
using OrderContentDomain = Elrob.Terminal.Domain.OrderContent;
using OrderContentWebservice = Elrob.Terminal.ExcelServiceServiceReference.OrderContent;

namespace Elrob.Terminal.Converters
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
