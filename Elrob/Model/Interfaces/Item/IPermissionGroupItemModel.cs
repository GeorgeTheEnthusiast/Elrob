using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IPermissionGroupItemModel
    {
        void MergePermissionGroup(Group group, List<Permission> permissions);

        List<Permission> GetAllPermissions();
    }
}
