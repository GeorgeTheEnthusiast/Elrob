using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces
{
    public interface ICardReaderPresenter
    {
        Card EnteredCard { get; set; }

        DialogResult ShowDialog();
    }
}
