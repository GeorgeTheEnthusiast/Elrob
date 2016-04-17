using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderPreviewItemView
    {
        DialogResult ShowDialog();

        OrderContent OrderContent { get; }

        ComboBox ComboBoxPlace { get; }

        OrderContent PassedOrderContent { get; set; }

        Order PassedOrder { get; set; }

        ComboBox ComboBoxMaterial { get; }

        TextBox TextBoxName { get; }

        TextBox TextBoxDocumentNumber { get; }

        NumericUpDown NumericUpDownHeight { get; }

        NumericUpDown NumericUpDownWidth { get; }

        NumericUpDown NumericUpDownPackageQuantity { get; }

        NumericUpDown NumericUpDownThickness { get; }

        NumericUpDown NumericUpDownToComplete { get; }

        NumericUpDown NumericUpDownUnitWeight { get; }
    }
}
