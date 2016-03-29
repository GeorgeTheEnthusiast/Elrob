using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IPlaceModel
    {
        List<Place> GetAllPlaces();

        void AddPlace(Place place);

        bool DeletePlace(Place place);

        void UpdatePlace(Place place);
    }
}
