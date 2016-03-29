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

        OrderContent OrderContent { get; set; }

        TextBox TextBoxOrderContent { get; }

        TextBox TextBoxOrder { get; }

        TextBox TextBoxDocumentNumber { get; }

        TextBox TextBoxToComplete { get; }

        TextBox TextBoxCompletedSum { get; }
    }
}
