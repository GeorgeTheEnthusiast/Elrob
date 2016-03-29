using System.Collections.Generic;
using OrderContentDto = Elrob.Terminal.Dto.OrderContent;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IOrderContentModel
    {
        List<OrderContentDto> GetOrderContent(int orderId, int placeId);

        List<OrderContentDto> GetOrderContent(int orderId);

        void AddOrderContent(OrderContentDto orderContent);

        void DeleteOrderContent(OrderContentDto orderContent);

        void UpdateOrderContent(OrderContentDto orderContent);
    }
}
