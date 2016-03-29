using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderProgressItemView
    {
        DialogResult ShowDialog(OrderContent orderContent, OrderProgress OrderProgress);

        OrderProgress OrderProgress { get; }
    }
}
