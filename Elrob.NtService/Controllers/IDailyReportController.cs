namespace Elrob.NtService.Controllers
{
    using System.Collections.Generic;

    using Elrob.NtService.Dto;

    public interface IDailyReportController
    {
        Dictionary<Dto.Place, List<DailyReport>> GetDailyReport(WeekRange weekRange);
    }
}