using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Choose
{
    public interface IPlaceChooseModel
    {
        List<Place> GetAllPlaces();
    }
}
