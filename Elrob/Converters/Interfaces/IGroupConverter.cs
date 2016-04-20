using System.Collections.Generic;
using Elrob.Terminal.Domain;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IGroupConverter
    {
        List<Dto.Group> Convert(List<Group> input);

        Group Convert(Dto.Group group);
    }
}
