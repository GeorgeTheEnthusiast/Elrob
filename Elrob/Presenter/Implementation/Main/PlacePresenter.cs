using System;
using System.Collections.Generic;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class PlacePresenter : IPlacePresenter
    {
        private readonly IPlaceView _placeView;
        private readonly IPlaceModel _placeModel;

        public PlacePresenter(IPlaceView placeView, IPlaceModel placeModel)
        {
            if (placeView == null) throw new ArgumentNullException("placeView");
            if (placeModel == null) throw new ArgumentNullException("placeModel");

            _placeView = placeView;
            _placeModel = placeModel;
        }

        public List<Place> GetAllPlaces()
        {
            return _placeModel.GetAllPlaces();
        }

        public bool DeletePlace(Place place)
        {
            return _placeModel.DeletePlace(place);
        }

        public void UpdatePlace(Place place)
        {
            _placeModel.UpdatePlace(place);
        }

        public void AddPlace(Place place)
        {
            _placeModel.AddPlace(place);
        }

        public void ShowDialog()
        {
            _placeView.Places.Clear();
            var items = _placeModel.GetAllPlaces();
            foreach (var item in items)
            {
                _placeView.Places.Add(item);
            }

            _placeView.ShowDialog();
        }

        public void RefreshData()
        {
            _placeView.Places.Clear();
            var items = GetAllPlaces();
            foreach (var item in items)
            {
                _placeView.Places.Add(item);
            }
        }
    }
}
