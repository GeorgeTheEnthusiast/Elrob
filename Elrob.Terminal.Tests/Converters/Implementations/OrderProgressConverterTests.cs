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
    class OrderProgressConverterTests
    {
        private IOrderProgressConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new OrderProgressConverter();
        }

        [Test]
        public void NullInputInConvertMethodThrowsArgumentNullException()
        {
            List<DomainEntities.OrderProgress> orderProgresses = null;
            DtoEntities.OrderProgress orderProgress = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(orderProgresses));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(orderProgress));
        }

        [Test]
        public void Properly_convert_list_of_domain_orderProgress()
        {
            var fixture = new Fixture();
            var orderProgresses = fixture.Create<List<DomainEntities.OrderProgress>>();
            var firstOrderProgress = orderProgresses.First();
            
            var result = _sut.Convert(orderProgresses);
            var firstResult = result.First();
            
            result.ShouldNotBeNull();
            result.Count.ShouldBe(orderProgresses.Count);
            firstResult.Id.ShouldBe(firstOrderProgress.Id);
            firstResult.Completed.ShouldBe(firstOrderProgress.Completed);
            firstResult.ProgressCreatedDate.ShouldBe(firstOrderProgress.ProgressCreatedDate);
            firstResult.ProgressModifiedDate.ShouldBe(firstOrderProgress.ProgressModifiedDate);
            firstResult.TimeSpend.ShouldBe(firstOrderProgress.TimeSpend);
            firstResult.OrderContent.ShouldNotBeNull();
            firstResult.OrderContent.Id.ShouldBe(firstOrderProgress.OrderContent.Id);
            firstResult.OrderContent.Completed.ShouldBe(0);
            firstResult.OrderContent.DocumentNumber.ShouldBe(firstOrderProgress.OrderContent.DocumentNumber);
            firstResult.OrderContent.Height.ShouldBe(firstOrderProgress.OrderContent.Height);
            firstResult.OrderContent.Name.ShouldBe(firstOrderProgress.OrderContent.Name);
            firstResult.OrderContent.PackageQuantity.ShouldBe(firstOrderProgress.OrderContent.PackageQuantity);
            firstResult.OrderContent.Thickness.ShouldBe(firstOrderProgress.OrderContent.Thickness);
            firstResult.OrderContent.ToComplete.ShouldBe(firstOrderProgress.OrderContent.ToComplete);
            firstResult.OrderContent.UnitWeight.ShouldBe(firstOrderProgress.OrderContent.UnitWeight);
            firstResult.OrderContent.Width.ShouldBe(firstOrderProgress.OrderContent.Width);
            firstResult.OrderContent.Material.ShouldNotBeNull();
            firstResult.OrderContent.Material.Id.ShouldBe(firstOrderProgress.OrderContent.Material.Id);
            firstResult.OrderContent.Material.Name.ShouldBe(firstOrderProgress.OrderContent.Material.Name);
            firstResult.OrderContent.Order.ShouldNotBeNull();
            firstResult.OrderContent.Order.Id.ShouldBe(firstOrderProgress.OrderContent.Order.Id);
            firstResult.OrderContent.Order.Name.ShouldBe(firstOrderProgress.OrderContent.Order.Name);
            firstResult.OrderContent.Order.PercentageProgress.ShouldBe(0);
            firstResult.OrderContent.Order.TotalTimeSpend.ShouldBe(0);
            firstResult.OrderContent.Place.ShouldNotBeNull();
            firstResult.OrderContent.Place.Id.ShouldBe(firstOrderProgress.OrderContent.Place.Id);
            firstResult.OrderContent.Place.Name.ShouldBe(firstOrderProgress.OrderContent.Place.Name);
            firstResult.User.ShouldNotBeNull();
            firstResult.User.Id.ShouldBe(firstOrderProgress.User.Id);
            firstResult.User.FirstName.ShouldBe(firstOrderProgress.User.FirstName);
            firstResult.User.LastName.ShouldBe(firstOrderProgress.User.LastName);
            firstResult.User.LoginName.ShouldBe(firstOrderProgress.User.LoginName);
            firstResult.User.Password.ShouldBe(firstOrderProgress.User.Password);
            firstResult.User.Card.ShouldNotBeNull();
            firstResult.User.Card.Id.ShouldBe(firstOrderProgress.User.Card.Id);
            firstResult.User.Card.Login.ShouldBe(firstOrderProgress.User.Card.Login);
            firstResult.User.Card.Name.ShouldBe(firstOrderProgress.User.Card.Name);
            firstResult.User.Card.Password.ShouldBe(firstOrderProgress.User.Card.Password);
            firstResult.User.Group.ShouldNotBeNull();
            firstResult.User.Group.Id.ShouldBe(firstOrderProgress.User.Group.Id);
            firstResult.User.Group.Name.ShouldBe(firstOrderProgress.User.Group.Name);
            firstResult.User.Group.Permissions.Count.ShouldBe(firstOrderProgress.User.Group.Permissions.Count);
        }

        [Test]
        public void Empty_dto_list_converts_to_empty_list()
        {
            List<DomainEntities.OrderProgress> list = new List<DomainEntities.OrderProgress>();

            var result = _sut.Convert(list);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_dto_orderContent()
        {
            var fixture = new Fixture();
            DtoEntities.OrderProgress orderProgress = fixture.Create<DtoEntities.OrderProgress>();

            var result = _sut.Convert(orderProgress);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(orderProgress.Id);
            result.Completed.ShouldBe(orderProgress.Completed);
            result.ProgressCreatedDate.ShouldBe(orderProgress.ProgressCreatedDate);
            result.ProgressModifiedDate.ShouldBe(orderProgress.ProgressModifiedDate);
            result.TimeSpend.ShouldBe(orderProgress.TimeSpend);
            result.OrderContent.ShouldNotBeNull();
            result.OrderContent.Id.ShouldBe(orderProgress.OrderContent.Id);
            result.OrderContent.DocumentNumber.ShouldBe(orderProgress.OrderContent.DocumentNumber);
            result.OrderContent.Height.ShouldBe(orderProgress.OrderContent.Height);
            result.OrderContent.Name.ShouldBe(orderProgress.OrderContent.Name);
            result.OrderContent.PackageQuantity.ShouldBe(orderProgress.OrderContent.PackageQuantity);
            result.OrderContent.Thickness.ShouldBe(orderProgress.OrderContent.Thickness);
            result.OrderContent.ToComplete.ShouldBe(orderProgress.OrderContent.ToComplete);
            result.OrderContent.UnitWeight.ShouldBe(orderProgress.OrderContent.UnitWeight);
            result.OrderContent.Width.ShouldBe(orderProgress.OrderContent.Width);
            result.OrderContent.Material.ShouldNotBeNull();
            result.OrderContent.Material.Id.ShouldBe(orderProgress.OrderContent.Material.Id);
            result.OrderContent.Material.Name.ShouldBe(orderProgress.OrderContent.Material.Name);
            result.OrderContent.Order.ShouldNotBeNull();
            result.OrderContent.Order.Id.ShouldBe(orderProgress.OrderContent.Order.Id);
            result.OrderContent.Order.Name.ShouldBe(orderProgress.OrderContent.Order.Name);
            result.OrderContent.Place.ShouldNotBeNull();
            result.OrderContent.Place.Id.ShouldBe(orderProgress.OrderContent.Place.Id);
            result.OrderContent.Place.Name.ShouldBe(orderProgress.OrderContent.Place.Name);
            result.User.ShouldNotBeNull();
            result.User.Id.ShouldBe(orderProgress.User.Id);
            result.User.FirstName.ShouldBe(orderProgress.User.FirstName);
            result.User.LastName.ShouldBe(orderProgress.User.LastName);
            result.User.LoginName.ShouldBe(orderProgress.User.LoginName);
            result.User.Password.ShouldBe(orderProgress.User.Password);
            result.User.Card.ShouldNotBeNull();
            result.User.Card.Id.ShouldBe(orderProgress.User.Card.Id);
            result.User.Card.Login.ShouldBe(orderProgress.User.Card.Login);
            result.User.Card.Name.ShouldBe(orderProgress.User.Card.Name);
            result.User.Card.Password.ShouldBe(orderProgress.User.Card.Password);
            result.User.Group.ShouldNotBeNull();
            result.User.Group.Id.ShouldBe(orderProgress.User.Group.Id);
            result.User.Group.Name.ShouldBe(orderProgress.User.Group.Name);
            result.User.Group.Permissions.Count.ShouldBe(orderProgress.User.Group.Permissions.Count);
        }
    }
}
