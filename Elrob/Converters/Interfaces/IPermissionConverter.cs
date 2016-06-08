using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IPermissionConverter
    {
        List<Permission> Convert(List<Elrob.Common.Domain.Permission> input);

        List<Elrob.Common.Domain.Permission> Convert(List<Permission> input);
    }
}
