using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Domain;
using Elrob.Terminal.Model.Interfaces.Choose;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Choose
{
    public class LogInMethodChooseModel : ILogInMethodChooseModel
    {
        private readonly IUserConverter _userConverter;

        private ISessionFactory _sessionFactory;

        public LogInMethodChooseModel(IUserConverter userConverter, ISessionFactory sessionFactory)
        {
            if (userConverter == null) throw new ArgumentNullException(nameof(userConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _userConverter = userConverter;
            this._sessionFactory = sessionFactory;
        }

        public dto.User GetUserByCard(dto.Card card)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Domain.User>()
                    .JoinQueryOver<Card>(c => c.Card)
                    .Where(x => x.Login == card.Login)
                    .And(x => x.Password == card.Password)
                    .SingleOrDefault();

                var dto = _userConverter.Convert(domain);

                return dto;
            }
        }
    }
}
