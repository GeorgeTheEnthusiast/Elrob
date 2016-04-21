using System.Windows.Forms;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IMainView
    {
        DialogResult ShowDialog();

        bool UseWaitCursor { get; set; }

        Button ButtonImport { get; }

        Button ButtonGroups { get; }

        Button ButtonMaterials { get; }

        Button ButtonOrderProgress { get; }

        Button ButtonOrders { get; }

        Button ButtonPlaces { get; }

        Button ButtonUsers { get; }

        TextBox TextBoxUserName { get; }
    }
}
