using System;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class LoginPresenter : ILoginPresenter
    {
        private readonly ILoginModel _loginModel;
        private readonly ILoginView _loginView;

        public LoginPresenter(ILoginView loginView, ILoginModel loginModel)
        {
            if (loginView == null) throw new ArgumentNullException("loginView");
            if (loginModel == null) throw new ArgumentNullException("loginModel");
            
            _loginView = loginView;
            _loginModel = loginModel;
        }

        public bool CanLogIn()
        {
            var user = _loginModel.GetUserByLoginName(_loginView.User.LoginName); ;

            if (user == null
                || user.Password != _loginView.User.Password)
            {
                MessageBox.Show("Błędna nazwa użytkownika, bądź hasła!");
                return false;
            }

            UserFactory.Instance.SetUser(user);

            return true;
        }
        
        public DialogResult ShowDialog()
        {
            _loginView.TextBoxLogin.Text = "";
            _loginView.TextBoxPassword.Text = "";

            return _loginView.ShowDialog();
        }
    }
}
