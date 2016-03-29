using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class UserPresenter : IUserPresenter
    {
        private readonly IUserView _userView;
        private readonly IUserModel _userModel;

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
