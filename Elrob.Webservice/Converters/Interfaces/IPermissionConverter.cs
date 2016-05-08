namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.Webservice.Dto;

    public interface IPermissionConverter
    {
        List<Permission> Convert(List<Domain.Permission> input);

        List<Domain.Permission> Convert(List<Permission> input);
    }
}
