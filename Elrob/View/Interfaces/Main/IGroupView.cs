using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IGroupView
    {
        DialogResult ShowDialog();

        CustomBindingList<Group> Groups { get; set; }

        DataGridView DataGridViewGroups { get; }

        Button ButtonEdit { get; }

        Button ButtonAdd { get; }

        Button ButtonDelete { get; }

        Button ButtonPermissionGroup { get; }
    }
}
