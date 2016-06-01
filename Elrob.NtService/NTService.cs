using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.NtService
{
    using Elrob.NtService.Jobs;

    using NLog;

    using Quartz;

    partial class NTService
    {
        private IScheduler Scheduler;

        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        
        public void OnStart()
        {
            _logger.Info("Starting NTService...");
            //Scheduler = QuartzJobFactory.ScheduleJob<DailyReportJob>(SimpleScheduleBuilder.Create());
            Scheduler = QuartzJobFactory.ScheduleJob<DailyReportJob>(CronScheduleBuilder.DailyAtHourAndMinute(00, 00));
        }

        public void OnStop()
        {
            _logger.Info("Stopping NTService...");
            Scheduler.Clear();
        }
    }
}
