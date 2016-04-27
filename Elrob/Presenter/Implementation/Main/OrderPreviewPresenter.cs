using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class OrderPreviewPresenter : IOrderPreviewPresenter
    {
        private readonly IOrderPreviewView _orderPreviewView;
        private readonly IOrderPreviewModel _orderPreviewModel;
        private readonly IOrderContentConverter _orderContentConverter;
        private IOrderPreviewItemPresenter _orderPreviewItemPresenter;

        public OrderPreviewPresenter(IOrderPreviewView orderPreviewView, IOrderPreviewModel orderPreviewModel, IOrderContentConverter orderContentConverter)
        {
            if (orderPreviewView == null) throw new ArgumentNullException("orderPreviewView");
            if (orderPreviewModel == null) throw new ArgumentNullException("orderPreviewModel");
            if (orderContentConverter == null) throw new ArgumentNullException("orderContentConverter");

            _orderPreviewView = orderPreviewView;
            _orderPreviewModel = orderPreviewModel;
            _orderContentConverter = orderContentConverter;
        }

        public DialogResult ShowDialog(OrderPreviewViewModel orderPreviewViewModel)
        {
            int id = 1;
            orderPreviewViewModel.OrderContents.ForEach(x =>
            {
                x.Id = id;
                id++;
            });

            _orderPreviewView.OrderContents.Clear();

            foreach (var orderContent in orderPreviewViewModel.OrderContents)
            {
                _orderPreviewView.OrderContents.Add(orderContent);
            }

            if (orderPreviewViewModel.Order != null)
            {
                _orderPreviewView.TextBoxOrderName.Text = orderPreviewViewModel.Order.Name;
                _orderPreviewView.Order = orderPreviewViewModel.Order;
            }

            _orderPreviewView.Materials = orderPreviewViewModel.Materials;
            _orderPreviewView.Places = orderPreviewViewModel.Places;

            return _orderPreviewView.ShowDialog();
        }

        public void ShowAddForm()
        {
            _orderPreviewItemPresenter = Program.Kernel.Get<IOrderPreviewItemPresenter>();
            var dialogResult = _orderPreviewItemPresenter.ShowDialog(_orderPreviewView.Order, null, _orderPreviewView.Materials, _orderPreviewView.Places);

            if (dialogResult == DialogResult.OK)
            {
                var nextId = _orderPreviewView.OrderContents.Max(x => x.Id) + 1;
                _orderPreviewItemPresenter.OrderContent.Id = nextId;

                _orderPreviewView.OrderContents.Add(_orderPreviewItemPresenter.OrderContent);
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(_orderPreviewView.DataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            _orderPreviewItemPresenter = Program.Kernel.Get<IOrderPreviewItemPresenter>();
            var dialogResult = _orderPreviewItemPresenter.ShowDialog(_orderPreviewView.Order, selectedRow, _orderPreviewView.Materials, _orderPreviewView.Places);

            if (dialogResult == DialogResult.OK)
            {
                var row = _orderPreviewView.OrderContents.FirstOrDefault(x => x.Id == _orderPreviewItemPresenter.OrderContent.Id);
                var rowIndex = _orderPreviewView.OrderContents.IndexOf(row);
                row = _orderContentConverter.Clone(_orderPreviewItemPresenter.OrderContent, row);
                _orderPreviewView.OrderContents[rowIndex] = row;
            }
        }

        public void DeleteOrderContent()
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(_orderPreviewView.DataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            var row = _orderPreviewView.OrderContents.FirstOrDefault(x => x.Id == selectedRow.Id);
            _orderPreviewView.OrderContents.Remove(row);
        }

        public void AcceptChanges()
        {
            _orderPreviewView.Order.Name = _orderPreviewView.TextBoxOrderName.Text.Trim();

            bool orderExist = _orderPreviewModel.IsOrderExist(_orderPreviewView.Order.Name);

            if (orderExist)
            {
                MessageBox.Show("Zamówienie z taką nazwą już istnieje!");
                return;
            }

            var orderContentList = _orderPreviewView.OrderContents.ToList();
            orderContentList.ForEach(x => x.Id = 0);
            _orderPreviewView.Order.StartDate = _orderPreviewView.DateTimePickerStartDate.Value;

            _orderPreviewModel.SaveOrder(_orderPreviewView.Order, orderContentList);

            MessageBox.Show("Import zakończony powodzeniem!");

            _orderPreviewView.DialogResult = DialogResult.OK;
        }
    }
}
