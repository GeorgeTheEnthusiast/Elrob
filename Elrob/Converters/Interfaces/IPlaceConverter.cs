using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IPlaceConverter
    {
        List<Place> Convert(List<Domain.Place> input);

        Domain.Place Convert(Place place);
    }
}
