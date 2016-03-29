using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IGroupItemPresenter
    {
        DialogResult ShowDialog(Group group);

        void AcceptChanges(bool IsInEditMode);
    }
}
