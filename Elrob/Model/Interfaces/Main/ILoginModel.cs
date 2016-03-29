using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface ILoginModel
    {
        User GetUserByLoginName(string loginName);
    }
}
