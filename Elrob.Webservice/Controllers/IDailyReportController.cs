namespace Elrob.Webservice.Controllers
{
    using System.Collections.Generic;

    using Elrob.Webservice.Dto;

    public interface IDailyReportController
    {
        Dictionary<Dto.Place, List<DailyReport>> GetDailyReport(WeekRange weekRange);
    }
}