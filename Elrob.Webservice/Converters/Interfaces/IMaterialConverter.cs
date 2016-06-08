using MaterialDto = Elrob.Webservice.Dto.Material;
using MaterialDomain = Elrob.Common.Domain.Material;

namespace Elrob.Webservice.Converters.Interfaces
{
    using System.Collections.Generic;

    public interface IMaterialConverter
    {
        List<MaterialDto> Convert(List<MaterialDomain> input);

        MaterialDomain Convert(MaterialDto input);
    }
}
