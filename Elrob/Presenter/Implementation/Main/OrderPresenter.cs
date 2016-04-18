using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class OrderPresenter : IOrderPresenter
    {
        private readonly IOrderView _orderView;
        private readonly IOrderModel _orderModel;
        private IPlaceChoosePresenter _placeChoosePresenter;
        private IOrderItemPresenter _orderItemPresenter;
        private IOrderContentPresenter _orderContentPresenter;

        public OrderPresenter(IOrderView orderView, IOrderModel orderModel)
        {
            if (orderView == null) throw new ArgumentNullException("orderView");
            if (orderModel == null) throw new ArgumentNullException("orderModel");

            _orderView = orderView;
            _orderModel = orderModel;
        }

        public void ShowDialog()
        {
            _placeChoosePresenter = Program.Kernel.Get<IPlaceChoosePresenter>();
            var dialogResultPlace = _placeChoosePresenter.ShowDialog();

            if (dialogResultPlace == DialogResult.OK)
            {
                RefreshData(_placeChoosePresenter.ChoosedPlace);

                _orderView.TextBoxPlace.Text = _placeChoosePresenter.ChoosedPlace.Name;
                _orderView.Place = _placeChoosePresenter.ChoosedPlace;

                _orderView.ShowDialog();
            }
        }

        public void RefreshData(Place place)
        {
            _orderView.Orders.Clear();

            var items = new List<Order>();

            if (place.Id == int.MaxValue)
            {
                items = _orderModel.GetOrdersWithProgress();
            }
            else
            {
                items = _orderModel.GetOrdersWithProgressByPlace(place.Id);
            }
            
            foreach (var item in items)
            {
                _orderView.Orders.Add(item);
            }
        }

        public void SetPermissions()
        {
            _orderView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_EditRows);
            _orderView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_AddRows);
            _orderView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_DeleteRows);
        }

        public void ShowAddForm()
        {
            _orderItemPresenter = Program.Kernel.Get<IOrderItemPresenter>();
            var dialogResult = _orderItemPresenter.ShowDialog(null);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData(_orderView.Place);
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<Order>(_orderView.DataGridViewOrders);

            if (selectedRow == default(Order))
            {
                return;
            }

            _orderItemPresenter = Program.Kernel.Get<IOrderItemPresenter>();
            var dialogResult = _orderItemPresenter.ShowDialog(selectedRow);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData(_orderView.Place);
            }
        }

        public void DeleteOrder()
        {
            var selectedRow = Helpers.GetSelectedRow<Order>(_orderView.DataGridViewOrders);

            if (selectedRow == default(Order))
            {
                return;
            }

            if (MessageBox.Show(
                "Usunięcie zamówienia spowoduje również usunięcie jego całej zawartości oraz raportów z przepracowanych godzin. Czy aby napewno chcesz usunąć te zamówienia?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _orderModel.DeleteOrder(selectedRow);
                RefreshData(_orderView.Place);
            }
        }

        public void ShowOrderContentForm()
        {
            var selectedRow = Helpers.GetSelectedRow<Order>(_orderView.DataGridViewOrders);

            if (selectedRow == default(Order))
            {
                return;
            }

            _orderContentPresenter = Program.Kernel.Get<IOrderContentPresenter>();
            var dialogResult = _orderContentPresenter.ShowDialog(selectedRow, _orderView.Place);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData(_orderView.Place);
            }
        }
    }
}
