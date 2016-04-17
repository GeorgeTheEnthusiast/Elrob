using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IPlaceItemPresenter
    {
        DialogResult ShowDialog(Place place);

        void AcceptChanges();
    }
}
