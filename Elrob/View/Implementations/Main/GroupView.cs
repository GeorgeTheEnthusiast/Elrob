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
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class GroupView : Form, IGroupView
    {
        private readonly IGroupPresenter _groupPresenter;

        public CustomBindingList<Group> Groups { get; set; }

        public DataGridView DataGridViewGroups => dataGridViewGroups;

        public Button ButtonEdit => buttonEdit;

        public Button ButtonAdd => buttonAdd;

        public Button ButtonDelete => buttonDelete;

        public Button ButtonPermissionGroup => buttonPermissionGroup;

        public GroupView()
        {
            _groupPresenter = new GroupPresenter(this, Program.Kernel.Get<IGroupModel>());

            InitializeComponent();

            dataGridViewGroups.AutoGenerateColumns = false;
            dataGridViewGroups.DataSource = Groups = new CustomBindingList<Group>();
            Icon = Resources.purchase_order;

            _groupPresenter.SetPermissions();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _groupPresenter.ShowGroupAddForm();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _groupPresenter.ShowGroupEditForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _groupPresenter.DeleteGroup();
        }

        private void buttonPermissionGroup_Click(object sender, EventArgs e)
        {
            _groupPresenter.ShowPermissionGroupForm();
        }

        private void dataGridViewGroups_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewGroups, e.ColumnIndex);
        }
    }
}
