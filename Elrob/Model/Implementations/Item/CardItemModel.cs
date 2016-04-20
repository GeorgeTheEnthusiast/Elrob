using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class CardItemModel : ICardItemModel
    {
        private readonly ICardConverter _cardConverter;

        public CardItemModel( 
            ICardConverter cardConverter)
        {
            if (cardConverter == null) throw new ArgumentNullException("cardConverter");

            _cardConverter = cardConverter;
        }

        public void UpdateCard(dto.Card card)
        {
            var domain = _cardConverter.Convert(card);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }
    }
}
