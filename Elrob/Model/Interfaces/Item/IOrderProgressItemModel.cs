using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IOrderProgressItemModel
    {
        void AddOrderProgress(OrderProgress orderProgress);

        void UpdateOrderProgress(OrderProgress orderProgress);
    }
}
