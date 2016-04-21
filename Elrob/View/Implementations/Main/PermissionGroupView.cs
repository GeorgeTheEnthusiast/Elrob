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
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class PermissionGroupView : Form, IPermissionGroupView
    {
        private readonly IPermissionGroupPresenter _permissionGroupPresenter;

        public PermissionGroupView()
        {
            _permissionGroupPresenter = new PermissionGroupPresenter(this, Program.Kernel.Get<IPermissionGroupModel>());
            
            InitializeComponent();

            dataGridViewPermissionGroups.AutoGenerateColumns = false;
            dataGridViewPermissionGroups.DataSource = PermissionGroups = new CustomBindingList<PermissionGroup>();
            Icon = Resources.purchase_order;

            _permissionGroupPresenter.SetPermissions();
        }

        public Group Group { get; set; }

        public Button ButtonChange => buttonChange;

        public Button ButtonDelete => buttonDelete;

        public TextBox TextBoxGroup => textBoxGroup;

        public DataGridView DataGridViewPermissionGroups => dataGridViewPermissionGroups;

        public CustomBindingList<PermissionGroup> PermissionGroups { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            _permissionGroupPresenter.ShowChangeForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _permissionGroupPresenter.DeletePermissionGroup();
        }
        
        private void dataGridViewPermissionGroups_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewPermissionGroups, e.ColumnIndex);
        }
    }
}
