using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PermissionGroupPresenter : IPermissionGroupPresenter
    {
        private readonly IPermissionGroupView _permissionGroupView;
        private readonly IPermissionGroupModel _permissionGroupModel;
        private IPermissionGroupItemPresenter _permissionGroupItemPresenter;

        public PermissionGroupPresenter(IPermissionGroupView permissionGroupView, IPermissionGroupModel permissionGroupModel)
        {
            if (permissionGroupView == null) throw new ArgumentNullException("permissionGroupView");
            if (permissionGroupModel == null) throw new ArgumentNullException("permissionGroupModel");

            _permissionGroupView = permissionGroupView;
            _permissionGroupModel = permissionGroupModel;
        }

        public DialogResult ShowDialog(Group group)
        {
            RefreshData(group);

            _permissionGroupView.Group = group;
            _permissionGroupView.TextBoxGroup.Text = group.Name;
            
            return _permissionGroupView.ShowDialog();
        }

        public void RefreshData(Group group)
        {
            _permissionGroupView.PermissionGroups.Clear();
            var items = _permissionGroupModel.GetPermissionGroupsByGroupId(group.Id);
            foreach (var item in items)
            {
                _permissionGroupView.PermissionGroups.Add(item);
            }
        }

        public void SetPermissions()
        {
            _permissionGroupView.ButtonChange.Enabled = UserFactory.Instance.HasPermission(PermissionType.PermissionGroupView_ChangePermissions);
            _permissionGroupView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.PermissionGroupView_DeletePermission);
        }

        public void ShowChangeForm()
        {
            _permissionGroupItemPresenter = Program.Kernel.Get<IPermissionGroupItemPresenter>();
            var dialogResult = _permissionGroupItemPresenter.ShowDialog(_permissionGroupView.Group, _permissionGroupView.PermissionGroups.ToList());

            if (dialogResult == DialogResult.OK)
            {
                RefreshData(_permissionGroupView.Group);
            }
        }

        public void DeletePermissionGroup()
        {
            var selectedRow = Helpers.GetSelectedRow<PermissionGroup>(_permissionGroupView.DataGridViewPermissionGroups);

            if (selectedRow == default(PermissionGroup))
            {
                return;
            }

            if (MessageBox.Show(
                "Czy aby napewno chcesz usunąć to uprawnienie?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _permissionGroupModel.DeletePermissionGroup(selectedRow);
                RefreshData(_permissionGroupView.Group);
            }
        }
    }
}
