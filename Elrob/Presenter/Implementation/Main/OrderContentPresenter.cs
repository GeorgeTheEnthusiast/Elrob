using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class OrderContentPresenter : IOrderContentPresenter
    {
        private readonly IOrderContentView _orderContentView;
        private readonly IOrderContentModel _orderContentModel;
        private IOrderContentItemPresenter _orderContentItemPresenter;

        public OrderContentPresenter(IOrderContentView orderContentView, IOrderContentModel orderContentModel)
        {
            if (orderContentView == null) throw new ArgumentNullException("orderContentView");
            if (orderContentModel == null) throw new ArgumentNullException("orderContentModel");

            _orderContentView = orderContentView;
            _orderContentModel = orderContentModel;
        }

        public DialogResult ShowDialog(Order order, Place place)
        {
            RefreshData(order, place);

            _orderContentView.TextBoxOrderName.Text = order.Name;
            _orderContentView.TextBoxPlace.Text = place.Name;
            _orderContentView.Order = order;
            _orderContentView.Place = place;

            return _orderContentView.ShowDialog();
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

        public void ShowAddForm()
        {
            _orderContentItemPresenter = Program.Kernel.Get<IOrderContentItemPresenter>();
            var dialogResult = _orderContentItemPresenter.ShowDialog(_orderContentView.Order, null, _orderContentView.Place);

            if (dialogResult == DialogResult.OK)
            {
                _orderContentModel.AddOrderContent(_orderContentItemPresenter.OrderContent);
                RefreshData(_orderContentView.Order, _orderContentView.Place);
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(_orderContentView.DataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            _orderContentItemPresenter = Program.Kernel.Get<IOrderContentItemPresenter>();
            var dialogResult = _orderContentItemPresenter.ShowDialog(_orderContentView.Order, selectedRow, _orderContentView.Place);

            if (dialogResult == DialogResult.OK)
            {
                _orderContentModel.UpdateOrderContent(_orderContentItemPresenter.OrderContent);
                RefreshData(_orderContentView.Order, _orderContentView.Place);
            }
        }

        public void DeleteOrderContent()
        {
            var selectedRow = Helpers.GetSelectedRow<OrderContent>(_orderContentView.DataGridViewOrderContent);

            if (selectedRow == default(OrderContent))
            {
                return;
            }

            _orderContentModel.DeleteOrderContent(selectedRow);
            RefreshData(_orderContentView.Order, _orderContentView.Place);
        }

        public void SetPermissions()
        {
            _orderContentView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderContentView_EditRows);
            _orderContentView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderContentView_AddRows);
            _orderContentView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderContentView_DeleteRows);
        }
    }
}
