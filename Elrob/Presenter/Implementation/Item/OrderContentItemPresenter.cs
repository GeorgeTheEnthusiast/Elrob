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
            _orderContentItemView.PassedOrderContent = orderContent;
            _orderContentItemView.PassedOrder = order;

            var materials = _orderContentItemModel.GetAllMaterials();
            var places = GetAllPlaces(place);

            _orderContentItemView.ComboBoxMaterial.DataSource = materials;
            _orderContentItemView.ComboBoxPlace.DataSource = places;

            if (orderContent != null)
            {
                _orderContentItemView.ComboBoxMaterial.SelectedIndex = materials.IndexOf(materials.FirstOrDefault(x => x.Id == orderContent.Material.Id));
                _orderContentItemView.ComboBoxPlace.SelectedIndex = places.IndexOf(places.FirstOrDefault(x => x.Id == orderContent.Place.Id));

                _orderContentItemView.TextBoxName.Text = orderContent.Name;
                _orderContentItemView.TextBoxDocumentNumber.Text = orderContent.DocumentNumber;
                _orderContentItemView.NumericUpDownHeight.Value = orderContent.Height.GetValueOrDefault();
                _orderContentItemView.NumericUpDownWidth.Value = orderContent.Width.GetValueOrDefault();
                _orderContentItemView.NumericUpDownPackageQuantity.Value = orderContent.PackageQuantity;
                _orderContentItemView.NumericUpDownThickness.Value = orderContent.Thickness.GetValueOrDefault();
                _orderContentItemView.NumericUpDownToComplete.Value = orderContent.ToComplete;
                _orderContentItemView.NumericUpDownUnitWeight.Value = orderContent.UnitWeight;
            }

            return _orderContentItemView.ShowDialog();
        }

        private List<Place> GetAllPlaces(Place place)
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
