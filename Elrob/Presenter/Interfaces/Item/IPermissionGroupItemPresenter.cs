using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IPermissionGroupItemPresenter
    {
        void MergePermissionGroup();

        DialogResult ShowDialog(Group group, List<PermissionGroup> permissionGroups);
    }
}
