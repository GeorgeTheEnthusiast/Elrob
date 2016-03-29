using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Choose;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Choose
{
    public class OrderContentChoosePresenter : IOrderContentChoosePresenter
    {
        private readonly IOrderContentChooseView _orderContentChooseView;
        private readonly IOrderContentChooseModel _orderContentChooseModel;

        public OrderContentChoosePresenter(IOrderContentChooseView orderContentChooseView, IOrderContentChooseModel orderContentChooseModel)
        {
            if (orderContentChooseView == null) throw new ArgumentNullException("orderContentChooseView");
            if (orderContentChooseModel == null) throw new ArgumentNullException("orderContentChooseModel");

            _orderContentChooseView = orderContentChooseView;
            _orderContentChooseModel = orderContentChooseModel;
        }

        public OrderContent ChoosedOrderContent => _orderContentChooseView.OrderContent;
        
        public DialogResult ShowDialog(Order order, Place place)
        {
            if (place.Id == int.MaxValue)
            {
                _orderContentChooseView.ComboBoxOrders.DataSource = _orderContentChooseModel.GetOrderContentsByOrder(order);
            }
            else
            {
                _orderContentChooseView.ComboBoxOrders.DataSource = _orderContentChooseModel.GetOrderContentsByOrderAndPlace(order, place);
            }
            
            return _orderContentChooseView.ShowDialog();
        }
    }
}
