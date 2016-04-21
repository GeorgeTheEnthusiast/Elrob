using System;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Choose;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Choose;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Choose
{
    public partial class OrderChooseView : Form, IOrderChooseView
    {
        private IOrderChoosePresenter _orderChoosePresenter;

        public OrderChooseView()
        {
            InitializeComponent();

            _orderChoosePresenter = new OrderChoosePresenter(this, Program.Kernel.Get<IOrderChooseModel>());
            comboBoxOrders.DataSource = _orderChoosePresenter.GetAllOrders();
            Icon = Resources.purchase_order;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public Order Order => comboBoxOrders.SelectedItem as Order;

        public DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }
    }
}
