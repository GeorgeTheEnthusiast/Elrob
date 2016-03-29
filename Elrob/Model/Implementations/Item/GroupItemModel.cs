using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class GroupItemModel : IGroupItemModel
    {
        private readonly IGroupConverter _groupConverter;

        public GroupItemModel( 
            IGroupConverter groupConverter)
        {
            if (groupConverter == null) throw new ArgumentNullException("groupConverter");

            _groupConverter = groupConverter;
        }

        public void AddGroup(dto.Group group)
        {
            var domain = _groupConverter.Convert(group);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateGroup(dto.Group group)
        {
            var domain = _groupConverter.Convert(group);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public bool IsGroupExist(string groupName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Group>()
                    .Where(x => x.Name == groupName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
