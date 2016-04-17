using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class UserItemPresenter : IUserItemPresenter
    {
        private readonly IUserItemView _userItemView;
        private readonly IUserItemModel _userItemModel;

        public UserItemPresenter(IUserItemView userItemView, IUserItemModel userItemModel)
        {
            if (userItemView == null) throw new ArgumentNullException("userItemView");
            if (userItemModel == null) throw new ArgumentNullException("userItemModel");

            _userItemView = userItemView;
            _userItemModel = userItemModel;
        }

        public DialogResult ShowDialog(User user)
        {
            _userItemView.PassedUser = user;

            var groups = _userItemModel.GetAllGroups();
            _userItemView.ComboBoxGroup.DataSource = groups;

            _userItemView.LoginNameErrorProvider.Clear();
            _userItemView.PasswordErrorProvider.Clear();

            if (_userItemView.PassedUser != null)
            {
                _userItemView.IsInEditMode = true;

                _userItemView.ComboBoxGroup.SelectedIndex = groups.IndexOf(groups.FirstOrDefault(x => x.Id == user.Group.Id));

                _userItemView.TextBoxLogin.Text = _userItemView.PassedUser.LoginName;
                _userItemView.TextBoxFirstName.Text = _userItemView.PassedUser.FirstName;
                _userItemView.TextBoxLastName.Text = _userItemView.PassedUser.LastName;
                _userItemView.TextBoxPassword.Text = _userItemView.PassedUser.Password;
                _userItemView.TextBoxRepeatPassword.Text = _userItemView.PassedUser.Password;
            }
            else
            {
                _userItemView.IsInEditMode = false;
            }
            
            return _userItemView.ShowDialog();
        }

        public void AcceptChanges()
        {
            if (!_userItemView.IsInEditMode || _userItemView.PassedUser.LoginName != _userItemView.User.LoginName)
            {
                var userExist = _userItemModel.IsUserExist(_userItemView.User.LoginName);

                if (userExist)
                {
                    _userItemView.LoginNameErrorProvider.SetError(_userItemView.TextBoxLogin, "Użytkownik o takim loginie już istnieje!");
                    return;
                }
                else
                {
                    _userItemView.LoginNameErrorProvider.Clear();
                }
            }

            if (_userItemView.TextBoxPassword.Text != _userItemView.TextBoxRepeatPassword.Text)
            {
                _userItemView.PasswordErrorProvider.SetError(_userItemView.TextBoxPassword, "Wpisane hasła nie są zgodne!");
                _userItemView.PasswordErrorProvider.SetError(_userItemView.TextBoxRepeatPassword, "Wpisane hasła nie są zgodne!");
                return;
            }
            else
            {
                _userItemView.PasswordErrorProvider.Clear();
            }

            if (_userItemView.IsInEditMode)
            {
                _userItemModel.UpdateUser(_userItemView.User);
            }
            else
            {
                _userItemModel.AddUser(_userItemView.User);
            }

            _userItemView.DialogResult = DialogResult.OK;
        }
    }
}
