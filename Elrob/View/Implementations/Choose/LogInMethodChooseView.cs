using System;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Choose;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Choose;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Choose
{
    public partial class LogInMethodChooseView : Form, ILogInMethodChooseView
    {
        private readonly ILogInMethodChoosePresenter _logInMethodChoosePresenter;

        public LogInMethodChooseView()
        {
            InitializeComponent();

            _logInMethodChoosePresenter = new LogInMethodChoosePresenter(this, Program.Kernel.Get<ILogInMethodChooseModel>());
        }

        public bool Visible { get { return base.Visible; } set { base.Visible = value; } }

        private void buttonLoginAndPassword_Click(object sender, EventArgs e)
        {
            _logInMethodChoosePresenter.ShowAuthenticationForm(LogInMethod.LoginAndPassword);
        }

        private void buttonCard_Click(object sender, EventArgs e)
        {
            _logInMethodChoosePresenter.ShowAuthenticationForm(LogInMethod.Card);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
