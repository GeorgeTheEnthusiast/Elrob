using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class UserPresenter : IUserPresenter
    {
        private readonly IUserView _userView;
        private readonly IUserModel _userModel;
        private IUserItemPresenter _userItemPresenter;
        private ICardPresenter _cardPresenter;

        public UserPresenter(IUserView userView, IUserModel userModel)
        {
            if (userView == null) throw new ArgumentNullException("userView");
            if (userModel == null) throw new ArgumentNullException("userModel");

            _userView = userView;
            _userModel = userModel;
        }

        public void RefreshData()
        {
            _userView.Users.Clear();
            var items = GetAllUsers();
            foreach (var item in items)
            {
                _userView.Users.Add(item);
            }
        }

        public void ShowAddForm()
        {
            _userItemPresenter = Program.Kernel.Get<IUserItemPresenter>();
            var dialogResult = _userItemPresenter.ShowDialog(null);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<User>(_userView.DataGridViewUsers);

            if (selectedRow == default(User))
            {
                return;
            }

            _userItemPresenter = Program.Kernel.Get<IUserItemPresenter>();
            var dialogResult = _userItemPresenter.ShowDialog(selectedRow);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void DeleteUser()
        {
            var selectedRow = Helpers.GetSelectedRow<User>(_userView.DataGridViewUsers);

            if (selectedRow == default(User))
            {
                return;
            }

            if (MessageBox.Show(
                "Czy aby napewno chcesz usunąć tego użytkownika?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                bool result = _userModel.DeleteUser(selectedRow);

                if (result)
                {
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Użytkownik ten zaraportował już pracę, nie da się go usunąć!");
                }
            }
        }

        public void SetPermissions()
        {
            _userView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_EditRows);
            _userView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_AddRows);
            _userView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_DeleteRows);
            _userView.ButtonCards.Enabled = UserFactory.Instance.HasPermission(PermissionType.CardView_View);
        }

        public void ShowCardForm()
        {
            _cardPresenter = Program.Kernel.Get<ICardPresenter>();
            var dialogResult = _cardPresenter.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public List<User> GetAllUsers()
        {
            return _userModel.GetAllUsers();
        }

        public bool DeleteUser(User user)
        {
            return _userModel.DeleteUser(user);
        }

        public DialogResult ShowDialog()
        {
            RefreshData();

            return _userView.ShowDialog();
        }
    }
}
