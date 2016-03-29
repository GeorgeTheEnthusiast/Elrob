using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Choose
{
    public interface IOrderChoosePresenter
    {
        Order ChoosedOrder{ get; }

        List<Order> GetAllOrders();

        DialogResult ShowDialog();
    }
}
