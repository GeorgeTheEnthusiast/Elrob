using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
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
    public partial class OrderPreviewView : Form, IOrderPreviewView
    {
        private readonly IOrderPreviewPresenter _orderPreviewPresenter;
        private IOrderPreviewItemPresenter _orderPreviewItemPresenter;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public OrderPreviewView()
        {
            _orderPreviewPresenter = new OrderPreviewPresenter(this, Program.Kernel.Get<IOrderPreviewModel>(), Program.Kernel.Get<IOrderContentConverter>());

            InitializeComponent();

            dataGridViewOrderContent.AutoGenerateColumns = false;
            dataGridViewOrderContent.DataSource = OrderContents = new CustomBindingList<OrderContent>();
        }

        public DialogResult ShowDialog(OrderPreviewViewModel orderViewModel)
        {
            foreach (var orderContent in orderViewModel.OrderContents)
            {
                OrderContents.Add(orderContent);
            }
            
            if (orderViewModel.Order != null)
            {
                textBoxOrderName.Text = orderViewModel.Order.Name;
                Order = orderViewModel.Order;
            }

            Materials = orderViewModel.Materials;
            Places = orderViewModel.Places;

            return ShowDialog();
        }

        public CustomBindingList<OrderContent> OrderContents { get; set; }

        public Order Order { get; set; }

        public List<Material> Materials { get; set; }

        public List<Place> Places { get; set; }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Order.Name = textBoxOrderName.Text.Trim();
            bool saveResult = _orderPreviewPresenter.SaveOrder(Order, OrderContents.ToList());

            if (saveResult)
            {
                Close();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderPreviewItemPresenter = Program.Kernel.Get<IOrderPreviewItemPresenter>();
            var dialogResult = _orderPreviewItemPresenter.ShowDialog(Order, null, Materials, Places);

            if (dialogResult == DialogResult.OK)
            {
                _orderPreviewPresenter.AddOrderContent(_orderPreviewItemPresenter.OrderContent);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(dataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            _orderPreviewItemPresenter = Program.Kernel.Get<IOrderPreviewItemPresenter>();
            var dialogResult = _orderPreviewItemPresenter.ShowDialog(Order, selectedRow, Materials, Places);

            if (dialogResult == DialogResult.OK)
            {
                _orderPreviewPresenter.UpdateOrderContent(_orderPreviewItemPresenter.OrderContent);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(dataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            _orderPreviewPresenter.DeleteOrderContent(selectedRow);
        }

        private void dataGridViewOrderContent_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewOrderContent, e.ColumnIndex);
        }

        private void textBoxOrderName_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }

        private void textBoxOrderName_TextChanged_1(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }
    }
}
