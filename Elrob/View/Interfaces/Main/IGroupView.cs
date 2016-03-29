using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Main
{
    public interface IGroupView
    {
        DialogResult ShowDialog();

        CustomBindingList<Group> Groups { get; set; }
    }
}
