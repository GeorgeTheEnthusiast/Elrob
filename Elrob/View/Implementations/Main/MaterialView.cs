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
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class MaterialView : Form, IMaterialView
    {
        private readonly IMaterialPresenter _materialPresenter;
        private IMaterialItemPresenter _materialItemPresenter;

        public MaterialView()
        {
            _materialPresenter = new MaterialPresenter(this, Program.Kernel.Get<IMaterialModel>());

            InitializeComponent();

            dataGridViewMaterials.AutoGenerateColumns = false;
            dataGridViewMaterials.DataSource = Materials = new CustomBindingList<Material>();

            buttonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_EditRows);
            buttonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_AddRows);
            buttonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_DeleteRows);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        public CustomBindingList<Material> Materials { get; set; }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _materialItemPresenter = Program.Kernel.Get<IMaterialItemPresenter>();
            _materialItemPresenter.ShowDialog(null);
            _materialPresenter.RefreshData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Material>(dataGridViewMaterials);

            if (selectedRow == default(Material))
            {
                return;
            }

            _materialItemPresenter = Program.Kernel.Get<IMaterialItemPresenter>();
            _materialItemPresenter.ShowDialog(selectedRow);
            _materialPresenter.RefreshData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = Helpers.GetSelectedRow<Material>(dataGridViewMaterials);

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
                _materialPresenter.DeleteMaterial(selectedRow);
                _materialPresenter.RefreshData();
            }
        }

        public DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        private void dataGridViewMaterials_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewMaterials, e.ColumnIndex);
        }
    }
}
