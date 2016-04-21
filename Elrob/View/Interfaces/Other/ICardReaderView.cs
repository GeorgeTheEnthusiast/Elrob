using System.Windows.Forms;

namespace Elrob.Terminal.View.Interfaces.Other
{
    public interface ICardReaderView
    {
        string EnteredText { get; set; }

        DialogResult ShowDialog();
    }
}
