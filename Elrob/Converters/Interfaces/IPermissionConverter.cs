using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IPermissionConverter
    {
        List<Permission> Convert(List<Domain.Permission> input);

        List<Domain.Permission> Convert(List<Permission> input);
    }
}
