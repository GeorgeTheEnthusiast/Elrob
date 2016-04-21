using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
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
    public partial class OrderPreviewItemView : Form, IOrderPreviewItemView
    {
        private readonly IOrderPreviewItemPresenter _orderPreviewItemPresenter;
        
        public OrderContent PassedOrderContent { get; set; }

        public Order PassedOrder { get; set; }

        public ComboBox ComboBoxMaterial => comboBoxMaterial;

        public ComboBox ComboBoxPlace => comboBoxPlaces;

        public TextBox TextBoxName => textBoxName;

        public TextBox TextBoxDocumentNumber => textBoxDocumentNumber;

        public NumericUpDown NumericUpDownHeight => numericUpDownHeight;

        public NumericUpDown NumericUpDownWidth => numericUpDownWidth;

        public NumericUpDown NumericUpDownPackageQuantity => numericUpDownPackageQuantity;

        public NumericUpDown NumericUpDownThickness => numericUpDownThickness;

        public NumericUpDown NumericUpDownToComplete => numericUpDownToComplete;

        public NumericUpDown NumericUpDownUnitWeight => numericUpDownUnitWeight;

        public OrderPreviewItemView()
        {
            _orderPreviewItemPresenter = new OrderPreviewItemPresenter(this, Program.Kernel.Get<IOrderPreviewItemModel>());
            
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
            Order = PassedOrder,
            DocumentNumber = textBoxDocumentNumber.Text.Trim(),
            Material = comboBoxMaterial.SelectedItem as Material,
            Place = comboBoxPlaces.SelectedItem as Place,
            Height = numericUpDownHeight.Value,
            Width = numericUpDownWidth.Value,
            PackageQuantity = (int)numericUpDownPackageQuantity.Value,
            Thickness = numericUpDownThickness.Value,
            ToComplete = (int)numericUpDownToComplete.Value,
            UnitWeight = numericUpDownUnitWeight.Value,
            Id = PassedOrderContent == null ? 0 : PassedOrderContent.Id
        };

        private void control_Click(object sender, System.EventArgs e)
        {
            OnScreenKeyboardController.ShowOnScreenKeyboard();
        }
    }
}
