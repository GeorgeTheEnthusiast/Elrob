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
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;
using NLog;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class OrderContentView : Form, IOrderContentView
    {
        private readonly IOrderContentPresenter _orderContentPresenter;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public OrderContentView()
        {
            _orderContentPresenter = new OrderContentPresenter(this, Program.Kernel.Get<IOrderContentModel>());

            InitializeComponent();

            dataGridViewOrderContent.AutoGenerateColumns = false;
            dataGridViewOrderContent.DataSource = OrderContents = new CustomBindingList<OrderContent>();
            Icon = Resources.purchase_order;

            _orderContentPresenter.SetPermissions();
        }

        public CustomBindingList<OrderContent> OrderContents { get; set; }

        public Order Order { get; set; }

        public Place Place { get; set; }

        public TextBox TextBoxOrderName => textBoxOrderName;

        public TextBox TextBoxPlace => textBoxPlace;

        public Button ButtonEdit => buttonEdit;

        public Button ButtonAdd => buttonAdd;

        public Button ButtonDelete => buttonDelete;

        public DataGridView DataGridViewOrderContent => dataGridViewOrderContent;

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderContentPresenter.ShowAddForm();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _orderContentPresenter.ShowEditForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _orderContentPresenter.DeleteOrderContent();
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
