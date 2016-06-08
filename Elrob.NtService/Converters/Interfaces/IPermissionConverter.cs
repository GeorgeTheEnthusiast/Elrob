namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.NtService.Dto;

    public interface IPermissionConverter
    {
        List<Permission> Convert(List<Elrob.Common.Domain.Permission> input);

        List<Elrob.Common.Domain.Permission> Convert(List<Permission> input);
    }
}
