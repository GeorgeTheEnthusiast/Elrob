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
    public class GroupPresenter : IGroupPresenter
    {
        private readonly IGroupView _groupView;
        private readonly IGroupModel _groupModel;
        private IGroupItemPresenter _groupItemPresenter;
        private IPermissionGroupPresenter _permissionGroupPresenter;

        public GroupPresenter(IGroupView groupView, IGroupModel groupModel)
        {
            if (groupView == null) throw new ArgumentNullException("groupView");
            if (groupModel == null) throw new ArgumentNullException("groupModel");

            _groupView = groupView;
            _groupModel = groupModel;
        }

        public void ShowDialog()
        {
            RefreshData();

            _groupView.ShowDialog();
        }

        public void RefreshData()
        {
            _groupView.Groups.Clear();
            var groups = _groupModel.GetAllGroups();
            foreach (var group in groups)
            {
                _groupView.Groups.Add(group);
            }
        }

        public void ShowGroupEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<Group>(_groupView.DataGridViewGroups);

            if (selectedRow == default(Group))
            {
                return;
            }

            _groupItemPresenter = Program.Kernel.Get<IGroupItemPresenter>();
            var dialogResult = _groupItemPresenter.ShowDialog(selectedRow);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void ShowGroupAddForm()
        {
            _groupItemPresenter = Program.Kernel.Get<IGroupItemPresenter>();
            var dialogResult = _groupItemPresenter.ShowDialog(null);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void ShowPermissionGroupForm()
        {
            var selectedRow = Helpers.GetSelectedRow<Group>(_groupView.DataGridViewGroups);

            if (selectedRow == default(Group))
            {
                return;
            }

            _permissionGroupPresenter = Program.Kernel.Get<IPermissionGroupPresenter>();
            _permissionGroupPresenter.ShowDialog(selectedRow);
        }

        public void DeleteGroup()
        {
            var selectedRow = Helpers.GetSelectedRow<Group>(_groupView.DataGridViewGroups);

            if (selectedRow == default(Group))
            {
                return;
            }

            if (MessageBox.Show(
                "Czy aby napewno chcesz usunąć tą grupę?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                bool result = _groupModel.DeleteGroup(selectedRow);

                if (result)
                {
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Ta grupa posiada użytkowników. Usuń ich i spróbuj ponownie.");
                }
            }
        }

        public void SetPermissions()
        {
            _groupView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_EditRows);
            _groupView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_AddRows);
            _groupView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_DeleteRows);
            _groupView.ButtonPermissionGroup.Enabled = UserFactory.Instance.HasPermission(PermissionType.PermissionGroupView_View);
        }
    }
}
