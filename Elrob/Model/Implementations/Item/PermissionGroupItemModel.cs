using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Common.Domain;

namespace Elrob.Terminal.Model.Implementations.Item
{
    using Elrob.Common.DataAccess;

    public class PermissionGroupItemModel : IPermissionGroupItemModel
    {
        private readonly IPermissionGroupConverter _permissionGroupConverter;
        private readonly IPermissionConverter _permissionConverter;
        private readonly IGroupConverter _groupConverter;

        private ISessionFactory _sessionFactory;

        public PermissionGroupItemModel( 
            IPermissionGroupConverter permissionGroupConverter, 
            IPermissionConverter permissionConverter,
            IGroupConverter groupConverter, ISessionFactory sessionFactory)
        {
            if (permissionGroupConverter == null) throw new ArgumentNullException(nameof(permissionGroupConverter));
            if (permissionConverter == null) throw new ArgumentNullException(nameof(permissionConverter));
            if (groupConverter == null) throw new ArgumentNullException(nameof(groupConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _permissionGroupConverter = permissionGroupConverter;
            _permissionConverter = permissionConverter;
            _groupConverter = groupConverter;
            this._sessionFactory = sessionFactory;
        }

        public void MergePermissionGroup(dto.Group @group, List<dto.Permission> permissions)
        {
            var domainPermissions = _permissionConverter.Convert(permissions);
            var domainGroup = _groupConverter.Convert(group);
            int groupId = group.Id;

            using (var session = _sessionFactory.OpenSession())
            {
                var permissionGroupsOldState = session.QueryOver<Elrob.Common.Domain.PermissionGroup>()
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
                        Elrob.Common.Domain.PermissionGroup newRow = new Elrob.Common.Domain.PermissionGroup()
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
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Elrob.Common.Domain.Permission>()
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
