using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class PermissionGroupItemModel : IPermissionGroupItemModel
    {
        private readonly IPermissionGroupConverter _permissionGroupConverter;
        private readonly IPermissionConverter _permissionConverter;
        private readonly IGroupConverter _groupConverter;

        public PermissionGroupItemModel( 
            IPermissionGroupConverter permissionGroupConverter, 
            IPermissionConverter permissionConverter,
            IGroupConverter groupConverter)
        {
            if (permissionGroupConverter == null) throw new ArgumentNullException("permissionGroupConverter");
            if (permissionConverter == null) throw new ArgumentNullException("permissionConverter");
            if (groupConverter == null) throw new ArgumentNullException("groupConverter");

            _permissionGroupConverter = permissionGroupConverter;
            _permissionConverter = permissionConverter;
            _groupConverter = groupConverter;
        }

        public void MergePermissionGroup(dto.Group @group, List<dto.Permission> permissions)
        {
            var domainPermissions = _permissionConverter.Convert(permissions);
            var domainGroup = _groupConverter.Convert(group);
            int groupId = group.Id;

            using (var session = NHibernateHelper.OpenSession())
            {
                var permissionGroupsOldState = session.QueryOver<Domain.PermissionGroup>()
                    .Where(x => x.Group.Id == groupId)
                    .List()
                    .ToList();

                foreach (var newState in domainPermissions)
                {
                    if (permissionGroupsOldState.Any(old => old.Permission.Id == newState.Id))
                    {

                    }
                    else
                    {
                        Domain.PermissionGroup newRow = new domain.PermissionGroup()
                        {
                            Group = domainGroup,
                            Permission = newState
                        };
                        session.Save(newRow);
                    }
                }

                permissionGroupsOldState.RemoveAll(x => domainPermissions.Any(y => y.Id == x.Permission.Id));
                
                foreach (var row in permissionGroupsOldState)
                {
                    session.Delete(row);
                }

                session.Flush();
            }
        }

        public List<dto.Permission> GetAllPermissions()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Permission>()
                    .OrderBy(x => x.Name)
                    .Asc
                    .List()
                    .ToList();

                var dto = _permissionConverter.Convert(domain);

                return dto;
            }
        }
    }
}
