using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Terminal.Tests.Model.Implementations.Choose
{
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;

    using Elrob.Terminal.Common;
    using Elrob.Terminal.Converters.Interfaces;
    using Elrob.Terminal.Domain;
    using Elrob.Terminal.Model.Implementations.Choose;
    using Elrob.Terminal.Model.Interfaces.Choose;

    using NSubstitute;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class LogInMethodChooseModelTests
    {
        private ILogInMethodChooseModel _sut;

        private IUserConverter _userConverter;

        private ISessionFactory _sessionFactory;

        private ISessionFactory _fakeSessionFactory = new FakeSessionFactory();

        private IFixture _fixture = new Fixture();

        [SetUp]
        public void SetUp()
        {
            _userConverter = Substitute.For<IUserConverter>();
            _sessionFactory = Substitute.For<ISessionFactory>();
            _sut = new LogInMethodChooseModel(_userConverter, _fakeSessionFactory);
        }

        [Test]
        public void GetUserByCard_Properly_Returns_Data()
        {
            Domain.User user = _fixture.Create<Domain.User>();

            using (var session = _fakeSessionFactory.OpenSession())
            {
                session.Save(user);
            }

            using (var session = _fakeSessionFactory.OpenSession())
            {
                var users = session.QueryOver<Domain.User>().List().ToList();
            }
        }
    }
}
