namespace Elrob.Webservice.Controllers
{
    using System.Collections.Generic;

    using Elrob.Webservice.Dto;

    public interface IDailyReportController
    {
        List<DailyReport> GetDailyReport(WeekRange weekRange);
    }
}