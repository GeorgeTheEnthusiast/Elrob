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
    public partial class MaterialItemView : Form, IMaterialItemView
    {
        private readonly IMaterialItemPresenter _materialItemPresenter;
        
        public ErrorProvider ErrorProviderName => nameErrorProvider;

        public TextBox TextBoxName => textBoxName;

        public bool IsInEditMode { get; set; }

        public Material PassedMaterial { get; set; }

        public MaterialItemView()
        {
            _materialItemPresenter = new MaterialItemPresenter(this, Program.Kernel.Get<IMaterialItemModel>());
            
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _materialItemPresenter.AcceptChanges(IsInEditMode);
        }

        public Material Material => new Material()
        {
            Name = textBoxName.Text.Trim(),
            Id = PassedMaterial?.Id ?? 0
        };
    }
}
