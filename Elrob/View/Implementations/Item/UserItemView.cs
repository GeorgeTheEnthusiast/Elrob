using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class UserItemView : Form, IUserItemView
    {
        private readonly IUserItemPresenter _userItemPresenter;

        private bool _isInEditMode;

        private User _user;

        public UserItemView()
        {
            _userItemPresenter = new UserItemPresenter(this, Program.Kernel.Get<IUserItemModel>());
            
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            if (!_isInEditMode || _user.LoginName != User.LoginName)
            {
                var userExist = _userItemPresenter.IsUserExist(User.LoginName);

                if (userExist)
                {
                    loginNameErrorProvider.SetError(textBoxLogin, "Użytkownik o takim loginie już istnieje!");
                    return;
                }
                else
                {
                    loginNameErrorProvider.Clear();
                }
            }
                
            if (textBoxPassword.Text != textBoxRepeatPassword.Text)
            {
                passwordErrorProvider.SetError(textBoxPassword, "Wpisane hasła nie są zgodne!");
                passwordErrorProvider.SetError(textBoxRepeatPassword, "Wpisane hasła nie są zgodne!");
                return;
            }
            else
            {
                passwordErrorProvider.Clear();
            }

            if (_isInEditMode)
            {
                _userItemPresenter.UpdateUser(User);
            }
            else
            {
                _userItemPresenter.AddUser(User);
            }

            DialogResult = DialogResult.OK;
        }

        public DialogResult ShowDialog(User user)
        {
            _user = user;

            var groups = _userItemPresenter.GetAllGroups();
            comboBoxGroup.DataSource = groups;

            loginNameErrorProvider.Clear();
            passwordErrorProvider.Clear();

            if (_user != null)
            {
                _isInEditMode = true;

                comboBoxGroup.SelectedIndex = groups.IndexOf(groups.FirstOrDefault(x => x.Id == user.Group.Id));

                textBoxLogin.Text = _user.LoginName;
                textBoxFirstName.Text = _user.FirstName;
                textBoxLastName.Text = _user.LastName;
                textBoxPassword.Text = _user.Password;
                textBoxRepeatPassword.Text = _user.Password;
            }
            else
            {
                _isInEditMode = false;
            }

            return base.ShowDialog();
        }

        public User User => new User()
        {
            Id = _user?.Id ?? 0,
            LoginName = textBoxLogin.Text.Trim(),
            FirstName = textBoxFirstName.Text.Trim(),
            LastName = textBoxLastName.Text.Trim(),
            Password = textBoxPassword.Text.Trim(),
            Group = comboBoxGroup.SelectedItem as Group
        };
    }
}
