using System;
using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Main;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class PlaceView : Form, IPlaceView
    {
        private readonly IPlacePresenter _placePresenter;
        private IPlaceItemPresenter _placeItemPresenter;

        public PlaceView()
        {
            _placePresenter = new PlacePresenter(this, Program.Kernel.Get<IPlaceModel>());

            InitializeComponent();

            dataGridViewPlaces.AutoGenerateColumns = false;
            dataGridViewPlaces.DataSource = Places = new CustomBindingList<Place>();

            buttonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_EditRows);
            buttonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_AddRows);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_DeleteRows);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        public CustomBindingList<Place> Places { get; set; }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _placeItemPresenter = Program.Kernel.Get<IPlaceItemPresenter>();
            _placeItemPresenter.ShowDialog(null);
            _placePresenter.RefreshData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Place>(dataGridViewPlaces);

            if (selectedRow == default(Place))
            {
                return;
            }

            _placeItemPresenter = Program.Kernel.Get<IPlaceItemPresenter>();
            _placeItemPresenter.ShowDialog(selectedRow);
            _placePresenter.RefreshData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Place>(dataGridViewPlaces);

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
                _placePresenter.DeletePlace(selectedRow);
                _placePresenter.RefreshData();
            }
        }

        public DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        private void dataGridViewPlaces_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewPlaces, e.ColumnIndex);
        }
    }
}
