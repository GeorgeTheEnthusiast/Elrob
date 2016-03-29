using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Main;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class PermissionGroupView : Form, IPermissionGroupView
    {
        private readonly IPermissionGroupPresenter _permissionGroupPresenter;
        private IPermissionGroupItemPresenter _permissionGroupItemPresenter;

        public PermissionGroupView()
        {
            _permissionGroupPresenter = new PermissionGroupPresenter(this, Program.Kernel.Get<IPermissionGroupModel>());
            
            InitializeComponent();

            dataGridViewPermissionGroups.AutoGenerateColumns = false;
            dataGridViewPermissionGroups.DataSource = PermissionGroups = new CustomBindingList<PermissionGroup>();
            
            buttonChange.Enabled = UserFactory.Instance.HasPermission(PermissionType.PermissionGroupView_ChangePermissions);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.PermissionGroupView_DeletePermission);
        }

        public Group Group { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            _permissionGroupItemPresenter = Program.Kernel.Get<IPermissionGroupItemPresenter>();
            _permissionGroupItemPresenter.ShowDialog(Group, PermissionGroups.ToList());
            _permissionGroupPresenter.RefreshData(Group);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<PermissionGroup>(dataGridViewPermissionGroups);

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
                _permissionGroupPresenter.DeletePermissionGroup(selectedRow);
                _permissionGroupPresenter.RefreshData(Group);
            }
        }

        public DialogResult ShowDialog(Group group)
        {
            Group = group;
            textBoxGroup.Text = Group.Name;

            return base.ShowDialog();
        }

        public CustomBindingList<PermissionGroup> PermissionGroups { get; set; }

        private void dataGridViewPermissionGroups_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewPermissionGroups, e.ColumnIndex);
        }
    }
}
