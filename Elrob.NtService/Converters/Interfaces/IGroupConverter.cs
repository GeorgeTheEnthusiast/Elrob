namespace Elrob.NtService.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.NtService.Domain;

    public interface IGroupConverter
    {
        List<Dto.Group> Convert(List<Group> input);

        Group Convert(Dto.Group group);
    }
}
