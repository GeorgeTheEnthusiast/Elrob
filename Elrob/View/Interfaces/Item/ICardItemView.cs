using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface ICardItemView
    {
        DialogResult ShowDialog();

        Card Card { get; }

        Card PassedCard { get; set; }

        TextBox TextBoxLogin { get; }

        TextBox TextBoxPassword { get; }

        TextBox TextBoxName { get; }

        bool IsInEditMode { get; set; }

        DialogResult DialogResult { get; set; }
    }
}
