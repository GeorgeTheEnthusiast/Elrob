using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Choose
{
    public interface IOrderContentChoosePresenter
    {
        OrderContent ChoosedOrderContent { get; }

        DialogResult ShowDialog(Order order, Place place);
    }
}
