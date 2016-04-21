using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Choose
{
    public interface ILogInMethodChooseView
    {
        DialogResult ShowDialog();

        bool Visible { get; set; }
    }
}
