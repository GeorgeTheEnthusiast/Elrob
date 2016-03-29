﻿using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

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
            return _orderItemView.ShowDialog(order);
        }

        public bool IsOrderExist(string orderName)
        {
            return _orderItemModel.IsOrderExist(orderName);
        }
    }
}
