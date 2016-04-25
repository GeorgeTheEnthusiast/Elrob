using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderItemView
    {
        Order Order { get; }

        DialogResult ShowDialog();

        Order PassedOrder { get; set; }

        TextBox TextBoxName { get; }

        DateTimePicker DateTimePickerStartDate { get; }

        ErrorProvider NameErrorProvider { get; }

        bool IsInEditMode { get; set; }

        DialogResult DialogResult { get; set; }
    }
}
