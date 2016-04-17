using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IOrderPreviewItemPresenter
    {
        DialogResult ShowDialog(Order order, OrderContent orderContent, List<Material> materials, List<Place> places);
        
        OrderContent OrderContent { get; }
    }
}
