using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Converters.Implementations;
using Elrob.Terminal.Converters.Interfaces;
using DomainEntities = Elrob.Terminal.Domain;
using DtoEntities = Elrob.Terminal.Dto;
using NUnit.Framework;

namespace Elrob.Terminal.Tests.Converters.Implementations
{
    using Ploeh.AutoFixture;

    using Shouldly;

    [TestFixture]
    class GroupConverterTests
    {
        private IGroupConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new GroupConverter();
        }

        [Test]
        public void NullInputThrowsArgumentNullException()
        {
            List<DomainEntities.Group> groups = null;
            DtoEntities.Group group = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(groups));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(group));
        }

        [Test]
        public void Properly_convert_list_of_groups()
        {
            var fixture = new Fixture();
            var groups = fixture.Create<List<DomainEntities.Group>>();

            var firstGroup = groups.First();
            var firstPermission = firstGroup.Permissions.First();

            var result = _sut.Convert(groups);
            var firstResultGroup = result.First();
            var firstResultPermission = firstResultGroup.Permissions.First();

            result.Count.ShouldBe(groups.Count);
            firstResultGroup.Id.ShouldBe(firstGroup.Id);
            firstResultGroup.Name.ShouldBe(firstGroup.Name);
            firstResultPermission.Id.ShouldBe(firstPermission.Id);
            firstResultPermission.Name.ShouldBe(firstPermission.Name);
            firstResultPermission.DisplayName.ShouldBe(firstPermission.DisplayName);
        }

        [Test]
        public void Empty_list_converts_to_empty_list()
        {
            List<DomainEntities.Group> groups = new List<DomainEntities.Group>();

            var result = _sut.Convert(groups);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_group()
        {
            var fixture = new Fixture();
            DtoEntities.Group group = fixture.Create<DtoEntities.Group>();
            var permission = group.Permissions.First();

            var result = _sut.Convert(group);
            var firstPermissionResult = result.Permissions.First();

            result.Id.ShouldBe(group.Id);
            result.Name.ShouldBe(group.Name);
            firstPermissionResult.Id.ShouldBe(permission.Id);
            firstPermissionResult.Name.ShouldBe(permission.Name);
            firstPermissionResult.DisplayName.ShouldBe(permission.DisplayName);
        }
    }
}
