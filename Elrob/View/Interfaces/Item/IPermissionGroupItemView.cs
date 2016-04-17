using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IPermissionGroupItemView
    {
        DialogResult ShowDialog();

        BindingList<Permission> Permissions { get; set; }

        CheckedListBox CheckedListBoxPermissions { get; }

        Group Group { get; set; }
    }
}
