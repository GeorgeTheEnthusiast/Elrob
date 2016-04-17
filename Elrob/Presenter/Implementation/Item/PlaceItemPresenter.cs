using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

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
            _placeItemView.PassedPlace = place;
            _placeItemView.NameErrorProvider.Clear();

            if (_placeItemView.PassedPlace != null)
            {
                _placeItemView.IsInEditMode = true;
                _placeItemView.TextBoxName.Text = _placeItemView.PassedPlace.Name;
            }
            else
            {
                _placeItemView.IsInEditMode = false;
            }
            
            return _placeItemView.ShowDialog();
        }

        public void AcceptChanges()
        {
            var placeExist = _placeItemModel.IsPlaceExist(_placeItemView.Place.Name);

            if (placeExist)
            {
                _placeItemView.NameErrorProvider.SetError(_placeItemView.TextBoxName, "Placówka z taką nazwą już istnieje!");
                return;
            }
            else
            {
                _placeItemView.NameErrorProvider.Clear();
            }

            if (_placeItemView.IsInEditMode)
            {
                _placeItemModel.UpdatePlace(_placeItemView.Place);
            }
            else
            {
                _placeItemModel.AddPlace(_placeItemView.Place);
            }

            _placeItemView.DialogResult = DialogResult.OK;
        }
    }
}
