using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IPermissionGroupPresenter
    {
        DialogResult ShowDialog(Group group);

        void RefreshData(Group group);

        void SetPermissions();

        void ShowChangeForm();

        void DeletePermissionGroup();
    }
}
