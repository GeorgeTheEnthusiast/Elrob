using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IOrderProgressView
    {
        DialogResult ShowDialog();

        CustomBindingList<OrderProgress> OrderProgresses { get; set; }

        OrderContent OrderContent { get; }

        Place Place { get; set; }

        ComboBox ComboBoxOrderContent { get; }

        ComboBox ComboBoxOrderContentByDocumentNumber { get; }

        TextBox TextBoxOrder { get; }

        TextBox TextBoxToComplete { get; }

        TextBox TextBoxCompletedSum { get; }

        TextBox TextBoxTimeSpendSum { get; }

        Button ButtonEdit { get; }

        Button ButtonAdd { get; }

        Button ButtonDelete { get; }

        DataGridViewTextBoxColumn DataGridViewUserColumn { get; }

        DataGridView DataGridViewOrderProgress { get; }
    }
}
