using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Choose;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Choose
{
    public class LogInMethodChoosePresenter : ILogInMethodChoosePresenter
    {
        private readonly ILogInMethodChooseView _logInMethodChooseView;
        private readonly ILogInMethodChooseModel _logInMethodChooseModel;
        private ILoginPresenter _loginPresenter;

        public LogInMethodChoosePresenter(ILogInMethodChooseView logInMethodChooseView, ILogInMethodChooseModel logInMethodChooseModel)
        {
            if (logInMethodChooseView == null) throw new ArgumentNullException("logInMethodChooseView");
            if (logInMethodChooseModel == null) throw new ArgumentNullException("logInMethodChooseModel");

            _logInMethodChooseView = logInMethodChooseView;
            _logInMethodChooseModel = logInMethodChooseModel;
        }

        public DialogResult ShowDialog()
        {
            return _logInMethodChooseView.ShowDialog();
        }

        public void ShowAuthenticationForm(LogInMethod logInMethod)
        {
            _logInMethodChooseView.Visible = false;

            switch (logInMethod)
            {
                case LogInMethod.Card:
                    ICardReaderPresenter cardReaderPresenter = Program.Kernel.Get<ICardReaderPresenter>();

                    DialogResult cardReaderDialogResult = cardReaderPresenter.ShowDialog();

                    while (cardReaderDialogResult == DialogResult.OK)
                    {
                        var user = _logInMethodChooseModel.GetUserByCard(cardReaderPresenter.EnteredCard);

                        if (user != null)
                        {
                            UserFactory.Instance.SetUser(user);
                            IMainPresenter mainPresenter = Program.Kernel.Get<IMainPresenter>();
                            mainPresenter.ShowDialog();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Ta karta nie jest wprowadzona do bazy danych!");
                        }

                        cardReaderDialogResult = cardReaderPresenter.ShowDialog();
                    }
                    break;
                case LogInMethod.LoginAndPassword:
                    ILoginPresenter loginPresenter = Program.Kernel.Get<ILoginPresenter>();

                    DialogResult loginViewDialogResult = loginPresenter.ShowDialog();

                    while (loginViewDialogResult == DialogResult.OK)
                    {
                        if (loginPresenter.CanLogIn())
                        {
                            IMainPresenter mainPresenter = Program.Kernel.Get<IMainPresenter>();
                            mainPresenter.ShowDialog();
                            break;
                        }

                        loginViewDialogResult = loginPresenter.ShowDialog();
                    }
                    break;
            }

            _logInMethodChooseView.Visible = true;
        }
    }
}
