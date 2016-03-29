using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IPermissionGroupModel
    {
        List<PermissionGroup> GetPermissionGroupsByGroupId(int groupId);

        void DeletePermissionGroup(PermissionGroup permissionGroup);
    }
}
