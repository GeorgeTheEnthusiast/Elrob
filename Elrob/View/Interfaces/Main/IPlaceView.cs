using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IPlaceView
    {
        DialogResult ShowDialog();

        CustomBindingList<Place> Places { get; set; }

        DataGridView DataGridViewPlaces { get; }

        Button ButtonEdit { get; }

        Button ButtonAdd { get; }

        Button ButtonDelete { get; }
    }
}
