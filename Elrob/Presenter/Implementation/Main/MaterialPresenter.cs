using System;
using System.Collections.Generic;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class MaterialPresenter : IMaterialPresenter
    {
        private readonly IMaterialView _materialView;
        private readonly IMaterialModel _materialModel;

        public MaterialPresenter(IMaterialView materialView, IMaterialModel materialModel)
        {
            if (materialView == null) throw new ArgumentNullException("materialView");
            if (materialModel == null) throw new ArgumentNullException("materialModel");

            _materialView = materialView;
            _materialModel = materialModel;
        }

        public List<Material> GetAllMaterials()
        {
            return _materialModel.GetAllMaterials();
        }

        public bool DeleteMaterial(Material material)
        {
            return _materialModel.DeleteMaterial(material);
        }

        public void ShowDialog()
        {
            RefreshData();

            _materialView.ShowDialog();
        }

        public void RefreshData()
        {
            _materialView.Materials.Clear();
            var items = GetAllMaterials();
            foreach (var item in items)
            {
                _materialView.Materials.Add(item);
            }
        }
    }
}
