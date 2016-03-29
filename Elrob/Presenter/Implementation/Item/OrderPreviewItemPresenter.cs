using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class OrderPreviewItemPresenter : IOrderPreviewItemPresenter
    {
        private readonly IOrderPreviewItemView _orderPreviewItemView;
        private readonly IOrderPreviewItemModel _orderPreviewItemModel;

        public OrderPreviewItemPresenter(IOrderPreviewItemView orderPreviewItemView, IOrderPreviewItemModel orderPreviewItemModel)
        {
            if (orderPreviewItemView == null) throw new ArgumentNullException("orderPreviewItemView");
            if (orderPreviewItemModel == null) throw new ArgumentNullException("orderPreviewItemModel");

            _orderPreviewItemView = orderPreviewItemView;
            _orderPreviewItemModel = orderPreviewItemModel;
        }

        public DialogResult ShowDialog(Order order, OrderContent orderContent, List<Material> materials, List<Place> places)
        {
            var presentMaterials = _orderPreviewItemModel.GetAllMaterials();
            var presentPlaces = _orderPreviewItemModel.GetAllPlaces();

            materials = materials.Concat(presentMaterials)
                .Distinct(new MaterialComparer())
                .ToList();

            places = places.Concat(presentPlaces)
                .Distinct(new PlaceComparer())
                .ToList();

            return _orderPreviewItemView.ShowDialog(order, orderContent, materials, places);
        }

        public List<Material> GetAllMaterials()
        {
            return _orderPreviewItemModel.GetAllMaterials();
        }

        public List<Place> GetAllPlaces()
        {
            return _orderPreviewItemModel.GetAllPlaces();
        }

        public OrderContent OrderContent => _orderPreviewItemView.OrderContent;
    }
}
