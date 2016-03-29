using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Dto;
using FluentNHibernate.Utils;

namespace Elrob.Terminal.Controllers
{
    public class UserFactory : IUserFactory
    {
        public static UserFactory Instance { get; }

        public User LoggedUser { get; private set; }

        static UserFactory()
        {
            if (Instance == null)
            {
                Instance = new UserFactory();
            }
        }

        public void SetUser(User user)
        {
            LoggedUser = user;
        }

        public bool HasPermission(PermissionType permissionType)
        {
            return LoggedUser.Group.Permissions.Any(x => x.Id == (int) permissionType);
        }
    }
}
