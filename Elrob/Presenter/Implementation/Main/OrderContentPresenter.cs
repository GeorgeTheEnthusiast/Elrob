using System;
using System.Collections.Generic;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class OrderContentPresenter : IOrderContentPresenter
    {
        private readonly IOrderContentView _orderContentView;
        private readonly IOrderContentModel _orderContentModel;

        public OrderContentPresenter(IOrderContentView orderContentView, IOrderContentModel orderContentModel)
        {
            if (orderContentView == null) throw new ArgumentNullException("orderContentView");
            if (orderContentModel == null) throw new ArgumentNullException("orderContentModel");

            _orderContentView = orderContentView;
            _orderContentModel = orderContentModel;
        }

        public void DeleteOrderContent(OrderContent orderContent)
        {
            _orderContentModel.DeleteOrderContent(orderContent);
        }

        public void UpdateOrderContent(OrderContent orderContent)
        {
            _orderContentModel.UpdateOrderContent(orderContent);
        }

        public void AddOrderContent(OrderContent orderContent)
        {
            _orderContentModel.AddOrderContent(orderContent);
        }

        public void ShowDialog(Order order, Place place)
        {
            RefreshData(order, place);

            _orderContentView.ShowDialog(order, place);
        }

        public void RefreshData(Order order, Place place)
        {
            _orderContentView.OrderContents.Clear();
            var items = new List<OrderContent>();

            if (place.Id == int.MaxValue)
            {
                items = _orderContentModel.GetOrderContent(order.Id);
            }
            else
            {
                items = _orderContentModel.GetOrderContent(order.Id, place.Id);
            }

            foreach (var item in items)
            {
                _orderContentView.OrderContents.Add(item);
            }
        }
    }
}
