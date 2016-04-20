using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class MaterialPresenter : IMaterialPresenter
    {
        private readonly IMaterialView _materialView;
        private readonly IMaterialModel _materialModel;
        private IMaterialItemPresenter _materialItemPresenter;

        public MaterialPresenter(IMaterialView materialView, IMaterialModel materialModel)
        {
            if (materialView == null) throw new ArgumentNullException("materialView");
            if (materialModel == null) throw new ArgumentNullException("materialModel");

            _materialView = materialView;
            _materialModel = materialModel;
        }

        public void ShowDialog()
        {
            RefreshData();

            _materialView.ShowDialog();
        }

        public void RefreshData()
        {
            _materialView.Materials.Clear();
            var items = _materialModel.GetAllMaterials();
            foreach (var item in items)
            {
                _materialView.Materials.Add(item);
            }
        }

        public void ShowAddForm()
        {
            _materialItemPresenter = Program.Kernel.Get<IMaterialItemPresenter>();
            var dialogResult = _materialItemPresenter.ShowDialog(null);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<Material>(_materialView.DataGridViewMaterials);

            if (selectedRow == default(Material))
            {
                return;
            }

            _materialItemPresenter = Program.Kernel.Get<IMaterialItemPresenter>();
            var dialogResult = _materialItemPresenter.ShowDialog(selectedRow);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void DeleteMaterial()
        {
            var selectedRow = Helpers.GetSelectedRow<Material>(_materialView.DataGridViewMaterials);

            if (selectedRow == default(Material))
            {
                return;
            }

            if (MessageBox.Show(
                "Usunięcie tego materiału spowoduje również usunięcie jego wpisów w zamówieniach. Czy aby napewno chcesz usunąć ten materiał?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _materialModel.DeleteMaterial(selectedRow);
                RefreshData();
            }
        }

        public void SetPermissions()
        {
            _materialView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_EditRows);
            _materialView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_AddRows);
            _materialView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_DeleteRows);
        }
    }
}
