using System.Collections.Generic;
using Elrob.Terminal.Dto;
using MaterialDto = Elrob.Terminal.Dto.Material;
using OrderDto = Elrob.Terminal.Dto.Order;
using OrderContentDto = Elrob.Terminal.Dto.OrderContent;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IOrderPreviewModel
    {
        List<Place> GetAllPlaces();

        List<MaterialDto> GetAllMaterials();

        void SaveOrder(OrderDto order, List<OrderContentDto> orderContent);

        bool IsOrderExist(string orderName);
    }
}
