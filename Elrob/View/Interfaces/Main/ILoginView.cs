using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface ILoginView
    {
        User User { get; }

        DialogResult ShowDialog();

        TextBox TextBoxLogin { get; }

        TextBox TextBoxPassword { get; }
    }
}
