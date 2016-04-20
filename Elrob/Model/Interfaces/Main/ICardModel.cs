using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface ICardModel
    {
        List<Card> GetAllCards();

        void DeleteCard(Card card);

        void AddCard(Card card);

        bool IsCardExist(string loginName);
    }
}
