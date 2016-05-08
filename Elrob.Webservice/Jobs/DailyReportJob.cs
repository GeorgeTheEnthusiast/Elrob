using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Jobs
{
    using System.Globalization;
    using System.Text;

    using Elrob.Webservice.Controllers;
    using Elrob.Webservice.Converters.Interfaces;

    using NLog;

    using Quartz;

    [DisallowConcurrentExecution]
    public class DailyReportJob : IJob
    {
        private readonly IDailyReportController _dailyReportController;

        private readonly IEmailSenderController _emailSenderController;

        private readonly IWeekRangeConverter _weekRangeConverter;

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public DailyReportJob(
            IDailyReportController dailyReportController, 
            IEmailSenderController emailSenderController,
            IWeekRangeConverter weekRangeConverter)
        {
            if (dailyReportController == null)
            {
                throw new ArgumentNullException(nameof(dailyReportController));
            }
            if (emailSenderController == null)
            {
                throw new ArgumentNullException(nameof(emailSenderController));
            }
            if (weekRangeConverter == null)
            {
                throw new ArgumentNullException(nameof(weekRangeConverter));
            }
            this._dailyReportController = dailyReportController;
            this._emailSenderController = emailSenderController;
            this._weekRangeConverter = weekRangeConverter;
        }

        public void Execute(IJobExecutionContext context)
        {
            _logger.Info("Executing DailyReportJob...");

            try
            {
                var weekRange = _weekRangeConverter.GetWeekRange(DateTime.Now);
                var dailyReportData = _dailyReportController.GetDailyReport(weekRange);
                var emailMessage = new StringBuilder();
                string emailSubject = string.Format("Raport z wykonanych prac od {0} do {1}", 
                    weekRange.StartDate.ToShortDateString(), 
                    weekRange.EndDate.ToShortDateString());
                int weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                    DateTime.Now,
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday);
                string oldPlaceName = string.Empty;
                int lp = 1;

                foreach (var row in dailyReportData)
                {
                    if (oldPlaceName != row.PlaceName)
                    {
                        emailMessage.AppendLine(new string('-', 20));
                        emailMessage.AppendLine(string.Format("Placówka: {0}", row.PlaceName));
                        emailMessage.AppendLine(string.Format("Tydzień: {0}", weekNumber));
                        emailMessage.AppendLine("LP.");
                        lp = 1;
                    }
                    
                    emailMessage.AppendLine(string.Format("{0}. {1} {2} zrobiony w {3}%", 
                        lp,
                        row.OrderContentDocumentNumber,
                        row.OrderContentName,
                        row.PercentageProgress));
                    
                    oldPlaceName = row.PlaceName;
                    lp++;
                }

                _emailSenderController.SendEmail(emailMessage.ToString(), emailSubject);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            _logger.Info("DailyReportJob is completed.");
        }
    }
}