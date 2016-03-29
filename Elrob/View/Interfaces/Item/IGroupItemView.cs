using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IGroupItemView
    {
        DialogResult ShowDialog();

        Group FilledGroup { get; }

        ErrorProvider ErrorProviderName { get; }

        TextBox TextBoxName { get; }

        bool IsInEditMode { get; set; }

        Group PassedGroup { get; set; }

        DialogResult DialogResult { get; set; }
    }
}
