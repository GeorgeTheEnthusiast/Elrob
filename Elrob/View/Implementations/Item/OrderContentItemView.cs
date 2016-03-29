using System.Linq;
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
    public partial class OrderContentItemView : Form, IOrderContentItemView
    {
        private readonly IOrderContentItemPresenter _orderContentItemPresenter;
        
        private OrderContent _orderContent;
        private Order _order;

        public OrderContentItemView()
        {
            _orderContentItemPresenter = new OrderContentItemPresenter(this, Program.Kernel.Get<IOrderContentItemModel>());
            
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public OrderContent OrderContent => new OrderContent()
        {
            Name = textBoxName.Text.Trim(),
            Order = _order,
            DocumentNumber = textBoxDocumentNumber.Text.Trim(),
            Material = comboBoxMaterial.SelectedItem as Material,
            Place = comboBoxPlaces.SelectedItem as Place,
            Height = numericUpDownHeight.Value,
            Width = numericUpDownWidth.Value,
            PackageQuantity = (int)numericUpDownPackageQuantity.Value,
            Thickness = numericUpDownThickness.Value,
            ToComplete = (int)numericUpDownToComplete.Value,
            UnitWeight = numericUpDownUnitWeight.Value,
            Id = _orderContent == null ? 0 : _orderContent.Id
        };

        public ComboBox ComboBoxPlace => comboBoxPlaces;

        public DialogResult ShowDialog(Order order, OrderContent orderContent, Place place)
        {
            _orderContent = orderContent;
            _order = order;

            var materials = _orderContentItemPresenter.GetAllMaterials();
            var places = _orderContentItemPresenter.GetAllPlaces(place);

            comboBoxMaterial.DataSource = materials;
            comboBoxPlaces.DataSource = places;

            if (_orderContent != null)
            {
                comboBoxMaterial.SelectedIndex = materials.IndexOf(materials.FirstOrDefault(x => x.Id == orderContent.Material.Id));
                comboBoxPlaces.SelectedIndex = places.IndexOf(places.FirstOrDefault(x => x.Id == orderContent.Place.Id));

                textBoxName.Text = _orderContent.Name;
                textBoxDocumentNumber.Text = _orderContent.DocumentNumber;
                numericUpDownHeight.Value = _orderContent.Height.GetValueOrDefault();
                numericUpDownWidth.Value = _orderContent.Width.GetValueOrDefault();
                numericUpDownPackageQuantity.Value = _orderContent.PackageQuantity;
                numericUpDownThickness.Value = _orderContent.Thickness.GetValueOrDefault();
                numericUpDownToComplete.Value = _orderContent.ToComplete;
                numericUpDownUnitWeight.Value = _orderContent.UnitWeight;
            }

            return base.ShowDialog();
        }
    }
}
