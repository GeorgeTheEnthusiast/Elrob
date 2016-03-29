using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class MainModel : IMainModel
    {
        private readonly IUserConverter _userConverter;
        public MainModel(IUserConverter userConverter)
        {
            if (userConverter == null) throw new ArgumentNullException("userConverter");

            _userConverter = userConverter;
        }

        public User GetUserByLoginName(string loginName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var userDomain = session.QueryOver<Domain.User>()
                    .Where(x => x.LoginName == loginName)
                    .SingleOrDefault();

                var userDto = _userConverter.Convert(userDomain);

                return userDto;
            }
        }
    }
}
