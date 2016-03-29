using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IUserItemPresenter
    {
        void UpdateUser(User user);

        void AddUser(User user);

        DialogResult ShowDialog(User user);

        bool IsUserExist(string loginName);

        List<Group> GetAllGroups();
    }
}
