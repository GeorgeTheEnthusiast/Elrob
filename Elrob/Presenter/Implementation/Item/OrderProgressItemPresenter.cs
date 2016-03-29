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

        public void UpdateOrderProgress(OrderProgress orderProgress)
        {
            _orderProgressItemModel.UpdateOrderProgress(orderProgress);
        }

        public void AddOrderProgress(OrderProgress orderProgress)
        {
            _orderProgressItemModel.AddOrderProgress(orderProgress);
        }

        public DialogResult ShowDialog(OrderContent orderContent, OrderProgress orderProgress)
        {
            return _orderProgressItemView.ShowDialog(orderContent, orderProgress);
        }
    }
}
