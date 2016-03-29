using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IUserModel
    {
        List<User> GetAllUsers();

        bool DeleteUser(User user);
    }
}
