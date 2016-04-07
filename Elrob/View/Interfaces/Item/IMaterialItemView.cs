using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IMaterialItemView
    {
        DialogResult ShowDialog();

        Material Material { get; }

        Material PassedMaterial { get; set; }

        ErrorProvider ErrorProviderName { get; }

        TextBox TextBoxName { get; }

        bool IsInEditMode { get; set; }

        DialogResult DialogResult { get; set; }
    }
}
