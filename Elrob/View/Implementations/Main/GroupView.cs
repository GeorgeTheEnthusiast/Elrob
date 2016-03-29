using System;
using System.ComponentModel;
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
    public partial class GroupView : Form, IGroupView
    {
        private readonly IGroupPresenter _groupPresenter;
        private IGroupItemPresenter _groupItemPresenter;
        private IPermissionGroupPresenter _permissionGroupPresenter;

        public GroupView()
        {
            _groupPresenter = new GroupPresenter(this, Program.Kernel.Get<IGroupModel>());

            InitializeComponent();

            dataGridViewGroups.AutoGenerateColumns = false;
            dataGridViewGroups.DataSource = Groups = new CustomBindingList<Group>();

            buttonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_EditRows);
            buttonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_AddRows);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_DeleteRows);
            buttonPermissionGroup.Enabled = UserFactory.Instance.HasPermission(PermissionType.PermissionGroupView_View);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _groupItemPresenter = Program.Kernel.Get<IGroupItemPresenter>();
            _groupItemPresenter.ShowDialog(null);
            _groupPresenter.RefreshData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Group>(dataGridViewGroups);

            if (selectedRow == default(Group))
            {
                return;
            }

            _groupItemPresenter = Program.Kernel.Get<IGroupItemPresenter>();
            _groupItemPresenter.ShowDialog(selectedRow);
            _groupPresenter.RefreshData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Group>(dataGridViewGroups);

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
                bool result = _groupPresenter.DeleteGroup(selectedRow);

                if (result)
                {
                    _groupPresenter.RefreshData();
                }
                else
                {
                    MessageBox.Show("Ta grupa posiada użytkowników. Usuń ich i spróbuj ponownie.");
                }
            }
        }

        public CustomBindingList<Group> Groups { get; set; }

        public DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        private void buttonPermissionGroup_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Group>(dataGridViewGroups);

            if (selectedRow == default(Group))
            {
                return;
            }

            _permissionGroupPresenter = Program.Kernel.Get<IPermissionGroupPresenter>();
            _permissionGroupPresenter.ShowDialog(selectedRow);
        }

        private void dataGridViewGroups_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewGroups, e.ColumnIndex);
        }
    }
}
