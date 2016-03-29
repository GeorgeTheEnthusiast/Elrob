using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class OrderContentItemPresenter : IOrderContentItemPresenter
    {
        private readonly IOrderContentItemView _orderContentItemView;
        private readonly IOrderContentItemModel _orderContentItemModel;

        public OrderContentItemPresenter(IOrderContentItemView orderContentItemView, IOrderContentItemModel orderContentItemModel)
        {
            if (orderContentItemView == null) throw new ArgumentNullException("orderContentItemView");
            if (orderContentItemModel == null) throw new ArgumentNullException("orderContentItemModel");

            _orderContentItemView = orderContentItemView;
            _orderContentItemModel = orderContentItemModel;
        }

        public DialogResult ShowDialog(Order order, OrderContent orderContent, Place place)
        {
            return _orderContentItemView.ShowDialog(order, orderContent, place);
        }

        public List<Material> GetAllMaterials()
        {
            return _orderContentItemModel.GetAllMaterials();
        }

        public List<Place> GetAllPlaces(Place place)
        {
            var places = new List<Place>();

            if (place.Id == int.MaxValue)
            {
                places = _orderContentItemModel.GetAllPlaces(); 
            }
            else
            {
                places.Add(place);
            }

            return places;
        }

        public OrderContent OrderContent => _orderContentItemView.OrderContent;
    }
}
