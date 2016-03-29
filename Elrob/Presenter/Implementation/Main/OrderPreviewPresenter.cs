using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class OrderPreviewPresenter : IOrderPreviewPresenter
    {
        private readonly IOrderPreviewView _orderPreviewView;
        private readonly IOrderPreviewModel _orderPreviewModel;
        private readonly IOrderContentConverter _orderContentConverter;

        public OrderPreviewPresenter(IOrderPreviewView orderPreviewView, IOrderPreviewModel orderPreviewModel, IOrderContentConverter orderContentConverter)
        {
            if (orderPreviewView == null) throw new ArgumentNullException("orderPreviewView");
            if (orderPreviewModel == null) throw new ArgumentNullException("orderPreviewModel");
            if (orderContentConverter == null) throw new ArgumentNullException("orderContentConverter");

            _orderPreviewView = orderPreviewView;
            _orderPreviewModel = orderPreviewModel;
            _orderContentConverter = orderContentConverter;
        }

        public bool SaveOrder(Order order, List<OrderContent> orderContents)
        {
            bool orderExist = _orderPreviewModel.IsOrderExist(order.Name);

            if (orderExist)
            {
                MessageBox.Show("Zamówienie z taką nazwą już istnieje!");
                return false;
            }

            orderContents.ForEach(x => x.Id = 0);

            _orderPreviewModel.SaveOrder(order, orderContents);

            MessageBox.Show("Import zakończony powodzeniem!");
            return true;
        }

        public void AddOrderContent(OrderContent orderContent)
        {
            var nextId = _orderPreviewView.OrderContents.Max(x => x.Id) + 1;
            orderContent.Id = nextId;

            _orderPreviewView.OrderContents.Add(orderContent);
        }

        public void UpdateOrderContent(OrderContent orderContent)
        {
            var row = _orderPreviewView.OrderContents.FirstOrDefault(x => x.Id == orderContent.Id);
            var rowIndex = _orderPreviewView.OrderContents.IndexOf(row);
            row = _orderContentConverter.Clone(orderContent, row);
            _orderPreviewView.OrderContents[rowIndex] = row;
        }

        public void DeleteOrderContent(OrderContent orderContent)
        {
            var row = _orderPreviewView.OrderContents.FirstOrDefault(x => x.Id == orderContent.Id);
            _orderPreviewView.OrderContents.Remove(row);
        }

        public DialogResult ShowDialog(OrderPreviewViewModel orderPreviewViewModel)
        {
            int id = 1;
            orderPreviewViewModel.OrderContents.ForEach(x =>
            {
                x.Id = id;
                id++;
            });

            return _orderPreviewView.ShowDialog(orderPreviewViewModel);
        }
    }
}
