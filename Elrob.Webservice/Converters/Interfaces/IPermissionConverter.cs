namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    using dto = Elrob.Webservice.Dto;
    using domain = Elrob.Common.Domain;

    public interface IPermissionConverter
    {
        List<dto.Permission> Convert(List<domain.Permission> input);

        List<domain.Permission> Convert(List<dto.Permission> input);
    }
}
