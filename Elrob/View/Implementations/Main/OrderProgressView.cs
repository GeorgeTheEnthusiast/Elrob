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
    public partial class OrderProgressView : Form, IOrderProgressView
    {
        private readonly IOrderProgressPresenter _orderProgressPresenter;
        private IOrderProgressItemPresenter _orderProgressItemPresenter;

        public OrderProgressView()
        {
            _orderProgressPresenter = new OrderProgressPresenter(this, Program.Kernel.Get<IOrderProgressModel>());

            InitializeComponent();

            dataGridViewOrderProgress.AutoGenerateColumns = false;
            dataGridViewOrderProgress.DataSource = OrderProgresses = new CustomBindingList<OrderProgress>();

            buttonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_EditRows);
            buttonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_AddRows);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_DeleteRows);
            UserColumn.Visible = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_SeeWhoAddRows);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderProgressItemPresenter = Program.Kernel.Get<IOrderProgressItemPresenter>();
            _orderProgressItemPresenter.ShowDialog(OrderContent, null);
            _orderProgressPresenter.RefreshData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<OrderProgress>(dataGridViewOrderProgress);

            if (selectedRow == default(OrderProgress))
            {
                return;
            }

            _orderProgressItemPresenter = Program.Kernel.Get<IOrderProgressItemPresenter>();
            _orderProgressItemPresenter.ShowDialog(OrderContent, selectedRow);
            _orderProgressPresenter.RefreshData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<OrderProgress>(dataGridViewOrderProgress);

            if (selectedRow == default(OrderProgress))
            {
                return;
            }

            if (MessageBox.Show(
                "Czy aby napewno chcesz usunąć ten wpis?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _orderProgressPresenter.DeleteOrderProgress(selectedRow);
                _orderProgressPresenter.RefreshData();
            }
        }

        public DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        public CustomBindingList<OrderProgress> OrderProgresses { get; set; }

        public OrderContent OrderContent { get; set; }

        public TextBox TextBoxOrderContent => textBoxOrderContent;

        public TextBox TextBoxOrder => textBoxOrder;

        public TextBox TextBoxDocumentNumber => textBoxDocumentNumber;

        public TextBox TextBoxToComplete => textBoxToComplete;

        public TextBox TextBoxCompletedSum => _textBoxCompletedSum;

        private void dataGridViewOrderProgress_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewOrderProgress, e.ColumnIndex);
        }

        private void textBoxOrder_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }

        private void textBoxOrderContent_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }

        private void textBoxDocumentNumber_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }
    }
}
