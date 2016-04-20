using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces
{
    public interface ICardReaderView
    {
        string EnteredText { get; set; }

        DialogResult ShowDialog();
    }
}
