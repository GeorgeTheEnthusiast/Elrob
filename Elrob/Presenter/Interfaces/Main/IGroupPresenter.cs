using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IGroupPresenter
    {
        List<Group> GetAllGroups();

        bool DeleteGroup(Group group);

        void ShowDialog();

        void RefreshData();
    }
}
