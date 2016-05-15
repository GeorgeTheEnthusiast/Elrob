using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Webservice.Tests.Controllers
{
    using Elrob.Webservice.Controllers;
    using Elrob.Webservice.Converters.Interfaces;
    using Elrob.Webservice.Dto;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class DailyReportControllerTests
    {
        private IDailyReportController _sut;

        private IPlaceConverter _placeConverter;

        [SetUp]
        public void SetUp()
        {
            _placeConverter = Substitute.For<IPlaceConverter>();
            _sut = new DailyReportController(_placeConverter);
        }

        [Test]
        public void GetDailyReport()
        {
            var weekRange = new WeekRange()
            {
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddMonths(3)
            };

            _sut.GetDailyReport(weekRange);
        }
    }
}
