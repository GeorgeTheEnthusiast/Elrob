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
    class PermissionConverterTests
    {
        private IPermissionConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PermissionConverter();
        }

        [Test]
        public void NullInputInConvertMethodThrowsArgumentNullException()
        {
            List<DomainEntities.Permission> domainList = null;
            List<DtoEntities.Permission> dtoList = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(domainList));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(dtoList));
        }

        [Test]
        public void Properly_convert_list_of_domain_permission()
        {
            var fixture = new Fixture();
            var permissions = fixture.Create<List<DomainEntities.Permission>>();
            var firstPermission = permissions.First();
            
            var result = _sut.Convert(permissions);
            var firstResult = result.First();
            
            result.ShouldNotBeNull();
            result.Count.ShouldBe(permissions.Count);
            firstResult.Id.ShouldBe(firstPermission.Id);
            firstResult.Name.ShouldBe(firstPermission.Name);
            firstResult.DisplayName.ShouldBe(firstPermission.DisplayName);
        }

        [Test]
        public void Properly_convert_list_of_dto_permission()
        {
            var fixture = new Fixture();
            var permissions = fixture.Create<List<DtoEntities.Permission>>();
            var firstPermission = permissions.First();

            var result = _sut.Convert(permissions);
            var firstResult = result.First();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(permissions.Count);
            firstResult.Id.ShouldBe(firstPermission.Id);
            firstResult.Name.ShouldBe(firstPermission.Name);
            firstResult.DisplayName.ShouldBe(firstPermission.DisplayName);
        }

        [Test]
        public void Empty_dto_list_converts_to_empty_list()
        {
            List<DomainEntities.Permission> list = new List<DomainEntities.Permission>();

            var result = _sut.Convert(list);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }
    }
}
