using System;
using System.ComponentModel;
using System.Drawing;
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
using NLog;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class OrderContentView : Form, IOrderContentView
    {
        private readonly IOrderContentPresenter _orderContentPresenter;
        private IOrderContentItemPresenter _orderContentItemPresenter;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public OrderContentView()
        {
            _orderContentPresenter = new OrderContentPresenter(this, Program.Kernel.Get<IOrderContentModel>());

            InitializeComponent();

            dataGridViewOrderContent.AutoGenerateColumns = false;
            dataGridViewOrderContent.DataSource = OrderContents = new CustomBindingList<OrderContent>();

            buttonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderContentView_EditRows);
            buttonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderContentView_AddRows);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderContentView_DeleteRows);
        }

        public DialogResult ShowDialog(Order order, Place place)
        {
            textBoxOrderName.Text = order.Name;
            textBoxPlace.Text = place.Name;
            Order = order;
            Place = place;

            return base.ShowDialog();
        }

        public CustomBindingList<OrderContent> OrderContents { get; set; }

        public Order Order { get; set; }

        public Place Place { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderContentItemPresenter = Program.Kernel.Get<IOrderContentItemPresenter>();
            var dialogResult = _orderContentItemPresenter.ShowDialog(Order, null, Place);

            if (dialogResult == DialogResult.OK)
            {
                _orderContentPresenter.AddOrderContent(_orderContentItemPresenter.OrderContent);
                _orderContentPresenter.RefreshData(Order, Place);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(dataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            _orderContentItemPresenter = Program.Kernel.Get<IOrderContentItemPresenter>();
            var dialogResult = _orderContentItemPresenter.ShowDialog(Order, selectedRow, Place);

            if (dialogResult == DialogResult.OK)
            {
                _orderContentPresenter.UpdateOrderContent(_orderContentItemPresenter.OrderContent);
                _orderContentPresenter.RefreshData(Order, Place);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(dataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            _orderContentPresenter.DeleteOrderContent(selectedRow);
            _orderContentPresenter.RefreshData(Order, Place);
        }

        private void dataGridViewOrderContent_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewOrderContent, e.ColumnIndex);
        }

        private void textBoxPlace_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }

        private void textBoxOrderName_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }
    }
}
