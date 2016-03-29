using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Main
{
    public interface IMainModel
    {
        User GetUserByLoginName(string loginName);
    }
}
