using System.Collections.Generic;
using MaterialDto = Elrob.Terminal.Dto.Material;
using MaterialDomain = Elrob.Common.Domain.Material;

namespace Elrob.Terminal.Converters.Interfaces
{
    public interface IMaterialConverter
    {
        List<MaterialDto> Convert(List<MaterialDomain> input);

        MaterialDomain Convert(MaterialDto input);
    }
}
