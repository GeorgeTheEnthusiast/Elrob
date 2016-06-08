using System.Collections.Generic;
using UserDto = Elrob.Terminal.Dto.User;
using UserDomain = Elrob.Common.Domain.User;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IUserConverter
    {
        UserDto Convert(UserDomain input);

        List<UserDto> Convert(List<UserDomain> input);

        UserDomain Convert(UserDto input);
    }
}
