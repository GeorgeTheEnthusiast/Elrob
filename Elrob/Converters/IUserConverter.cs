using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDto = Elrob.Terminal.Dto.User;
using UserDomain = Elrob.Terminal.Domain.User;

namespace Elrob.Terminal.Converters
{
    public interface IUserConverter
    {
        UserDto Convert(UserDomain input);

        List<UserDto> Convert(List<UserDomain> input);

        UserDomain Convert(UserDto input);
    }
}
