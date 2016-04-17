using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IGroupPresenter
    {
        void ShowDialog();

        void RefreshData();

        void ShowGroupEditForm();

        void ShowGroupAddForm();

        void ShowPermissionGroupForm();

        void DeleteGroup();

        void SetPermissions();
    }
}
