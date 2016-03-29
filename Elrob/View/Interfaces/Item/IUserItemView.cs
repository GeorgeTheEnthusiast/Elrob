using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IUserItemView
    {
        DialogResult ShowDialog(User user);

        User User { get; }
    }
}
