using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class OrderProgressItemPresenter : IOrderProgressItemPresenter
    {
        private readonly IOrderProgressItemView _orderProgressItemView;
        private readonly IOrderProgressItemModel _orderProgressItemModel;

        public OrderProgressItemPresenter(IOrderProgressItemView orderProgressItemView, IOrderProgressItemModel orderProgressItemModel)
        {
            if (orderProgressItemView == null) throw new ArgumentNullException("orderProgressItemView");
            if (orderProgressItemModel == null) throw new ArgumentNullException("orderProgressItemModel");

            _orderProgressItemView = orderProgressItemView;
            _orderProgressItemModel = orderProgressItemModel;
        }

        public void AcceptChanges()
        {
            if (_orderProgressItemView.IsInEditMode)
            {
                _orderProgressItemModel.UpdateOrderProgress(_orderProgressItemView.OrderProgress);
            }
            else
            {
                _orderProgressItemModel.AddOrderProgress(_orderProgressItemView.OrderProgress);
            }

            _orderProgressItemView.DialogResult = DialogResult.OK;
        }

        public DialogResult ShowDialog(OrderContent orderContent, OrderProgress orderProgress)
        {
            _orderProgressItemView.PassedOrderProgress = orderProgress;
            _orderProgressItemView.PassedOrderContent = orderContent;

            if (_orderProgressItemView.PassedOrderProgress != null)
            {
                _orderProgressItemView.IsInEditMode = true;
                _orderProgressItemView.NumericUpDownCompleted.Value = _orderProgressItemView.PassedOrderProgress.Completed;
                _orderProgressItemView.DateTimePickerTimeSpend.Value = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    _orderProgressItemView.PassedOrderProgress.TimeSpend.Hours,
                    _orderProgressItemView.PassedOrderProgress.TimeSpend.Minutes,
                    _orderProgressItemView.PassedOrderProgress.TimeSpend.Seconds);
            }
            else
            {
                _orderProgressItemView.IsInEditMode = false;
            }

            return _orderProgressItemView.ShowDialog();
        }
    }
}
