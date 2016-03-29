using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IGroupModel
    {
        List<Group> GetAllGroups();

        bool DeleteGroup(Group group);
    }
}
