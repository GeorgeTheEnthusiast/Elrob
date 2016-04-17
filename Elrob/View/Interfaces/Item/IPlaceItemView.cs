using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IPlaceItemView
    {
        DialogResult ShowDialog();

        Place Place { get; }

        bool IsInEditMode { get; set; }

        Place PassedPlace { get; set; }

        TextBox TextBoxName { get; }

        ErrorProvider NameErrorProvider { get; }

        DialogResult DialogResult { get; set; }
    }
}
