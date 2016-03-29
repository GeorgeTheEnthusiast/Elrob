using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IUserView
    {
        DialogResult ShowDialog();

        CustomBindingList<User> Users { get; set; }
    }
}
