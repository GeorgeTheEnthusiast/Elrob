using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IOrderProgressModel
    {
        List<OrderProgress> GetOrderContentProgressById(int orderContentId);

        void DeleteOrderProgress(OrderProgress orderProgress);
    }
}
