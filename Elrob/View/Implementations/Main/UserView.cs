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
    public partial class UserView : Form, IUserView
    {
        private readonly IUserPresenter _userPresenter;
        private IUserItemPresenter _userItemPresenter;

        public UserView()
        {
            _userPresenter = new UserPresenter(this, Program.Kernel.Get<IUserModel>());

            InitializeComponent();

            dataGridViewUsers.AutoGenerateColumns = false;
            dataGridViewUsers.DataSource = Users = new CustomBindingList<User>();

            buttonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_EditRows);
            buttonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_AddRows);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_DeleteRows);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _userItemPresenter = Program.Kernel.Get<IUserItemPresenter>();
            _userItemPresenter.ShowDialog(null);
            _userPresenter.RefreshData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<User>(dataGridViewUsers);

            if (selectedRow == default(User))
            {
                return;
            }

            _userItemPresenter = Program.Kernel.Get<IUserItemPresenter>();
            _userItemPresenter.ShowDialog(selectedRow);
            _userPresenter.RefreshData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<User>(dataGridViewUsers);

            if (selectedRow == default(User))
            {
                return;
            }

            if (MessageBox.Show(
                "Czy aby napewno chcesz usunąć tego użytkownika?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                bool result = _userPresenter.DeleteUser(selectedRow);

                if (result)
                {
                    _userPresenter.RefreshData();
                }
                else
                {
                    MessageBox.Show("Użytkownik ten zaraportował już pracę, nie da się go usunąć!");
                }
            }
        }

        public DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        public CustomBindingList<User> Users { get; set; }

        private void dataGridViewUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewUsers, e.ColumnIndex);
        }
    }
}
