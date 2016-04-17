using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IMaterialItemPresenter
    {
        DialogResult ShowDialog(Material material);

        void AcceptChanges();
    }
}
