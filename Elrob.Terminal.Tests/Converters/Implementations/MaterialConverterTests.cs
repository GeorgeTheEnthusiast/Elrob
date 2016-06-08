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
    class MaterialConverterTests
    {
        private IMaterialConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new MaterialConverter();
        }

        [Test]
        public void NullInputThrowsArgumentNullException()
        {
            List<DomainEntities.Material> materials = null;
            DtoEntities.Material material = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(materials));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(material));
        }

        [Test]
        public void Properly_convert_list_of_cards()
        {
            var fixture = new Fixture();
            List<DomainEntities.Material> materials = fixture.Create<List<DomainEntities.Material>>();
            var firstCard = materials.First();

            var result = _sut.Convert(materials);
            var firstResult = result.First();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(materials.Count);
            firstResult.Id.ShouldBe(firstCard.Id);
            firstResult.Name.ShouldBe(firstResult.Name);
        }

        [Test]
        public void Empty_list_converts_to_empty_list()
        {
            List<DomainEntities.Material> cards = new List<DomainEntities.Material>();

            var result = _sut.Convert(cards);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_card()
        {
            var fixture = new Fixture();
            DtoEntities.Material card = fixture.Create<DtoEntities.Material>();

            var result = _sut.Convert(card);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(card.Id);
            result.Name.ShouldBe(card.Name);
        }
    }
}
