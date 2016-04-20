using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IMaterialView
    {
        DialogResult ShowDialog();

        CustomBindingList<Material> Materials { get; set; }

        DataGridView DataGridViewMaterials { get; }

        Button ButtonEdit { get; }

        Button ButtonAdd { get; }

        Button ButtonDelete { get; }
    }
}
