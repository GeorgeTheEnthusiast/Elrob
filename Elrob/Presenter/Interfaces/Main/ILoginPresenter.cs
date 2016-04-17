using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface ILoginPresenter
    {
        bool CanLogIn();

        DialogResult ShowDialog();
    }
}
