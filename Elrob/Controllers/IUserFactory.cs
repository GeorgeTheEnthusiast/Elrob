using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Controllers
{
    public interface IUserFactory
    {
        void SetUser(User user);

        bool HasPermission(PermissionType permissionType);
    }
}
