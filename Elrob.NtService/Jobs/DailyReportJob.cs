﻿namespace Elrob.NtService.Jobs
{
    using System;
    using System.Globalization;
    using System.Text;

    using Elrob.NtService.Controllers;
    using Elrob.NtService.Converters.Interfaces;
    using Elrob.NtService.Dto;

    using NLog;

    using Quartz;

    [DisallowConcurrentExecution]
    public class DailyReportJob : IJob
    {
        private readonly IDailyReportController _dailyReportController;

        private readonly IEmailSenderController _emailSenderController;

        private readonly IWeekRangeConverter _weekRangeConverter;

        private readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

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
            this._logger.Info("Executing DailyReportJob...");

            try
            {
                var weekRange = this._weekRangeConverter.GetWeekRange(DateTime.Now);
                var dailyReportData = this._dailyReportController.GetDailyReport(weekRange);
                var emailMessage = new StringBuilder();
                string emailSubject = string.Format("Raport z wykonanych prac od {0} do {1}", 
                    weekRange.StartDate.ToShortDateString(), 
                    weekRange.EndDate.ToShortDateString());
                int weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                    DateTime.Now,
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday);
                
                foreach (Place row in dailyReportData.Keys)
                {
                    emailMessage.AppendLine(new string('-', 100));
                    emailMessage.AppendLine(string.Format("Placówka: {0}", row.Name));
                    emailMessage.AppendLine(string.Format("Tydzień: {0}", weekNumber));
                    emailMessage.AppendLine("LP.");
                    int lp = 1;

                    if (dailyReportData[row].Count == 0)
                    {
                        emailMessage.AppendLine("Brak zamówień w bieżącym tygodniu.");
                    }

                    foreach (var dailyReport in dailyReportData[row])
                    {
                        emailMessage.AppendLine(string.Format("{0}. {1} {2} zrobiony w {3}%",
                        lp,
                        dailyReport.OrderContentDocumentNumber,
                        dailyReport.OrderContentName,
                        dailyReport.PercentageProgress));
                        lp++;
                    }
                }

                this._emailSenderController.SendEmail(emailMessage.ToString(), emailSubject);
            }
            catch (Exception ex)
            {
                this._logger.Error(ex);
            }

            this._logger.Info("DailyReportJob is completed.");
        }
    }
}