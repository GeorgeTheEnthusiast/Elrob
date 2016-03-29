using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IPlaceItemModel
    {
        void AddPlace(Place place);

        void UpdatePlace(Place place);

        bool IsPlaceExist(string placeName);
    }
}
