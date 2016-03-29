using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderContentPresenter
    {
        void DeleteOrderContent(OrderContent orderContent);

        void UpdateOrderContent(OrderContent orderContent);

        void AddOrderContent(OrderContent orderContent);

        void ShowDialog(Order order, Place place);

        void RefreshData(Order order, Place place);
    }
}
