using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class UserItemModel : IUserItemModel
    {
        private readonly IUserConverter _userConverter;
        private readonly IGroupConverter _groupConverter;
        private readonly ICardConverter _cardConverter;

        public UserItemModel( 
            IUserConverter userConverter,
            IGroupConverter groupConverter,
            ICardConverter cardConverter)
        {
            if (userConverter == null) throw new ArgumentNullException("userConverter");
            if (groupConverter == null) throw new ArgumentNullException("groupConverter");
            if (cardConverter == null) throw new ArgumentNullException("cardConverter");

            _userConverter = userConverter;
            _groupConverter = groupConverter;
            _cardConverter = cardConverter;
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

        public List<dto.Card> GetAllCards()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Card>()
                    .List()
                    .ToList();

                var result = _cardConverter.Convert(domain);

                return result;
            }
        }

        public bool IsCardIsUnique(int cardId, int userId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.User>()
                    .Where(x => x.Card.Id == cardId)
                    .And(x => x.Id != userId)
                    .And(x => x.Card != null)
                    .RowCount();

                return rowCount == 0;
            }
        }
    }
}
