using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IGroupItemModel
    {
        void AddGroup(Group group);

        void UpdateGroup(Group group);

        bool IsGroupExist(string groupName);
    }
}
