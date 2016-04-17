using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IOrderProgressItemPresenter
    {
        void AcceptChanges();

        DialogResult ShowDialog(OrderContent orderContent, OrderProgress orderProgress);
    }
}
