using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Choose
{
    public interface IOrderChooseView
    {
        Order Order { get; }

        DialogResult ShowDialog();
    }
}
