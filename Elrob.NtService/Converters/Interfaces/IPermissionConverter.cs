namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.NtService.Dto;

    public interface IPermissionConverter
    {
        List<Permission> Convert(List<Domain.Permission> input);

        List<Domain.Permission> Convert(List<Permission> input);
    }
}
