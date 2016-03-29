using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class PermissionGroupPresenter : IPermissionGroupPresenter
    {
        private readonly IPermissionGroupView _permissionGroupView;
        private readonly IPermissionGroupModel _permissionGroupModel;

        public PermissionGroupPresenter(IPermissionGroupView permissionGroupView, IPermissionGroupModel permissionGroupModel)
        {
            if (permissionGroupView == null) throw new ArgumentNullException("permissionGroupView");
            if (permissionGroupModel == null) throw new ArgumentNullException("permissionGroupModel");

            _permissionGroupView = permissionGroupView;
            _permissionGroupModel = permissionGroupModel;
        }

        public List<PermissionGroup> GetPermissionGroupsByGroupId(int groupId)
        {
            return _permissionGroupModel.GetPermissionGroupsByGroupId(groupId);
        }

        public void DeletePermissionGroup(PermissionGroup permissionGroup)
        {
            _permissionGroupModel.DeletePermissionGroup(permissionGroup);
        }

        public DialogResult ShowDialog(Group group)
        {
            RefreshData(group);

            return _permissionGroupView.ShowDialog(group);
        }

        public void RefreshData(Group group)
        {
            _permissionGroupView.PermissionGroups.Clear();
            var items = GetPermissionGroupsByGroupId(group.Id);
            foreach (var item in items)
            {
                _permissionGroupView.PermissionGroups.Add(item);
            }
        }
    }
}
