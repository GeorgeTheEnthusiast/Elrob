using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IUserItemView
    {
        DialogResult ShowDialog();

        User User { get; }

        bool IsInEditMode { get; set; }

        User PassedUser { get; set; }

        ErrorProvider LoginNameErrorProvider { get; }

        ErrorProvider PasswordErrorProvider { get; }

        ErrorProvider CardErrorProvider { get; }

        ComboBox ComboBoxGroup { get; }

        ComboBox ComboBoxCard { get; }

        TextBox TextBoxLogin { get; }

        TextBox TextBoxFirstName { get; }

        TextBox TextBoxLastName { get; }

        TextBox TextBoxPassword { get; }

        TextBox TextBoxRepeatPassword { get; }

        DialogResult DialogResult { get; set; }
    }
}
