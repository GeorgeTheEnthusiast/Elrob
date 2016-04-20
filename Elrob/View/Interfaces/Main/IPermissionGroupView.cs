using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IPermissionGroupView
    {
        DialogResult ShowDialog();

        CustomBindingList<PermissionGroup> PermissionGroups { get; set; }

        Button ButtonChange { get; }

        Button ButtonDelete { get; }

        Group Group { get; set; }

        DataGridView DataGridViewPermissionGroups { get; }

        TextBox TextBoxGroup { get; }
    }
}
