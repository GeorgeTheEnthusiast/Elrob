using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IOrderPreviewItemPresenter
    {
        DialogResult ShowDialog(Order order, OrderContent orderContent, List<Material> materials, List<Place> places);

        List<Material> GetAllMaterials();

        List<Place> GetAllPlaces();

        OrderContent OrderContent { get; }
    }
}
