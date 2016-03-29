using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IOrderModel
    {
        List<Order> GetAllOrders();

        void AddOrder(Order order);

        void DeleteOrder(Order order);

        void UpdateOrder(Order order);

        List<Order> GetOrdersWithProgressByPlace(int placeId);

        List<Order> GetOrdersWithProgress();
    }
}
