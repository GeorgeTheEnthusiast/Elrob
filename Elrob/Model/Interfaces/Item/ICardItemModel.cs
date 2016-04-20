using CardDto = Elrob.Terminal.Dto.Card;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface ICardItemModel
    {
        void UpdateCard(CardDto card);
    }
}
