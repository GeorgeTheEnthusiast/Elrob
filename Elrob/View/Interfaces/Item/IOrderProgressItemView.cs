using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderProgressItemView
    {
        DialogResult ShowDialog();

        OrderProgress OrderProgress { get; }

        OrderProgress PassedOrderProgress { get; set; }

        OrderContent PassedOrderContent { get; set; }

        bool IsInEditMode { get; set; }

        NumericUpDown NumericUpDownCompleted { get; }

        DateTimePicker DateTimePickerTimeSpend { get; }

        DialogResult DialogResult { get; set; }
    }
}
