using UserDto = Elrob.Webservice.Dto.User;
using UserDomain = Elrob.Webservice.Domain.User;

namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IUserConverter
    {
        UserDto Convert(UserDomain input);

        List<UserDto> Convert(List<UserDomain> input);

        UserDomain Convert(UserDto input);
    }
}
