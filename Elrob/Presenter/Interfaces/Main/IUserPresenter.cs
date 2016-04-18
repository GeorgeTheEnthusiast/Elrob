using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IUserPresenter
    {
        List<User> GetAllUsers();

        bool DeleteUser(User user);

        DialogResult ShowDialog();

        void RefreshData();

        void ShowAddForm();

        void ShowEditForm();

        void DeleteUser();

        void SetPermissions();
    }
}
