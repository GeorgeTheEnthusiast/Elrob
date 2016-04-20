using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class GroupModel : IGroupModel
    {
        private readonly IGroupConverter _groupConverter;

        public GroupModel( 
            IGroupConverter groupConverter)
        {
            if (groupConverter == null) throw new ArgumentNullException("groupConverter");

            _groupConverter = groupConverter;
        }

        public List<dto.Group> GetAllGroups()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Group>()
                    .List()
                    .ToList();

                var dto = _groupConverter.Convert(domain);

                return dto;
            }
        }

        public bool DeleteGroup(dto.Group group)
        {
            var domain = _groupConverter.Convert(group);

            using (var session = NHibernateHelper.OpenSession())
            {
                var existInUser = session.QueryOver<domain.User>()
                    .Where(x => x.Group.Id == group.Id)
                    .RowCount();

                if (existInUser > 0)
                {
                    return false;
                }

                session.Delete(domain);
                session.Flush();

                return true;
            }
        }
    }
}
