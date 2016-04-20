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

        public UserView()
        {
            _userPresenter = new UserPresenter(this, Program.Kernel.Get<IUserModel>());

            InitializeComponent();

            dataGridViewUsers.AutoGenerateColumns = false;
            dataGridViewUsers.DataSource = Users = new CustomBindingList<User>();

            _userPresenter.SetPermissions();
        }

        public CustomBindingList<User> Users { get; set; }

        public DataGridView DataGridViewUsers => dataGridViewUsers;

        public Button ButtonEdit => buttonEdit;

        public Button ButtonAdd => buttonAdd;

        public Button ButtonDelete => buttonDelete;

        public Button ButtonCards => buttonCards;

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _userPresenter.ShowAddForm();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _userPresenter.ShowEditForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _userPresenter.DeleteUser();
        }
        
        private void dataGridViewUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewUsers, e.ColumnIndex);
        }

        private void buttonCards_Click(object sender, EventArgs e)
        {
            _userPresenter.ShowCardForm();
        }
    }
}
