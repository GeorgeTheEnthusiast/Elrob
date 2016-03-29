using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Domain;
using UserDto = Elrob.Terminal.Dto.User;
using UserDomain = Elrob.Terminal.Domain.User;

namespace Elrob.Terminal.Converters
{
    public interface IPermissionGroupConverter
    {
        List<Dto.PermissionGroup> Convert(List<PermissionGroup> input);

        List<PermissionGroup> Convert(List<Dto.PermissionGroup> input);

        PermissionGroup Convert(Dto.PermissionGroup input);
    }
}
