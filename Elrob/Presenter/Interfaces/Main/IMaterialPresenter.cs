using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IMaterialPresenter
    {
        void ShowDialog();

        void RefreshData();

        void ShowAddForm();

        void ShowEditForm();

        void DeleteMaterial();
    }
}
