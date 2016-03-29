using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IPermissionGroupPresenter
    {
        List<PermissionGroup> GetPermissionGroupsByGroupId(int groupId);

        void DeletePermissionGroup(PermissionGroup permissionGroup);

        DialogResult ShowDialog(Group group);

        void RefreshData(Group group);
    }
}
