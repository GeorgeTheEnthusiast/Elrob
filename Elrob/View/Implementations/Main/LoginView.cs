using System;
using System.Diagnostics;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Main;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class LoginView : Form, ILoginView
    {
        private readonly ILoginPresenter _loginPresenter;

        public LoginView()
        {
            _loginPresenter = new LoginPresenter(this, Program.Kernel.Get<ILoginModel>());
            
            InitializeComponent();
        }
        
        public User User => new User()
        {
            LoginName = textBoxUser.Text.Trim(),
            Password = textBoxPassword.Text
        };

        public TextBox TextBoxLogin => textBoxUser;

        public TextBox TextBoxPassword => textBoxPassword;

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonLogin_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
