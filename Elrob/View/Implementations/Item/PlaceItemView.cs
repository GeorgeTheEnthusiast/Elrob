using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class PlaceItemView : Form, IPlaceItemView
    {
        private IPlaceItemPresenter _placeItemPresenter;

        private bool _isInEditMode;

        private Place _place;

        public PlaceItemView()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            var placeExist = _placeItemPresenter.IsPlaceExist(Place.Name);

            if (placeExist)
            {
                nameErrorProvider.SetError(textBoxName, "Placówka z taką nazwą już istnieje!");
                return;
            }
            else
            {
                nameErrorProvider.Clear();
            }

            if (_isInEditMode)
            {
                _placeItemPresenter.UpdatePlace(Place);
            }
            else
            {
                _placeItemPresenter.AddPlace(Place);
            }

            DialogResult = DialogResult.OK;
        }

        public Place Place => new Place()
        {
            Name = textBoxName.Text.Trim(),
            Id = _place?.Id ?? 0
        };

        public DialogResult ShowDialog(Place place)
        {
            _placeItemPresenter = new PlaceItemPresenter(this, Program.Kernel.Get<IPlaceItemModel>());
            _place = place;
            nameErrorProvider.Clear();

            if (_place != null)
            {
                _isInEditMode = true;
                textBoxName.Text = _place.Name;
            }
            else
            {
                _isInEditMode = false;
            }

            return base.ShowDialog();
        }
    }
}
