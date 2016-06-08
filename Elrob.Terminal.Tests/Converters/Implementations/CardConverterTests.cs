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
    class CardConverterTests
    {
        private ICardConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CardConverter();
        }

        [Test]
        public void NullInputThrowsArgumentNullException()
        {
            List<DomainEntities.Card> cards = null;
            DtoEntities.Card card = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(cards));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(card));
        }

        [Test]
        public void Properly_convert_list_of_cards()
        {
            var fixture = new Fixture();
            List<DomainEntities.Card> cards = fixture.Create<List<DomainEntities.Card>>();
            var firstCard = cards.First();

            var result = _sut.Convert(cards);
            var firstResult = result.First();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(cards.Count);
            firstResult.Id.ShouldBe(firstCard.Id);
            firstResult.Login.ShouldBe(firstCard.Login);
            firstResult.Name.ShouldBe(firstResult.Name);
            firstResult.Password.ShouldBe(firstCard.Password);
        }

        [Test]
        public void Empty_list_converts_to_empty_list()
        {
            List<DomainEntities.Card> cards = new List<DomainEntities.Card>();

            var result = _sut.Convert(cards);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_card()
        {
            var fixture = new Fixture();
            DtoEntities.Card card = fixture.Create<DtoEntities.Card>();

            var result = _sut.Convert(card);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(card.Id);
            result.Login.ShouldBe(card.Login);
            result.Name.ShouldBe(card.Name);
            result.Password.ShouldBe(card.Password);
        }
    }
}
