using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IOrderItemModel
    {
        void AddOrder(Order order);

        void UpdateOrder(Order order);

        bool IsOrderExist(string orderName);
    }
}
