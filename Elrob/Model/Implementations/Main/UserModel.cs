using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class UserModel : IUserModel
    {
        private readonly IUserConverter _userConverter;

        public UserModel( 
            IUserConverter userConverter)
        {
            if (userConverter == null) throw new ArgumentNullException("userConverter");

            _userConverter = userConverter;
        }

        public List<dto.User> GetAllUsers()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.User>()
                    .List()
                    .ToList();

                var dto = _userConverter.Convert(domain);

                return dto;
            }
        }
        
        public bool DeleteUser(dto.User user)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domainOrderContent = session.QueryOver<domain.OrderProgress>()
                    .Where(x => x.User.Id == user.Id)
                    .SingleOrDefault();

                if (domainOrderContent != null)
                {
                    return false;
                }

                var domainUser = session.QueryOver<domain.User>()
                    .Where(x => x.Id == user.Id)
                    .SingleOrDefault();

                session.Delete(domainUser);
                session.Flush();
            }

            return true;
        }
    }
}
