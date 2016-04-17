using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderContentItemView
    {
        DialogResult ShowDialog();

        OrderContent OrderContent { get; }

        ComboBox ComboBoxPlace { get; }

        ComboBox ComboBoxMaterial { get; }

        TextBox TextBoxName { get; }

        TextBox TextBoxDocumentNumber { get; }

        NumericUpDown NumericUpDownHeight { get; }

        NumericUpDown NumericUpDownWidth { get; }

        NumericUpDown NumericUpDownPackageQuantity { get; }

        NumericUpDown NumericUpDownThickness { get; }

        NumericUpDown NumericUpDownToComplete { get; }

        NumericUpDown NumericUpDownUnitWeight { get; }

        Order PassedOrder { get; set; }

        OrderContent PassedOrderContent { get; set; }
    }
}
