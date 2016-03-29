using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IOrderView
    {
        DialogResult ShowDialog(Place place);

        CustomBindingList<Order> Orders { get; set; }

        Place Place { get; set; }
    }
}
