using System;
using System.Windows.Forms;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using NHibernate.Criterion;
using Order = Elrob.Terminal.Dto.Order;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class OrderItemPresenter : IOrderItemPresenter
    {
        private readonly IOrderItemView _orderItemView;
        private readonly IOrderItemModel _orderItemModel;

        public OrderItemPresenter(IOrderItemView orderItemView, IOrderItemModel orderItemModel)
        {
            if (orderItemView == null) throw new ArgumentNullException("orderItemView");
            if (orderItemModel == null) throw new ArgumentNullException("orderItemModel");

            _orderItemView = orderItemView;
            _orderItemModel = orderItemModel;
        }

        public void UpdateOrder(Order order)
        {
            _orderItemModel.UpdateOrder(order);
        }

        public void AddOrder(Order order)
        {
            _orderItemModel.AddOrder(order);
        }

        public DialogResult ShowDialog(Order order)
        {
            _orderItemView.PassedOrder = order;
            _orderItemView.NameErrorProvider.Clear();

            if (_orderItemView.PassedOrder != null)
            {
                _orderItemView.IsInEditMode = true;
                _orderItemView.TextBoxName.Text = _orderItemView.PassedOrder.Name;
                _orderItemView.DateTimePickerStartDate.Value = _orderItemView.PassedOrder.StartDate;
            }
            else
            {
                _orderItemView.IsInEditMode = false;
            }

            return _orderItemView.ShowDialog();
        }

        public void AcceptChanges()
        {
            var orderExists = _orderItemModel.IsOrderExist(_orderItemView.Order);

            if (orderExists)
            {
                _orderItemView.NameErrorProvider.SetError(_orderItemView.TextBoxName, "Zamówienie z taką nazwą już istnieje!");
                return;
            }
            
            _orderItemView.NameErrorProvider.Clear();

            if (_orderItemView.IsInEditMode)
            {
                _orderItemModel.UpdateOrder(_orderItemView.Order);
            }
            else
            {
                _orderItemModel.AddOrder(_orderItemView.Order);
            }

            _orderItemView.DialogResult = DialogResult.OK;
        }
    }
}
