namespace Elrob.NTService.Tests.Converters.Implementations
{
    using System;

    using Elrob.NtService.Converters.Implementations;
    using Elrob.NtService.Converters.Interfaces;

    using NUnit.Framework;

    using Shouldly;

    [TestFixture]
    public class WeekRangeConverterTests
    {
        private IWeekRangeConverter _sut;

        [SetUp]
        public void SetUp()
        {
            this._sut = new WeekRangeConverter();
        }

        [Test]
        public void GetWeekRange_returns_valid_range()
        {
            DateTime dateTime = new DateTime(2016, 04, 28);
            DateTime startDateTime = new DateTime(2016, 04, 25);
            DateTime endDateTime = new DateTime(2016, 05, 01);

            var result = this._sut.GetWeekRange(dateTime);

            result.StartDate.Year.ShouldBe(startDateTime.Year);
            result.StartDate.Month.ShouldBe(startDateTime.Month);
            result.StartDate.Day.ShouldBe(startDateTime.Day);
            result.EndDate.Year.ShouldBe(endDateTime.Year);
            result.EndDate.Month.ShouldBe(endDateTime.Month);
            result.EndDate.Day.ShouldBe(endDateTime.Day);
        }
    }
}
