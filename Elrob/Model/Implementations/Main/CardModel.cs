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
    public class CardModel : ICardModel
    {
        private readonly ICardConverter _cardConverter;

        public CardModel( 
            ICardConverter cardConverter)
        {
            if (cardConverter == null) throw new ArgumentNullException("cardConverter");

            _cardConverter = cardConverter;
        }

        public List<dto.Card> GetAllCards()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.Card>()
                    .List()
                    .ToList();

                var dto = _cardConverter.Convert(domain);

                return dto;
            }
        }

        public void DeleteCard(dto.Card card)
        {
            var domain = _cardConverter.Convert(card);

            using (var session = NHibernateHelper.OpenSession())
            {
                var existedInUser = session.QueryOver<domain.User>()
                    .Where(x => x.Card.Id == domain.Id)
                    .List()
                    .ToList();

                foreach (var user in existedInUser)
                {
                    user.Card = null;
                    session.Update(user);
                }
                
                session.Delete(domain);
                session.Flush();
            }
        }

        public void AddCard(dto.Card card)
        {
            var domain = _cardConverter.Convert(card);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public bool IsCardExist(string loginName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Card>()
                    .Where(x => x.Login == loginName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
