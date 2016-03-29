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
    public interface IGroupConverter
    {
        List<Dto.Group> Convert(List<Group> input);

        Group Convert(Dto.Group group);
    }
}
