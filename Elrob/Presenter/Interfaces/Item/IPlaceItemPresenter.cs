using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IPlaceItemPresenter
    {
        void UpdatePlace(Place place);

        void AddPlace(Place place);

        DialogResult ShowDialog(Place place);

        bool IsPlaceExist(string placeName);
    }
}
