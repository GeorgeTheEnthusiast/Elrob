using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IOrderView
    {
        DialogResult ShowDialog();

        CustomBindingList<Order> Orders { get; set; }

        Place Place { get; set; }

        Button ButtonAdd { get; }

        Button ButtonEdit { get; }

        Button ButtonDelete { get; }

        DataGridView DataGridViewOrders { get; }

        TextBox TextBoxPlace { get; }
    }
}
