using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IOrderPreviewItemView
    {
        DialogResult ShowDialog(Order order, OrderContent orderContent, List<Material> materials, List<Place> places);

        OrderContent OrderContent { get; }

        ComboBox ComboBoxPlace { get; }
    }
}
