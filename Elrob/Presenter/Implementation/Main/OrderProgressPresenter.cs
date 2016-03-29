using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class OrderProgressPresenter : IOrderProgressPresenter
    {
        private readonly IOrderProgressView _orderProgressView;
        private readonly IOrderProgressModel _orderProgressModel;

        public OrderProgressPresenter(IOrderProgressView orderProgressView, IOrderProgressModel orderProgressModel)
        {
            if (orderProgressView == null) throw new ArgumentNullException("orderProgressView");
            if (orderProgressModel == null) throw new ArgumentNullException("orderProgressModel");

            _orderProgressView = orderProgressView;
            _orderProgressModel = orderProgressModel;
        }

        public List<OrderProgress> GetOrderContentProgressById(int orderContentId)
        {
            return _orderProgressModel.GetOrderContentProgressById(orderContentId);
        }

        public void DeleteOrderProgress(OrderProgress orderProgress)
        {
            _orderProgressModel.DeleteOrderProgress(orderProgress);
        }

        public void ShowDialog(OrderContent orderContent)
        {
            _orderProgressView.OrderContent = orderContent;

            RefreshData();

            _orderProgressView.TextBoxOrderContent.Text = orderContent.Name;
            _orderProgressView.TextBoxOrder.Text = orderContent.Order.Name;
            _orderProgressView.TextBoxDocumentNumber.Text = orderContent.DocumentNumber;
            _orderProgressView.TextBoxToComplete.Text = orderContent.ToComplete.ToString();
            
            _orderProgressView.ShowDialog();
        }

        public void RefreshData()
        {
            _orderProgressView.OrderProgresses.Clear();
            var items = GetOrderContentProgressById(_orderProgressView.OrderContent.Id);

            foreach (var item in items)
            {
                _orderProgressView.OrderProgresses.Add(item);
            }

            _orderProgressView.TextBoxCompletedSum.Text = _orderProgressView.OrderProgresses.Sum(x => x.Completed).ToString();
        }
    }
}
