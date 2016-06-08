using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    using Elrob.Common.DataAccess;

    public class CardItemModel : ICardItemModel
    {
        private readonly ICardConverter _cardConverter;

        private ISessionFactory _sessionFactory;

        public CardItemModel( 
            ICardConverter cardConverter, ISessionFactory sessionFactory)
        {
            if (cardConverter == null) throw new ArgumentNullException(nameof(cardConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _cardConverter = cardConverter;
            this._sessionFactory = sessionFactory;
        }

        public void UpdateCard(dto.Card card)
        {
            var domain = _cardConverter.Convert(card);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
