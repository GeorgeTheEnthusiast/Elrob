using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class PlaceItemPresenter : IPlaceItemPresenter
    {
        private readonly IPlaceItemView _placeItemView;
        private readonly IPlaceItemModel _placeItemModel;

        public PlaceItemPresenter(IPlaceItemView placeItemView, IPlaceItemModel placeItemModel)
        {
            if (placeItemView == null) throw new ArgumentNullException("placeItemView");
            if (placeItemModel == null) throw new ArgumentNullException("placeItemModel");

            _placeItemView = placeItemView;
            _placeItemModel = placeItemModel;
        }

        public void UpdatePlace(Place place)
        {
            _placeItemModel.UpdatePlace(place);
        }

        public void AddPlace(Place place)
        {
            _placeItemModel.AddPlace(place);
        }

        public DialogResult ShowDialog(Place place)
        {
            return _placeItemView.ShowDialog(place);
        }

        public bool IsPlaceExist(string placeName)
        {
            return _placeItemModel.IsPlaceExist(placeName);
        }
    }
}
