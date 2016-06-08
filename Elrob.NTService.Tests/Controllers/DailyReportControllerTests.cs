namespace Elrob.NTService.Tests.Controllers
{
    using System;

    using Elrob.Common.DataAccess;
    using Elrob.NtService;
    using Elrob.NtService.Controllers;
    using Elrob.NtService.Converters.Interfaces;
    using Elrob.NtService.Dto;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class DailyReportControllerTests
    {
        private IDailyReportController _sut;

        private IPlaceConverter _placeConverter;
        private ISessionFactory _sessionFactory;

        [SetUp]
        public void SetUp()
        {
            this._placeConverter = Substitute.For<IPlaceConverter>();
            this._sessionFactory = Substitute.For<ISessionFactory>();
            this._sut = new DailyReportController(this._placeConverter, this._sessionFactory);
        }

        [Test]
        public void GetDailyReport()
        {
            var weekRange = new WeekRange()
            {
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddMonths(3)
            };

            this._sut.GetDailyReport(weekRange);
        }
    }
}
