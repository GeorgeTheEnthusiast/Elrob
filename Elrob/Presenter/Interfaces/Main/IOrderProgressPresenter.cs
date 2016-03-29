using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderProgressPresenter
    {
        List<OrderProgress> GetOrderContentProgressById(int orderContentId);

        void DeleteOrderProgress(OrderProgress orderProgress);

        void ShowDialog(OrderContent orderContent);

        void RefreshData();
    }
}
