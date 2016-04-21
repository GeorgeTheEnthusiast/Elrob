using System;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Choose;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Choose;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Choose
{
    public partial class PlaceChooseView : Form, IPlaceChooseView
    {
        public PlaceChooseView()
        {
            InitializeComponent();
            Icon = Resources.purchase_order;
        }

        public Place Place => comboBoxPlaces.SelectedItem as Place;

        public ComboBox ComboBoxPlaces => comboBoxPlaces;

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
