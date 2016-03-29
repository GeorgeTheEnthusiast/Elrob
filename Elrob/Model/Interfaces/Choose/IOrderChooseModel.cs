using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Choose
{
    public interface IOrderChooseModel
    {
        List<Order> GetAllOrders();
    }
}
