using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class MaterialItemPresenter : IMaterialItemPresenter
    {
        private readonly IMaterialItemView _materialItemView;
        private readonly IMaterialItemModel _materialItemModel;

        public MaterialItemPresenter(IMaterialItemView materialItemView, IMaterialItemModel materialItemModel)
        {
            if (materialItemView == null) throw new ArgumentNullException("materialItemView");
            if (materialItemModel == null) throw new ArgumentNullException("materialItemModel");

            _materialItemView = materialItemView;
            _materialItemModel = materialItemModel;
        }

        public void AcceptChanges(bool IsInEditMode)
        {
            var orderExists = _materialItemModel.IsMaterialExist(_materialItemView.Material.Name);

            if (orderExists)
            {
                _materialItemView.ErrorProviderName.SetError(_materialItemView.TextBoxName, "Materiał z taką nazwą już istnieje!");
                return;
            }
            else
            {
                _materialItemView.ErrorProviderName.Clear();
            }

            if (_materialItemView.IsInEditMode)
            {
                _materialItemModel.UpdateMaterial(_materialItemView.Material);
            }
            else
            {
                _materialItemModel.AddMaterial(_materialItemView.Material);
            }

            _materialItemView.DialogResult = DialogResult.OK;
        }

        public DialogResult ShowDialog(Material material)
        {
            _materialItemView.PassedMaterial = material;
            _materialItemView.ErrorProviderName.Clear();

            if (_materialItemView.PassedMaterial != null)
            {
                _materialItemView.IsInEditMode = true;
                _materialItemView.TextBoxName.Text = material.Name;
            }
            else
            {
                _materialItemView.IsInEditMode = false;
            }

            return _materialItemView.ShowDialog();
        }
    }
}
