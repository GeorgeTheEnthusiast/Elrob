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
    using Elrob.Common.DataAccess;

    public class PermissionGroupModel : IPermissionGroupModel
    {
        private readonly IPermissionGroupConverter _permissionGroupConverter;

        private ISessionFactory _sessionFactory;

        public PermissionGroupModel( 
            IPermissionGroupConverter permissionGroupConverter, ISessionFactory sessionFactory)
        {
            if (permissionGroupConverter == null) throw new ArgumentNullException(nameof(permissionGroupConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _permissionGroupConverter = permissionGroupConverter;
            this._sessionFactory = sessionFactory;
        }

        public List<dto.PermissionGroup> GetPermissionGroupsByGroupId(int groupId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Elrob.Common.Domain.PermissionGroup>()
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

            using (var session = _sessionFactory.OpenSession())
            {
                session.Delete(domain);
                session.Flush();
            }
        }
    }
}
