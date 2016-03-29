using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Choose
{
    public interface IOrderContentChooseModel
    {
        List<OrderContent> GetOrderContentsByOrderAndPlace(Order order, Place place);

        List<OrderContent> GetOrderContentsByOrder(Order order);
    }
}
