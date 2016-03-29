using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IPlacePresenter
    {
        List<Place> GetAllPlaces();

        bool DeletePlace(Place place);

        void UpdatePlace(Place place);

        void AddPlace(Place place);

        void ShowDialog();

        void RefreshData();
    }
}
