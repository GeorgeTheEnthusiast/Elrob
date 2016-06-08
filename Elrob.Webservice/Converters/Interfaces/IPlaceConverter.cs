namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    using dto = Elrob.Webservice.Dto;
    using domain = Elrob.Common.Domain;

    public interface IPlaceConverter
    {
        List<dto.Place> Convert(List<domain.Place> input);

        domain.Place Convert(dto.Place place);

        dto.Place Convert(domain.Place place);
    }
}
