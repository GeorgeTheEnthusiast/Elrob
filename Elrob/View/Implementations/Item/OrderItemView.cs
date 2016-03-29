using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class OrderItemView : Form, IOrderItemView
    {
        private readonly IOrderItemPresenter _orderItemPresenter;

        private bool _isInEditMode;

        private Order _order;

        public OrderItemView()
        {
            _orderItemPresenter = new OrderItemPresenter(this, Program.Kernel.Get<IOrderItemModel>());
            
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            var orderExists = _orderItemPresenter.IsOrderExist(Order.Name);

            if (orderExists)
            {
                nameErrorProvider.SetError(textBoxName, "Zamówienie z taką nazwą już istnieje!");
                return;
            }
            else
            {
                nameErrorProvider.Clear();
            }

            if (_isInEditMode)
            {
                _orderItemPresenter.UpdateOrder(Order);
            }
            else
            {
                _orderItemPresenter.AddOrder(Order);
            }

            DialogResult = DialogResult.OK;
        }

        public Order Order => new Order()
        {
            Name = textBoxName.Text.Trim(),
            Id = _order?.Id ?? 0
        };

        public DialogResult ShowDialog(Order order)
        {
            _order = order;
            nameErrorProvider.Clear();

            if (_order != null)
            {
                _isInEditMode = true;
                textBoxName.Text = _order.Name;
            }
            else
            {
                _isInEditMode = false;
            }

            return base.ShowDialog();
        }
    }
}
