using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IPlacePresenter
    {
        DialogResult ShowDialog();

        void RefreshData();

        void ShowAddForm();

        void ShowEditForm();

        void DeletePlace();

        void SetPermissions();
    }
}
