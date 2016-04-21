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
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class OrderProgressView : Form, IOrderProgressView
    {
        private readonly IOrderProgressPresenter _orderProgressPresenter;

        public OrderProgressView()
        {
            _orderProgressPresenter = new OrderProgressPresenter(this, Program.Kernel.Get<IOrderProgressModel>());

            InitializeComponent();

            dataGridViewOrderProgress.AutoGenerateColumns = false;
            dataGridViewOrderProgress.DataSource = OrderProgresses = new CustomBindingList<OrderProgress>();
            Icon = Resources.purchase_order;

            _orderProgressPresenter.SetPermissions();
        }

        public CustomBindingList<OrderProgress> OrderProgresses { get; set; }

        public OrderContent OrderContent => comboBoxOrderContent.SelectedItem as OrderContent;

        public Place Place { get; set; }

        public ComboBox ComboBoxOrderContent => comboBoxOrderContent;

        public ComboBox ComboBoxOrderContentByDocumentNumber => comboBoxOrderContentByDocumentNumber;

        public TextBox TextBoxOrder => textBoxOrder;
        
        public TextBox TextBoxToComplete => textBoxToComplete;

        public TextBox TextBoxCompletedSum => _textBoxCompletedSum;

        public TextBox TextBoxTimeSpendSum => textBoxTimeSpendSum;

        public Button ButtonEdit => buttonEdit;

        public Button ButtonAdd => buttonAdd;

        public Button ButtonDelete => buttonDelete;

        public DataGridViewTextBoxColumn DataGridViewUserColumn => UserColumn;

        public DataGridView DataGridViewOrderProgress => dataGridViewOrderProgress;

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _orderProgressPresenter.ShowAddForm();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _orderProgressPresenter.ShowEditForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _orderProgressPresenter.DeleteOrderProgress();
        }

        private void dataGridViewOrderProgress_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewOrderProgress, e.ColumnIndex);
        }

        private void textBoxOrder_TextChanged(object sender, EventArgs e)
        {
            Helpers.textBox_FitHeightToText(sender, e);
        }

        private void comboBoxOrderContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            _orderProgressPresenter.RefreshComboBoxes(comboBox);
        }
    }
}
