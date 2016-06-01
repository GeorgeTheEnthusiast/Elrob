using UserDto = Elrob.NtService.Dto.User;
using UserDomain = Elrob.NtService.Domain.User;

namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IUserConverter
    {
        UserDto Convert(UserDomain input);

        List<UserDto> Convert(List<UserDomain> input);

        UserDomain Convert(UserDto input);
    }
}
