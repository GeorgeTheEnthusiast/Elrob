using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IOrderPreviewView
    {
        DialogResult ShowDialog(OrderPreviewViewModel orderViewModel);

        CustomBindingList<OrderContent> OrderContents { get; set; }

        Order Order { get; set; }
    }
}
