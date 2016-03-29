using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Choose
{
    public interface IPlaceChooseView
    {
        Place Place { get; }

        ComboBox ComboBoxPlaces { get; }

        DialogResult ShowDialog();
    }
}
