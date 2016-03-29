using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IPermissionGroupView
    {
        DialogResult ShowDialog(Group group);

        CustomBindingList<PermissionGroup> PermissionGroups { get; set; }
    }
}
