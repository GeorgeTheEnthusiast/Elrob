using System;
using System.Collections.Generic;
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

        public void UpdateUser(User user)
        {
            _userItemModel.UpdateUser(user);
        }

        public void AddUser(User user)
        {
            _userItemModel.AddUser(user);
        }

        public DialogResult ShowDialog(User user)
        {
            return _userItemView.ShowDialog(user);
        }

        public bool IsUserExist(string loginName)
        {
            return _userItemModel.IsUserExist(loginName);
        }

        public List<Group> GetAllGroups()
        {
            return _userItemModel.GetAllGroups();
        }
    }
}
