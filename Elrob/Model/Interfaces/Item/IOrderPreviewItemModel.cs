using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IOrderPreviewItemModel
    {
        List<Material> GetAllMaterials();

        List<Place> GetAllPlaces();
    }
}
