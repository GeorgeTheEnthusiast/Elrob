using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
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
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public OrderPreviewView()
        {
            _orderPreviewPresenter = new OrderPreviewPresenter(this, Program.Kernel.Get<IOrderPreviewModel>(), Program.Kernel.Get<IOrderContentConverter>());

            InitializeComponent();

            dataGridViewOrderContent.AutoGenerateColumns = false;
            dataGridViewOrderContent.DataSource = OrderContents = new CustomBindingList<OrderContent>();
        }

        public CustomBindingList<OrderContent> OrderContents { get; set; }

        public Order Order { get; set; }

        public List<Material> Materials { get; set; }

        public List<Place> Places { get; set; }

        public TextBox TextBoxOrderName => textBoxOrderName;

        public DataGridView DataGridViewOrderContent => dataGridViewOrderContent;

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            _orderPreviewPresenter.AcceptChanges();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderPreviewPresenter.ShowAddForm();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _orderPreviewPresenter.ShowEditForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _orderPreviewPresenter.DeleteOrderContent();
        }

        private void dataGridViewOrderContent_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewOrderContent, e.ColumnIndex);
        }

        private void textBoxOrderName_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }
    }
}
