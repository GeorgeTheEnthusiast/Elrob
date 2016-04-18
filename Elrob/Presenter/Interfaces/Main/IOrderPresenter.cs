using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderPresenter
    {
        void ShowDialog();

        void RefreshData(Place place);

        void SetPermissions();

        void ShowAddForm();

        void ShowEditForm();

        void DeleteOrder();

        void ShowOrderContentForm();
    }
}
