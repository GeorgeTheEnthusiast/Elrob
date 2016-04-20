using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface ICardView
    {
        DialogResult ShowDialog();

        CustomBindingList<Card> Cards { get; set; }

        DataGridView DataGridViewCards { get; }

        Button ButtonAdd { get; }

        Button ButtonDelete { get; }

        Button ButtonEdit { get; }
    }
}
