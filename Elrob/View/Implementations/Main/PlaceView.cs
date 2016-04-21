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
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class PlaceView : Form, IPlaceView
    {
        private readonly IPlacePresenter _placePresenter;

        public PlaceView()
        {
            _placePresenter = new PlacePresenter(this, Program.Kernel.Get<IPlaceModel>());

            InitializeComponent();

            dataGridViewPlaces.AutoGenerateColumns = false;
            dataGridViewPlaces.DataSource = Places = new CustomBindingList<Place>();
            Icon = Resources.purchase_order;

            _placePresenter.SetPermissions();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public CustomBindingList<Place> Places { get; set; }

        public DataGridView DataGridViewPlaces => dataGridViewPlaces;

        public Button ButtonEdit => buttonEdit;

        public Button ButtonAdd => buttonAdd;

        public Button ButtonDelete => buttonDelete;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _placePresenter.ShowAddForm();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _placePresenter.ShowEditForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _placePresenter.DeletePlace();
        }

        private void dataGridViewPlaces_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewPlaces, e.ColumnIndex);
        }
    }
}
