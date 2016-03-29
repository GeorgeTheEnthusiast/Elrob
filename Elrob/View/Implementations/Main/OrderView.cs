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
    public partial class OrderView : Form, IOrderView
    {
        private readonly IOrderPresenter _orderPresenter;
        private IOrderContentPresenter _orderContentPresenter;
        private IOrderItemPresenter _orderItemPresenter;

        public OrderView()
        {
            _orderPresenter = new OrderPresenter(this, Program.Kernel.Get<IOrderModel>());

            InitializeComponent();

            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.DataSource = Orders = new CustomBindingList<Order>();
            
            buttonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_EditRows);
            buttonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_AddRows);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_DeleteRows);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        public CustomBindingList<Order> Orders { get; set; }

        public Place Place { get; set; }

        private void buttonOrderContent_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Order>(dataGridViewOrders);

            if (selectedRow == default(Order))
            {
                return;
            }

            _orderContentPresenter = Program.Kernel.Get<IOrderContentPresenter>();
            _orderContentPresenter.ShowDialog(selectedRow, Place);
            _orderPresenter.RefreshData(Place);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderItemPresenter = Program.Kernel.Get<IOrderItemPresenter>();
            _orderItemPresenter.ShowDialog(null);
            _orderPresenter.RefreshData(Place);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Order>(dataGridViewOrders);

            if (selectedRow == default(Order))
            {
                return;
            }

            _orderItemPresenter = Program.Kernel.Get<IOrderItemPresenter>();
            _orderItemPresenter.ShowDialog(selectedRow);
            _orderPresenter.RefreshData(Place);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Order>(dataGridViewOrders);

            if (selectedRow == default(Order))
            {
                return;
            }

            if (MessageBox.Show(
                "Usunięcie zamówienia spowoduje również usunięcie jego całej zawartości. Czy aby napewno chcesz usunąć te zamówienia?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _orderPresenter.DeleteOrder(selectedRow);
                _orderPresenter.RefreshData(Place);
            }
        }

        public DialogResult ShowDialog(Place place)
        {
            textBoxPlace.Text = place.Name;
            Place = place;

            return base.ShowDialog();
        }

        private void dataGridViewOrders_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewOrders, e.ColumnIndex);
        }

        private void textBoxPlace_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }
    }
}
