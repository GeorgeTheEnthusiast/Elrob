using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Choose;
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

        public OrderPresenter(IOrderView orderView, IOrderModel orderModel)
        {
            if (orderView == null) throw new ArgumentNullException("orderView");
            if (orderModel == null) throw new ArgumentNullException("orderModel");

            _orderView = orderView;
            _orderModel = orderModel;
        }

        public void DeleteOrder(Order order)
        {
            _orderModel.DeleteOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderModel.UpdateOrder(order);
        }

        public void AddOrder(Order order)
        {
            _orderModel.AddOrder(order);
        }

        public void ShowDialog()
        {
            _placeChoosePresenter = Program.Kernel.Get<IPlaceChoosePresenter>();
            var dialogResultPlace = _placeChoosePresenter.ShowDialog();

            if (dialogResultPlace == DialogResult.OK)
            {
                RefreshData(_placeChoosePresenter.ChoosedPlace);

                _orderView.ShowDialog(_placeChoosePresenter.ChoosedPlace);
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
    }
}
