using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderContentItemView
    {
        DialogResult ShowDialog(Order order, OrderContent orderContent, Place place);

        OrderContent OrderContent { get; }

        ComboBox ComboBoxPlace { get; }
    }
}
