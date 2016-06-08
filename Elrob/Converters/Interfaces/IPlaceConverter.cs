using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IPlaceConverter
    {
        List<Place> Convert(List<Elrob.Common.Domain.Place> input);

        Elrob.Common.Domain.Place Convert(Place place);
    }
}
