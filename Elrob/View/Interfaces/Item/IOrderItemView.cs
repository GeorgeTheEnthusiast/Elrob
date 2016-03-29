using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderItemView
    {
        Order Order { get; }

        DialogResult ShowDialog(Order order);
    }
}
