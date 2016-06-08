using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;

namespace Elrob.Terminal.Model.Implementations.Main
{
    using Elrob.Common.DataAccess;

    public class LoginModel : ILoginModel
    {
        private readonly IUserConverter _userConverter;

        private ISessionFactory _sessionFactory;

        public LoginModel(IUserConverter userConverter, ISessionFactory sessionFactory)
        {
            if (userConverter == null) throw new ArgumentNullException(nameof(userConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _userConverter = userConverter;
            this._sessionFactory = sessionFactory;
        }

        public User GetUserByLoginName(string loginName)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var userDomain = session.QueryOver<Elrob.Common.Domain.User>()
                    .Where(x => x.LoginName == loginName)
                    .SingleOrDefault();

                var userDto = _userConverter.Convert(userDomain);

                return userDto;
            }
        }
    }
}
