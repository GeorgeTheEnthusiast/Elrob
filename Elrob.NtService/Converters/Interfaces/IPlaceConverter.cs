namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.NtService.Dto;

    public interface IPlaceConverter
    {
        List<Place> Convert(List<Domain.Place> input);

        Domain.Place Convert(Place place);

        Place Convert(Domain.Place place);
    }
}
