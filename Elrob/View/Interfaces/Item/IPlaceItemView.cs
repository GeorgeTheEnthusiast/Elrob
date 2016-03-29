using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IPlaceItemView
    {
        DialogResult ShowDialog(Place place);

        Place Place { get; }
    }
}
