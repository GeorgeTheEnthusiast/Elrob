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

        public OrderView()
        {
            _orderPresenter = new OrderPresenter(this, Program.Kernel.Get<IOrderModel>());

            InitializeComponent();

            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.DataSource = Orders = new CustomBindingList<Order>();

            _orderPresenter.SetPermissions();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public CustomBindingList<Order> Orders { get; set; }

        public Place Place { get; set; }

        public Button ButtonAdd => buttonAdd;

        public Button ButtonEdit => buttonEdit;

        public Button ButtonDelete => buttonDelete;

        public TextBox TextBoxPlace => textBoxPlace;

        public DataGridView DataGridViewOrders => dataGridViewOrders;

        private void buttonOrderContent_Click(object sender, EventArgs e)
        {
            _orderPresenter.ShowOrderContentForm();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderPresenter.ShowAddForm();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _orderPresenter.ShowEditForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _orderPresenter.DeleteOrder();
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
