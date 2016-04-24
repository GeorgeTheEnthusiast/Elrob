using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Converters.Implementations;
using Elrob.Terminal.Converters.Interfaces;
using DomainEntities = Elrob.Terminal.Domain;
using DtoEntities = Elrob.Terminal.Dto;
using WebServiceEntities = Elrob.Terminal.Service_References.ExcelServiceServiceReference;
using NUnit.Framework;

namespace Elrob.Terminal.Tests.Converters.Implementations
{
    using System.Runtime.Serialization;

    using Ploeh.AutoFixture;

    using Shouldly;

    [TestFixture]
    class OrderContentConverterTests
    {
        private IOrderContentConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new OrderContentConverter();
        }

        [Test]
        public void NullInputInConvertMethodThrowsArgumentNullException()
        {
            List<DomainEntities.OrderContent> list1 = null;
            List<WebServiceEntities.OrderContent> list2 = null;
            List<DtoEntities.OrderContent> list3 = null;
            DtoEntities.OrderContent orderContent1 = null;
            WebServiceEntities.OrderContent orderContent2 = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(list1));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(list2));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(list3));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(orderContent1));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(orderContent2));
        }

        [Test]
        public void NullInputInCloneMethodThrowsArgumentNullException()
        {
            DtoEntities.OrderContent orderContent1 = new DtoEntities.OrderContent();
            DtoEntities.OrderContent orderContent2 = new DtoEntities.OrderContent();

            Assert.Throws<ArgumentNullException>(() => _sut.Clone(null, orderContent2));
            Assert.Throws<ArgumentNullException>(() => _sut.Clone(orderContent1, null));
            Assert.Throws<ArgumentNullException>(() => _sut.Clone(null, null));
        }

        [Test]
        public void Properly_convert_list_of_domain_orderContent()
        {
            var fixture = new Fixture();
            var orderContents = fixture.Create<List<DomainEntities.OrderContent>>();
            var firstOrderContent = orderContents.First();
            
            var result = _sut.Convert(orderContents);
            var firstResult = result.First();
            
            result.ShouldNotBeNull();
            result.Count.ShouldBe(orderContents.Count);
            firstResult.Id.ShouldBe(firstOrderContent.Id);
            firstResult.Completed.ShouldBe(0);
            firstResult.DocumentNumber.ShouldBe(firstOrderContent.DocumentNumber);
            firstResult.Height.ShouldBe(firstOrderContent.Height);
            firstResult.Name.ShouldBe(firstOrderContent.Name);
            firstResult.PackageQuantity.ShouldBe(firstOrderContent.PackageQuantity);
            firstResult.Thickness.ShouldBe(firstOrderContent.Thickness);
            firstResult.ToComplete.ShouldBe(firstOrderContent.ToComplete);
            firstResult.UnitWeight.ShouldBe(firstOrderContent.UnitWeight);
            firstResult.Width.ShouldBe(firstOrderContent.Width);
            firstResult.Material.ShouldNotBeNull();
            firstResult.Material.Id.ShouldBe(firstOrderContent.Material.Id);
            firstResult.Material.Name.ShouldBe(firstOrderContent.Material.Name);
            firstResult.Place.ShouldNotBeNull();
            firstResult.Place.Id.ShouldBe(firstOrderContent.Place.Id);
            firstResult.Place.Name.ShouldBe(firstOrderContent.Place.Name);
            firstResult.Order.ShouldNotBeNull();
            firstResult.Order.Id.ShouldBe(firstOrderContent.Order.Id);
            firstResult.Order.Name.ShouldBe(firstOrderContent.Order.Name);
            firstResult.Order.PercentageProgress.ShouldBe(0);
            firstResult.Order.TotalTimeSpend.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_list_of_dto_orderContent()
        {
            var fixture = new Fixture();
            var orderContents = fixture.Create<List<DtoEntities.OrderContent>>();
            var firstOrderContent = orderContents.First();

            var result = _sut.Convert(orderContents);
            var firstResult = result.First();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(orderContents.Count);
            firstResult.Id.ShouldBe(firstOrderContent.Id);
            firstResult.DocumentNumber.ShouldBe(firstOrderContent.DocumentNumber);
            firstResult.Height.ShouldBe(firstOrderContent.Height);
            firstResult.Name.ShouldBe(firstOrderContent.Name);
            firstResult.PackageQuantity.ShouldBe(firstOrderContent.PackageQuantity);
            firstResult.Thickness.ShouldBe(firstOrderContent.Thickness);
            firstResult.ToComplete.ShouldBe(firstOrderContent.ToComplete);
            firstResult.UnitWeight.ShouldBe(firstOrderContent.UnitWeight);
            firstResult.Width.ShouldBe(firstOrderContent.Width);
            firstResult.Material.ShouldNotBeNull();
            firstResult.Material.Id.ShouldBe(firstOrderContent.Material.Id);
            firstResult.Material.Name.ShouldBe(firstOrderContent.Material.Name);
            firstResult.Place.ShouldNotBeNull();
            firstResult.Place.Id.ShouldBe(firstOrderContent.Place.Id);
            firstResult.Place.Name.ShouldBe(firstOrderContent.Place.Name);
            firstResult.Order.ShouldNotBeNull();
            firstResult.Order.Id.ShouldBe(firstOrderContent.Order.Id);
            firstResult.Order.Name.ShouldBe(firstOrderContent.Order.Name);
        }

        [Test]
        public void Properly_convert_list_of_webservice_orderContent()
        {
            var fixture = new Fixture();
            fixture.Register<ExtensionDataObject>(() => null);
            var orderContents = fixture.Create<List<WebServiceEntities.OrderContent>>();
            var firstOrderContent = orderContents.First();

            var result = _sut.Convert(orderContents);
            var firstResult = result.First();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(orderContents.Count);
            firstResult.Id.ShouldBe(0);
            firstResult.DocumentNumber.ShouldBe(firstOrderContent.DocumentNumber);
            firstResult.Height.ShouldBe(firstOrderContent.Height);
            firstResult.Name.ShouldBe(firstOrderContent.Name);
            firstResult.PackageQuantity.ShouldBe(firstOrderContent.PackageQuantity);
            firstResult.Thickness.ShouldBe(firstOrderContent.Thickness);
            firstResult.ToComplete.ShouldBe(firstOrderContent.ToComplete);
            firstResult.UnitWeight.ShouldBe(firstOrderContent.UnitWeight);
            firstResult.Width.ShouldBe(firstOrderContent.Width);
            firstResult.Material.ShouldNotBeNull();
            firstResult.Material.Id.ShouldBe(0);
            firstResult.Material.Name.ShouldBe(firstOrderContent.Material.Name);
            firstResult.Place.ShouldNotBeNull();
            firstResult.Place.Id.ShouldBe(0);
            firstResult.Place.Name.ShouldBe(firstOrderContent.Place.Name);
            firstResult.Order.ShouldNotBeNull();
            firstResult.Order.Id.ShouldBe(0);
            firstResult.Order.Name.ShouldBe(firstOrderContent.Order.Name);
        }

        [Test]
        public void Empty_dto_list_converts_to_empty_list()
        {
            List<DtoEntities.OrderContent> list = new List<DtoEntities.OrderContent>();

            var result = _sut.Convert(list);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Empty_domain_list_converts_to_empty_list()
        {
            List<DomainEntities.OrderContent> list = new List<DomainEntities.OrderContent>();

            var result = _sut.Convert(list);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Empty_webservice_list_converts_to_empty_list()
        {
            List<WebServiceEntities.OrderContent> list = new List<WebServiceEntities.OrderContent>();

            var result = _sut.Convert(list);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_dto_orderContent()
        {
            var fixture = new Fixture();
            DtoEntities.OrderContent orderContent = fixture.Create<DtoEntities.OrderContent>();

            var result = _sut.Convert(orderContent);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(orderContent.Id);
            result.DocumentNumber.ShouldBe(orderContent.DocumentNumber);
            result.Height.ShouldBe(orderContent.Height);
            result.Name.ShouldBe(orderContent.Name);
            result.PackageQuantity.ShouldBe(orderContent.PackageQuantity);
            result.Thickness.ShouldBe(orderContent.Thickness);
            result.ToComplete.ShouldBe(orderContent.ToComplete);
            result.UnitWeight.ShouldBe(orderContent.UnitWeight);
            result.Width.ShouldBe(orderContent.Width);
            result.Material.ShouldNotBeNull();
            result.Material.Id.ShouldBe(orderContent.Material.Id);
            result.Material.Name.ShouldBe(orderContent.Material.Name);
            result.Place.ShouldNotBeNull();
            result.Place.Id.ShouldBe(orderContent.Place.Id);
            result.Place.Name.ShouldBe(orderContent.Place.Name);
            result.Order.ShouldNotBeNull();
            result.Order.Id.ShouldBe(orderContent.Order.Id);
            result.Order.Name.ShouldBe(orderContent.Order.Name);
        }

        [Test]
        public void Properly_convert_single_webservice_orderContent()
        {
            var fixture = new Fixture();
            fixture.Register<ExtensionDataObject>(() => null);
            WebServiceEntities.OrderContent orderContent = fixture.Create<WebServiceEntities.OrderContent>();

            var result = _sut.Convert(orderContent);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(0);
            result.DocumentNumber.ShouldBe(orderContent.DocumentNumber);
            result.Height.ShouldBe(orderContent.Height);
            result.Name.ShouldBe(orderContent.Name);
            result.PackageQuantity.ShouldBe(orderContent.PackageQuantity);
            result.Thickness.ShouldBe(orderContent.Thickness);
            result.ToComplete.ShouldBe(orderContent.ToComplete);
            result.UnitWeight.ShouldBe(orderContent.UnitWeight);
            result.Width.ShouldBe(orderContent.Width);
            result.Material.ShouldNotBeNull();
            result.Material.Id.ShouldBe(0);
            result.Material.Name.ShouldBe(orderContent.Material.Name);
            result.Place.ShouldNotBeNull();
            result.Place.Id.ShouldBe(0);
            result.Place.Name.ShouldBe(orderContent.Place.Name);
            result.Order.ShouldNotBeNull();
            result.Order.Id.ShouldBe(0);
            result.Order.Name.ShouldBe(orderContent.Order.Name);
        }

        [Test]
        public void Properly_clone_single_dto_orderContent()
        {
            var fixture = new Fixture();
            DtoEntities.OrderContent source = fixture.Create<DtoEntities.OrderContent>();
            DtoEntities.OrderContent destination = source;
            source.Name = fixture.Create<string>();
            source.Material = fixture.Create<DtoEntities.Material>();
            
            var result = _sut.Clone(source, destination);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(source.Id);
            result.DocumentNumber.ShouldBe(source.DocumentNumber);
            result.Height.ShouldBe(source.Height);
            result.Name.ShouldBe(source.Name);
            result.PackageQuantity.ShouldBe(source.PackageQuantity);
            result.Thickness.ShouldBe(source.Thickness);
            result.ToComplete.ShouldBe(source.ToComplete);
            result.UnitWeight.ShouldBe(source.UnitWeight);
            result.Width.ShouldBe(source.Width);
            result.Material.ShouldNotBeNull();
            result.Material.Id.ShouldBe(source.Material.Id);
            result.Material.Name.ShouldBe(source.Material.Name);
            result.Place.ShouldNotBeNull();
            result.Place.Id.ShouldBe(source.Place.Id);
            result.Place.Name.ShouldBe(source.Place.Name);
            result.Order.ShouldNotBeNull();
            result.Order.Id.ShouldBe(source.Order.Id);
            result.Order.Name.ShouldBe(source.Order.Name);
        }
    }
}
