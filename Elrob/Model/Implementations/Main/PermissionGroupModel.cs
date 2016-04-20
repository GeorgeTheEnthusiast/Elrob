using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class PermissionGroupModel : IPermissionGroupModel
    {
        private readonly IPermissionGroupConverter _permissionGroupConverter;

        public PermissionGroupModel( 
            IPermissionGroupConverter permissionGroupConverter)
        {
            if (permissionGroupConverter == null) throw new ArgumentNullException("permissionGroupConverter");

            _permissionGroupConverter = permissionGroupConverter;
        }

        public List<dto.PermissionGroup> GetPermissionGroupsByGroupId(int groupId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.PermissionGroup>()
                    .Where(x => x.Group.Id == groupId)
                    .List()
                    .OrderBy(x => x.Permission.Name)
                    .ToList();

                var dto = _permissionGroupConverter.Convert(domain);

                return dto;
            }
        }

        public void DeletePermissionGroup(dto.PermissionGroup permissionGroup)
        {
            var domain = _permissionGroupConverter.Convert(permissionGroup);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Delete(domain);
                session.Flush();
            }
        }
    }
}
