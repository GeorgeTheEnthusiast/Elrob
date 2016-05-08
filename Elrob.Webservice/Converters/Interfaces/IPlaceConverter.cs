namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.Webservice.Dto;

    public interface IPlaceConverter
    {
        List<Place> Convert(List<Domain.Place> input);

        Domain.Place Convert(Place place);

        Place Convert(Domain.Place place);
    }
}
