using System;
using System.Reflection;
using System.Windows.Forms;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View;
using Elrob.Terminal.View.Interfaces;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;
using NLog;

namespace Elrob.Terminal
{
    static class Program
    {
        public static StandardKernel Kernel;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        static void Main()
        {
            try
            {
                Kernel = new StandardKernel();
                Kernel.Load(Assembly.GetExecutingAssembly());

                ILoginView loginView = Kernel.Get<ILoginView>();
                DialogResult loginViewDialogResult = loginView.ShowDialog();

                while (loginViewDialogResult == DialogResult.OK)
                {
                    if (loginView.IsLoggedIn)
                    {
                        IMainPresenter mainPresenter = Kernel.Get<IMainPresenter>();
                        mainPresenter.ShowDialog();
                    }

                    loginViewDialogResult = loginView.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show("Wystąpił błąd programu. Skontaktuj się z administratorem systemu.");
            }
           
        }
    }
}
