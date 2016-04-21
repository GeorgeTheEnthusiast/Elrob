using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class PermissionGroupItemView : Form, IPermissionGroupItemView
    {
        private readonly IPermissionGroupItemPresenter _permissionGroupItemPresenter;
        
        public PermissionGroupItemView()
        {
            _permissionGroupItemPresenter = new PermissionGroupItemPresenter(this, Program.Kernel.Get<IPermissionGroupItemModel>());
            
            InitializeComponent();

            checkedListBoxPermissions.DataSource = Permissions = new BindingList<Permission>();
            Icon = Resources.purchase_order;
        }

        public BindingList<Permission> Permissions { get; set; }

        public CheckedListBox CheckedListBoxPermissions => checkedListBoxPermissions;

        public Group Group { get; set; }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _permissionGroupItemPresenter.MergePermissionGroup();

            DialogResult = DialogResult.OK;
        }
    }
}
