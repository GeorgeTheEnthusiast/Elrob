using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IOrderContentItemModel
    {
        void AddOrderContnt(OrderContent orderContent);

        void UpdateOrderContent(OrderContent orderContent);

        List<Material> GetAllMaterials();

        List<Place> GetAllPlaces();
    }
}
