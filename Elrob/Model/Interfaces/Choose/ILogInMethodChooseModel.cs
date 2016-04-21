using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Interfaces.Choose
{
    public interface ILogInMethodChooseModel
    {
        User GetUserByCard(Card card);
    }
}
