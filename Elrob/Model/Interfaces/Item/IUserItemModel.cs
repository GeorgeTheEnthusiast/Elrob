using System.Collections.Generic;
using System.Reflection;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IUserItemModel
    {
        void AddUser(User user);

        void UpdateUser(User user);

        bool IsUserExist(string loginName);

        List<Group> GetAllGroups();

        List<Card> GetAllCards();

        bool IsCardIsUnique(int cardId, int userId);
    }
}
