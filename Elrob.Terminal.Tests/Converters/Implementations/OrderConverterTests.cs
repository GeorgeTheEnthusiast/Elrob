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
    class OrderConverterTests
    {
        private IOrderConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new OrderConverter();
        }

        [Test]
        public void NullInputInConvertMethodThrowsArgumentNullException()
        {
            List<DomainEntities.Order> orders = null;
            DtoEntities.Order order = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(orders));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(order));
        }

        [Test]
        public void Properly_convert_list_of_domain_order()
        {
            var fixture = new Fixture();
            var orders = fixture.Create<List<DomainEntities.Order>>();
            var firstOrder = orders.First();
            
            var result = _sut.Convert(orders);
            var firstResult = result.First();
            
            result.ShouldNotBeNull();
            result.Count.ShouldBe(orders.Count);
            firstResult.Id.ShouldBe(firstOrder.Id);
            firstResult.Name.ShouldBe(firstOrder.Name);
            firstResult.PercentageProgress.ShouldBe(0);
            firstResult.TotalTimeSpend.ShouldBe(0);
        }

        [Test]
        public void Empty_dto_list_converts_to_empty_list()
        {
            List<DomainEntities.Order> list = new List<DomainEntities.Order>();

            var result = _sut.Convert(list);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_dto_orderContent()
        {
            var fixture = new Fixture();
            DtoEntities.Order order = fixture.Create<DtoEntities.Order>();

            var result = _sut.Convert(order);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(order.Id);
            result.Name.ShouldBe(order.Name);
        }
    }
}
