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
    public class PermissionGroupItemPresenter : IPermissionGroupItemPresenter
    {
        private readonly IPermissionGroupItemView _permissionGroupItemView;
        private readonly IPermissionGroupItemModel _permissionGroupItemModel;

        public PermissionGroupItemPresenter(IPermissionGroupItemView permissionGroupItemView, IPermissionGroupItemModel permissionGroupItemModel)
        {
            if (permissionGroupItemView == null) throw new ArgumentNullException("permissionGroupItemView");
            if (permissionGroupItemModel == null) throw new ArgumentNullException("permissionGroupItemModel");

            _permissionGroupItemView = permissionGroupItemView;
            _permissionGroupItemModel = permissionGroupItemModel;
        }
        
        public void MergePermissionGroup()
        {
            var checkedItems = _permissionGroupItemView.CheckedListBoxPermissions.CheckedItems.Cast<Permission>().ToList();

            _permissionGroupItemModel.MergePermissionGroup(_permissionGroupItemView.Group, checkedItems);
        }

        public DialogResult ShowDialog(Group group, List<PermissionGroup> permissionGroups)
        {
            _permissionGroupItemView.Group = group;
            _permissionGroupItemView.Permissions.Clear();
            var items = _permissionGroupItemModel.GetAllPermissions();

            foreach (var item in items)
            {
                _permissionGroupItemView.Permissions.Add(item);
            }

            for (int i = 0; i < _permissionGroupItemView.Permissions.Count; i++)
            {
                bool existInGroup = permissionGroups.Any(x => x.Permission.Id == _permissionGroupItemView.Permissions[i].Id);
                _permissionGroupItemView.CheckedListBoxPermissions.SetItemChecked(i, existInGroup);
            }

            return _permissionGroupItemView.ShowDialog();
        }
    }
}
