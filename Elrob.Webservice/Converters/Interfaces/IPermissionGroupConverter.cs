namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.Common.Domain;

    public interface IPermissionGroupConverter
    {
        List<Dto.PermissionGroup> Convert(List<PermissionGroup> input);

        List<PermissionGroup> Convert(List<Dto.PermissionGroup> input);

        PermissionGroup Convert(Dto.PermissionGroup input);
    }
}
