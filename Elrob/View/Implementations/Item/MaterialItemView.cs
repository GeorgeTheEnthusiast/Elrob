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

        private bool _isInEditMode;

        private Material _material;

        public MaterialItemView()
        {
            _materialItemPresenter = new MaterialItemPresenter(this, Program.Kernel.Get<IMaterialItemModel>());
            
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            var orderExists = _materialItemPresenter.IsMaterialExist(Material.Name);

            if (orderExists)
            {
                nameErrorProvider.SetError(textBoxName, "Materiał z taką nazwą już istnieje!");
                return;
            }
            else
            {
                nameErrorProvider.Clear();
            }

            if (_isInEditMode)
            {
                _materialItemPresenter.UpdateMaterial(Material);
            }
            else
            {
                _materialItemPresenter.AddMaterial(Material);
            }

            DialogResult = DialogResult.OK;
        }

        public Material Material => new Material()
        {
            Name = textBoxName.Text.Trim(),
            Id = _material?.Id ?? 0
        };

        public DialogResult ShowDialog(Material material)
        {
            _material = material;
            nameErrorProvider.Clear();

            if (_material != null)
            {
                _isInEditMode = true;
                textBoxName.Text = _material.Name;
            }
            else
            {
                _isInEditMode = false;
            }

            return base.ShowDialog();
        }
    }
}
