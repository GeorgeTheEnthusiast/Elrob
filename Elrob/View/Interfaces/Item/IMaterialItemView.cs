using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View.Interfaces.Item
{
    public interface IMaterialItemView
    {
        DialogResult ShowDialog(Material material);

        Material Material { get; }
    }
}
