using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IOrderProgressItemPresenter
    {
        void UpdateOrderProgress(OrderProgress orderProgress);

        void AddOrderProgress(OrderProgress orderProgress);

        DialogResult ShowDialog(OrderContent orderContent, OrderProgress orderProgress);
    }
}
