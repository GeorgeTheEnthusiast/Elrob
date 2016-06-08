namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.NtService.Dto;

    public interface IPlaceConverter
    {
        List<Place> Convert(List<Elrob.Common.Domain.Place> input);

        Elrob.Common.Domain.Place Convert(Place place);

        Place Convert(Elrob.Common.Domain.Place place);
    }
}
