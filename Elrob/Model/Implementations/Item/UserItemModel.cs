using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class UserItemModel : IUserItemModel
    {
        private readonly IUserConverter _userConverter;
        private readonly IGroupConverter _groupConverter;

        public UserItemModel( 
            IUserConverter userConverter,
            IGroupConverter groupConverter)
        {
            if (userConverter == null) throw new ArgumentNullException("userConverter");
            if (groupConverter == null) throw new ArgumentNullException("groupConverter");

            _userConverter = userConverter;
            _groupConverter = groupConverter;
        }

        public void AddUser(dto.User user)
        {
            var domain = _userConverter.Convert(user);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateUser(dto.User user)
        {
            var domain = _userConverter.Convert(user);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public bool IsUserExist(string loginName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.User>()
                    .Where(x => x.LoginName == loginName)
                    .RowCount();

                return rowCount > 0;
            }
        }

        public List<dto.Group> GetAllGroups()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Group>()
                    .List()
                    .ToList();

                var result = _groupConverter.Convert(domain);

                return result;
            }
        }
    }
}
