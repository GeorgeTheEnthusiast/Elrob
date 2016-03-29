using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Choose
{
    public interface IOrderContentChooseView
    {
        OrderContent OrderContent { get; }

        DialogResult ShowDialog();

        ComboBox ComboBoxOrders { get; }
    }
}
