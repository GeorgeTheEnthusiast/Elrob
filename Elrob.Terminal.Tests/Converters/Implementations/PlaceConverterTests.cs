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
    class PlaceConverterTests
    {
        private IPlaceConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PlaceConverter();
        }

        [Test]
        public void NullInputThrowsArgumentNullException()
        {
            List<DomainEntities.Place> places = null;
            DtoEntities.Place place = null;
            
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(places));
            Assert.Throws<ArgumentNullException>(() => _sut.Convert(place));
        }

        [Test]
        public void Properly_convert_list_of_places()
        {
            var fixture = new Fixture();
            var places  = fixture.Create<List<DomainEntities.Place>>();
            var firstPlace = places.First();

            var result = _sut.Convert(places);
            var firstResult = result.First();

            result.ShouldNotBeNull();
            result.Count.ShouldBe(places.Count);
            firstResult.Id.ShouldBe(firstPlace.Id);
            firstResult.Name.ShouldBe(firstResult.Name);
        }

        [Test]
        public void Empty_list_converts_to_empty_list()
        {
            var places = new List<DomainEntities.Place>();

            var result = _sut.Convert(places);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(0);
        }

        [Test]
        public void Properly_convert_single_place()
        {
            var fixture = new Fixture();
            var place = fixture.Create<DtoEntities.Place>();

            var result = _sut.Convert(place);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(place.Id);
            result.Name.ShouldBe(place.Name);
        }
    }
}
