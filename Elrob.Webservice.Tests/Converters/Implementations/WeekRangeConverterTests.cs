using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Webservice.Tests.Converters.Implementations
{
    using Elrob.Webservice.Converters.Implementations;
    using Elrob.Webservice.Converters.Interfaces;

    using NUnit.Framework;

    using Shouldly;

    [TestFixture]
    public class WeekRangeConverterTests
    {
        private IWeekRangeConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new WeekRangeConverter();
        }

        [Test]
        public void GetWeekRange_returns_valid_range()
        {
            DateTime dateTime = new DateTime(2016, 04, 28);
            DateTime startDateTime = new DateTime(2016, 04, 25);
            DateTime endDateTime = new DateTime(2016, 05, 01);

            var result = _sut.GetWeekRange(dateTime);

            result.StartDate.Year.ShouldBe(startDateTime.Year);
            result.StartDate.Month.ShouldBe(startDateTime.Month);
            result.StartDate.Day.ShouldBe(startDateTime.Day);
            result.EndDate.Year.ShouldBe(endDateTime.Year);
            result.EndDate.Month.ShouldBe(endDateTime.Month);
            result.EndDate.Day.ShouldBe(endDateTime.Day);
        }
    }
}
