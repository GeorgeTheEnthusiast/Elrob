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
    public class OrderChoosePresenter : IOrderChoosePresenter
    {
        private readonly IOrderChooseView _orderChooseView;
        private readonly IOrderChooseModel _orderChooseModel;

        public OrderChoosePresenter(IOrderChooseView orderChooseView, IOrderChooseModel orderChooseModel)
        {
            if (orderChooseView == null) throw new ArgumentNullException("orderChooseView");
            if (orderChooseModel == null) throw new ArgumentNullException("orderChooseModel");

            _orderChooseView = orderChooseView;
            _orderChooseModel = orderChooseModel;
        }

        public Order ChoosedOrder => _orderChooseView.Order;

        public List<Order> GetAllOrders()
        {
            return _orderChooseModel.GetAllOrders();
        }

        public DialogResult ShowDialog()
        {
            return _orderChooseView.ShowDialog();
        }
    }
}
