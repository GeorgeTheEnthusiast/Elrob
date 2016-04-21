using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Choose
{
    public interface ILogInMethodChoosePresenter
    {
        DialogResult ShowDialog();

        void ShowAuthenticationForm(LogInMethod logInMethod);
    }
}
