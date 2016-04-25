using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Converters.Implementations;
using Elrob.Terminal.Converters.Interfaces;
using DomainEntities = Elrob.Terminal.Domain;
using DtoEntities = Elrob.Terminal.Dto;
using WebServiceEntities = Elrob.Terminal.ExcelServiceServiceReference;
using NUnit.Framework;

namespace Elrob.Terminal.Tests.Converters.Implementations
{
    using System.Runtime.Serialization;

    using Ploeh.AutoFixture;

    using Shouldly;

    [TestFixture]
    class PermissionGroupConverterTests
    {
        private IPermissionGroupConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PermissionGroupConverter();
        }

        [Test]
        public void NullInputInConvertMethodThrowsArgumentNullException()
        {
            List<DomainEntities.PermissionGroup> permissionGroupsDomain = null;
            List<DtoEntities.PermissionGroup> permissionGroupsDto = null;
            DtoEntities.PermissionGroup permissionGroup = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(permissionGroupsDomain));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(permissionGroupsDto));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(permissionGroup));
        }

        [Test]
        public void Properly_convert_list_of_domain_progressGroup()
        {
            var fixture = new Fixture();
            var permissionGroups = fixture.Create<List<DomainEntities.PermissionGroup>>();
            var firstPermissionGroup = permissionGroups.First();
            
            var result = _sut.Convert(permissionGroups);
            var firstResult = result.First();
            
            result.ShouldNotBeNull();
            result.Count.ShouldBe(permissionGroups.Count);
            firstResult.Group.ShouldNotBeNull();
            firstResult.Group.Id.ShouldBe(firstPermissionGroup.Group.Id);
            firstResult.Group.Name.ShouldBe(firstPermissionGroup.Group.Name);
            firstResult.Group.Permissions.Count.ShouldBe(firstPermissionGroup.Group.Permissions.Count);
            firstResult.Permission.ShouldNotBeNull();
            firstResult.Permission.Id.ShouldBe(firstPermissionGroup.Permission.Id);
            firstResult.Permission.DisplayName.ShouldBe(firstPermissionGroup.Permission.DisplayName);
            firstResult.Permission.Name.ShouldBe(firstPermissionGroup.Permission.Name);
        }

        [Test]
        public void Empty_dto_list_converts_to_empty_list()
        {
            var list = new List<DomainEntities.PermissionGroup>();

            var result = _sut.Convert(list);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_dto_PermissionGroup()
        {
            var fixture = new Fixture();
            var progressGroup = fixture.Create<DtoEntities.PermissionGroup>();

            var result = _sut.Convert(progressGroup);

            result.ShouldNotBeNull();
            result.Group.ShouldNotBeNull();
            result.Group.Id.ShouldBe(progressGroup.Group.Id);
            result.Group.Name.ShouldBe(progressGroup.Group.Name);
            result.Group.Permissions.Count.ShouldBe(progressGroup.Group.Permissions.Count);
            result.Permission.ShouldNotBeNull();
            result.Permission.Id.ShouldBe(progressGroup.Permission.Id);
            result.Permission.DisplayName.ShouldBe(progressGroup.Permission.DisplayName);
            result.Permission.Name.ShouldBe(progressGroup.Permission.Name);
        }
    }
}
