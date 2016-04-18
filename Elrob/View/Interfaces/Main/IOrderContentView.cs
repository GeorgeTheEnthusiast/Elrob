using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IOrderContentView
    {
        DialogResult ShowDialog();

        CustomBindingList<OrderContent> OrderContents { get; set; }

        Order Order { get; set; }

        Place Place { get; set; }

        TextBox TextBoxOrderName { get; }

        TextBox TextBoxPlace { get; }

        DataGridView DataGridViewOrderContent { get; }

        Button ButtonEdit { get; }

        Button ButtonAdd { get; }

        Button ButtonDelete { get; }
    }
}
