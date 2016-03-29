using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IOrderContentItemPresenter
    {
        DialogResult ShowDialog(Order order, OrderContent orderContent, Place place);

        List<Material> GetAllMaterials();

        List<Place> GetAllPlaces(Place place);

        OrderContent OrderContent { get; }
    }
}
