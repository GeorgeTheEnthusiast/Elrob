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

        public bool IsInEditMode { get; set; }

        public Place PassedPlace { get; set; }

        public TextBox TextBoxName => textBoxName;

        public ErrorProvider NameErrorProvider => nameErrorProvider;

        public PlaceItemView()
        {
            _placeItemPresenter = new PlaceItemPresenter(this, Program.Kernel.Get<IPlaceItemModel>());

            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _placeItemPresenter.AcceptChanges();
        }

        public Place Place => new Place()
        {
            Name = textBoxName.Text.Trim(),
            Id = PassedPlace?.Id ?? 0
        };
    }
}
