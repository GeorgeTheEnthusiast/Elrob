using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    using Elrob.Common.DataAccess;

    public class GroupItemModel : IGroupItemModel
    {
        private readonly IGroupConverter _groupConverter;

        private ISessionFactory _sessionFactory;

        public GroupItemModel( 
            IGroupConverter groupConverter, ISessionFactory sessionFactory)
        {
            if (groupConverter == null) throw new ArgumentNullException(nameof(groupConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _groupConverter = groupConverter;
            this._sessionFactory = sessionFactory;
        }

        public void AddGroup(dto.Group group)
        {
            var domain = _groupConverter.Convert(group);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateGroup(dto.Group group)
        {
            var domain = _groupConverter.Convert(group);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public bool IsGroupExist(string groupName)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var rowCount = session.QueryOver<Elrob.Common.Domain.Group>()
                    .Where(x => x.Name == groupName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
