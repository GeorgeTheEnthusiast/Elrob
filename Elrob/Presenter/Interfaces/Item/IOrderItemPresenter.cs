using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IOrderItemPresenter
    {
        void UpdateOrder(Order order);

        void AddOrder(Order order);

        DialogResult ShowDialog(Order order);

        bool IsOrderExist(string orderName);

        void AcceptChanges();
    }
}
