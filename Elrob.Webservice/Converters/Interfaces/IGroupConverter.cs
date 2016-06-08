namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    using Elrob.Common.Domain;

    public interface IGroupConverter
    {
        List<Dto.Group> Convert(List<Group> input);

        Group Convert(Dto.Group group);
    }
}
