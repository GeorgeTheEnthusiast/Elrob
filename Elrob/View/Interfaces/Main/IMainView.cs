using System.Windows.Forms;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IMainView
    {
        DialogResult ShowDialog();

        bool UseWaitCursor { get; set; }

        Button ButtonImport { get; }
    }
}
