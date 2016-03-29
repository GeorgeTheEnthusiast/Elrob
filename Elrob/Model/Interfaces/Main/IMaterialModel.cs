using System.Collections.Generic;
using MaterialDto = Elrob.Terminal.Dto.Material;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IMaterialModel
    {
        List<MaterialDto> GetAllMaterials();

        bool DeleteMaterial(MaterialDto material);
    }
}
