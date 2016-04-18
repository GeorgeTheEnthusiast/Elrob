using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class PlacePresenter : IPlacePresenter
    {
        private readonly IPlaceView _placeView;
        private readonly IPlaceModel _placeModel;
        private IPlaceItemPresenter _placeItemPresenter;

        public PlacePresenter(IPlaceView placeView, IPlaceModel placeModel)
        {
            if (placeView == null) throw new ArgumentNullException("placeView");
            if (placeModel == null) throw new ArgumentNullException("placeModel");

            _placeView = placeView;
            _placeModel = placeModel;
        }

        public DialogResult ShowDialog()
        {
            _placeView.Places.Clear();
            var items = _placeModel.GetAllPlaces();
            foreach (var item in items)
            {
                _placeView.Places.Add(item);
            }

            return _placeView.ShowDialog();
        }

        public void RefreshData()
        {
            _placeView.Places.Clear();
            var items = _placeModel.GetAllPlaces();
            foreach (var item in items)
            {
                _placeView.Places.Add(item);
            }
        }

        public void ShowAddForm()
        {
            _placeItemPresenter = Program.Kernel.Get<IPlaceItemPresenter>();
            var dialogResult = _placeItemPresenter.ShowDialog(null);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<Place>(_placeView.DataGridViewPlaces);

            if (selectedRow == default(Place))
            {
                return;
            }

            _placeItemPresenter = Program.Kernel.Get<IPlaceItemPresenter>();
            var dialogResult = _placeItemPresenter.ShowDialog(selectedRow);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void DeletePlace()
        {
            var selectedRow = Helpers.GetSelectedRow<Place>(_placeView.DataGridViewPlaces);

            if (selectedRow == default(Place))
            {
                return;
            }

            if (MessageBox.Show(
                "Usunięcie tej placówki spowoduje również usunięcie jej wpisów w zamówieniach. Czy aby napewno chcesz usunąć tą placówkę?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _placeModel.DeletePlace(selectedRow);
                RefreshData();
            }
        }

        public void SetPermissions()
        {
            _placeView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_EditRows);
            _placeView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_AddRows);
            _placeView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_DeleteRows);
        }
    }
}
