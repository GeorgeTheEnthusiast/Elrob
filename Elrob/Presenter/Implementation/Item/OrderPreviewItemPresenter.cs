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

            _orderPreviewItemView.PassedOrderContent = orderContent;
            _orderPreviewItemView.PassedOrder = order;

            _orderPreviewItemView.ComboBoxMaterial.DataSource = materials;
            _orderPreviewItemView.ComboBoxPlace.DataSource = places;

            if (_orderPreviewItemView.PassedOrderContent != null)
            {
                _orderPreviewItemView.ComboBoxMaterial.SelectedIndex = materials.IndexOf(materials.FirstOrDefault(x => x.Name == orderContent.Material.Name));
                _orderPreviewItemView.ComboBoxPlace.SelectedIndex = places.IndexOf(places.FirstOrDefault(x => x.Name == orderContent.Place.Name));
                
                _orderPreviewItemView.TextBoxName.Text = _orderPreviewItemView.PassedOrderContent.Name;
                _orderPreviewItemView.TextBoxDocumentNumber.Text = _orderPreviewItemView.PassedOrderContent.DocumentNumber;
                _orderPreviewItemView.NumericUpDownHeight.Value = _orderPreviewItemView.PassedOrderContent.Height.GetValueOrDefault();
                _orderPreviewItemView.NumericUpDownWidth.Value = _orderPreviewItemView.PassedOrderContent.Width.GetValueOrDefault();
                _orderPreviewItemView.NumericUpDownPackageQuantity.Value = _orderPreviewItemView.PassedOrderContent.PackageQuantity;
                _orderPreviewItemView.NumericUpDownThickness.Value = _orderPreviewItemView.PassedOrderContent.Thickness.GetValueOrDefault();
                _orderPreviewItemView.NumericUpDownToComplete.Value = _orderPreviewItemView.PassedOrderContent.ToComplete;
                _orderPreviewItemView.NumericUpDownUnitWeight.Value = _orderPreviewItemView.PassedOrderContent.UnitWeight;
            }

            return _orderPreviewItemView.ShowDialog();
        }

        public OrderContent OrderContent => _orderPreviewItemView.OrderContent;
    }
}
