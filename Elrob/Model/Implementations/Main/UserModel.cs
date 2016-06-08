using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Common.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    using Elrob.Common.DataAccess;

    public class UserModel : IUserModel
    {
        private readonly IUserConverter _userConverter;

        private ISessionFactory _sessionFactory;

        public UserModel( 
            IUserConverter userConverter, ISessionFactory sessionFactory)
        {
            if (userConverter == null) throw new ArgumentNullException(nameof(userConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _userConverter = userConverter;
            this._sessionFactory = sessionFactory;
        }

        public List<dto.User> GetAllUsers()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Elrob.Common.Domain.User>()
                    .List()
                    .ToList();

                var dto = _userConverter.Convert(domain);

                return dto;
            }
        }
        
        public bool DeleteUser(dto.User user)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domainOrderContent = session.QueryOver<Elrob.Common.Domain.OrderProgress>()
                    .Where(x => x.User.Id == user.Id)
                    .SingleOrDefault();

                if (domainOrderContent != null)
                {
                    return false;
                }

                var domainUser = session.QueryOver<Elrob.Common.Domain.User>()
                    .Where(x => x.Id == user.Id)
                    .SingleOrDefault();

                session.Delete(domainUser);
                session.Flush();
            }

            return true;
        }
    }
}
