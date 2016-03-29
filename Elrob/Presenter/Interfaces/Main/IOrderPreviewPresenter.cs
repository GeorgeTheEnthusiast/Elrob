using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.View;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderPreviewPresenter
    {
        bool SaveOrder(Order order, List<OrderContent> orderContents);

        void AddOrderContent(OrderContent orderContent);

        void UpdateOrderContent(OrderContent orderContent);

        void DeleteOrderContent(OrderContent orderContent);

        DialogResult ShowDialog(OrderPreviewViewModel orderPreviewViewModel);
    }
}
