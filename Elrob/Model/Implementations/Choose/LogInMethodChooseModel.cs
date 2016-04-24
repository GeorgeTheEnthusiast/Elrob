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

        public LogInMethodChooseModel(IUserConverter userConverter)
        {
            if (userConverter == null) throw new ArgumentNullException("userConverter");

            _userConverter = userConverter;
        }

        public dto.User GetUserByCard(dto.Card card)
        {
            using (var session = NHibernateHelper.OpenSession())
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
