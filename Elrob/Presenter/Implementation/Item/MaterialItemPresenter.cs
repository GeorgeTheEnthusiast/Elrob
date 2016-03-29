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

        public bool IsMaterialExist(string materialName)
        {
            return _materialItemModel.IsMaterialExist(materialName);
        }

        public void UpdateMaterial(Material material)
        {
            _materialItemModel.UpdateMaterial(material);
        }

        public void AddMaterial(Material material)
        {
            _materialItemModel.AddMaterial(material);
        }

        public DialogResult ShowDialog(Material material)
        {
            return _materialItemView.ShowDialog(material);
        }
    }
}
