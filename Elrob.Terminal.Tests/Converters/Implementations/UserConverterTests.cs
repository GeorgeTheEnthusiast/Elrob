using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Converters.Implementations;
using Elrob.Terminal.Converters.Interfaces;
using DomainEntities = Elrob.Common.Domain;
using DtoEntities = Elrob.Terminal.Dto;
using NUnit.Framework;

namespace Elrob.Terminal.Tests.Converters.Implementations
{
    using Ploeh.AutoFixture;

    using Shouldly;

    [TestFixture]
    class UserConverterTests
    {
        private IUserConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new UserConverter();
        }

        [Test]
        public void NullInputThrowsArgumentNullException()
        {
            List<DomainEntities.User> users = null;
            DtoEntities.User userDto = null;
            DomainEntities.User userDomain = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(users));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(userDto));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(userDomain));
        }

        [Test]
        public void Properly_convert_list_of_users()
        {
            var fixture = new Fixture();
            var users  = fixture.Create<List<DomainEntities.User>>();
            var firstUser = users.First();

            var result = _sut.Convert(users);
            var firstResult = result.First();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(users.Count);
            firstResult.Id.ShouldBe(firstUser.Id);
            firstResult.FirstName.ShouldBe(firstResult.FirstName);
            firstResult.LastName.ShouldBe(firstResult.LastName);
            firstResult.LoginName.ShouldBe(firstResult.LoginName);
            firstResult.Password.ShouldBe(firstResult.Password);
            firstResult.Card.ShouldNotBeNull();
            firstResult.Card.Id.ShouldBe(firstResult.Card.Id);
            firstResult.Card.Login.ShouldBe(firstResult.Card.Login);
            firstResult.Card.Name.ShouldBe(firstResult.Card.Name);
            firstResult.Card.Password.ShouldBe(firstResult.Card.Password);
            firstResult.Group.ShouldNotBeNull();
            firstResult.Group.Id.ShouldBe(firstResult.Group.Id);
            firstResult.Group.Name.ShouldBe(firstResult.Group.Name);
            firstResult.Group.Permissions.Count.ShouldBe(firstResult.Group.Permissions.Count);
        }

        [Test]
        public void Empty_list_converts_to_empty_list()
        {
            var users = new List<DomainEntities.User>();

            var result = _sut.Convert(users);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_user()
        {
            var fixture = new Fixture();
            var user = fixture.Create<DtoEntities.User>();

            var result = _sut.Convert(user);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(user.Id);
            result.FirstName.ShouldBe(user.FirstName);
            result.LastName.ShouldBe(user.LastName);
            result.LoginName.ShouldBe(user.LoginName);
            result.Password.ShouldBe(user.Password);
            result.Card.ShouldNotBeNull();
            result.Card.Id.ShouldBe(user.Card.Id);
            result.Card.Login.ShouldBe(user.Card.Login);
            result.Card.Name.ShouldBe(user.Card.Name);
            result.Card.Password.ShouldBe(user.Card.Password);
            result.Group.ShouldNotBeNull();
            result.Group.Id.ShouldBe(user.Group.Id);
            result.Group.Name.ShouldBe(user.Group.Name);
            result.Group.Permissions.Count.ShouldBe(user.Group.Permissions.Count);
        }
    }
}
