using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface ILoginView
    {
        bool IsLoggedIn { get; }

        User User { get; }

        DialogResult ShowDialog();
    }
}
