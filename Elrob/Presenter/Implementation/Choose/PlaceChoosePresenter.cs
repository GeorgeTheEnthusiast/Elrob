using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Choose;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Choose
{
    public class PlaceChoosePresenter : IPlaceChoosePresenter
    {
        private readonly IPlaceChooseView _placeChooseView;
        private readonly IPlaceChooseModel _placeChooseModel;

        public PlaceChoosePresenter(IPlaceChooseView placeChooseView, IPlaceChooseModel placeChooseModel)
        {
            if (placeChooseView == null) throw new ArgumentNullException("placeChooseView");
            if (placeChooseModel == null) throw new ArgumentNullException("placeChooseModel");

            _placeChooseView = placeChooseView;
            _placeChooseModel = placeChooseModel;
        }

        public Place ChoosedPlace => _placeChooseView.Place;

        private List<Place> GetAllPlaces()
        {
            var places = _placeChooseModel.GetAllPlaces();

            bool addAllPlaces = UserFactory.Instance.HasPermission(PermissionType.PlaceChoose_All);

            if (addAllPlaces)
            {
                places.Add(new Place
                {
                    Id = int.MaxValue,
                    Name = "Wszystkie"
                });
            }

            return places;
        }

        public DialogResult ShowDialog()
        {
            _placeChooseView.ComboBoxPlaces.DataSource = GetAllPlaces();

            return _placeChooseView.ShowDialog();
        }

        public void ShowMainView()
        {
            IMainPresenter mainPresenter = Program.Kernel.Get<IMainPresenter>();
            mainPresenter.ShowDialog();
        }
    }
}
