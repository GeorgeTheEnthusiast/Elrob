using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IOrderContentView
    {
        DialogResult ShowDialog(Order order, Place place);

        CustomBindingList<OrderContent> OrderContents { get; set; }

        Order Order { get; set; }

        Place Place { get; set; }
    }
}
