using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using FluentNHibernate.Utils;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class UserItemPresenter : IUserItemPresenter
    {
        private readonly IUserItemView _userItemView;
        private readonly IUserItemModel _userItemModel;
        private const string cardEmptyName = "Brak";

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
            var cards = _userItemModel.GetAllCards();
            cards.Insert(0, new Card()
            {
                Id = -1,
                Name = cardEmptyName
            });
            _userItemView.ComboBoxGroup.DataSource = groups;
            _userItemView.ComboBoxCard.DataSource = cards;

            _userItemView.LoginNameErrorProvider.Clear();
            _userItemView.PasswordErrorProvider.Clear();
            _userItemView.CardErrorProvider.Clear();

            if (_userItemView.PassedUser != null)
            {
                _userItemView.IsInEditMode = true;

                _userItemView.ComboBoxGroup.SelectedIndex = groups.IndexOf(groups.FirstOrDefault(x => x.Id == user.Group.Id));

                if (user.Card != null)
                {
                    _userItemView.ComboBoxCard.SelectedIndex = cards.IndexOf(cards.FirstOrDefault(x => x != null && x.Id == user.Card.Id));
                }
                else
                {
                    _userItemView.ComboBoxCard.SelectedIndex = 0;
                }

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

            User user = _userItemView.User;

            if (user.Card != null && user.Card.Id == -1)
            {
                user.Card = null;
            }
            else
            {
                var isCardIsUnique = _userItemModel.IsCardIsUnique(_userItemView.User.Card.Id, _userItemView.User.Id);

                if (isCardIsUnique == false)
                {
                    _userItemView.CardErrorProvider.SetError(_userItemView.ComboBoxCard, "Ta karta została już przypisana do innego użytkownika!");
                    return;
                }
                else
                {
                    _userItemView.CardErrorProvider.Clear();
                }
            }
            
            if (_userItemView.IsInEditMode)
            {
                _userItemModel.UpdateUser(user);
            }
            else
            {
                _userItemModel.AddUser(user);
            }

            _userItemView.DialogResult = DialogResult.OK;
        }
    }
}
