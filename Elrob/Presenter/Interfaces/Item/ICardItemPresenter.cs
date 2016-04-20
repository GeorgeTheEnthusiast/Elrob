using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface ICardItemPresenter
    {
        DialogResult ShowDialog(Card card);

        void AcceptChanges();
    }
}
