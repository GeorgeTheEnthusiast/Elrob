using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Elrob.Webservice
{
    using System.Reflection;

    using Elrob.Webservice.Jobs;

    using Ninject;

    using NLog;

    using Quartz;

    public class Global : System.Web.HttpApplication
    {
        public static StandardKernel Kernel;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start(object sender, EventArgs e)
        {
            _logger.Debug("Starting Elrob.Webservice...");

            Kernel = new StandardKernel();
            Kernel.Load(Assembly.GetExecutingAssembly());

            //QuartzJobFactory.ScheduleJob<DailyReportJob>(SimpleScheduleBuilder.Create());
            QuartzJobFactory.ScheduleJob<DailyReportJob>(CronScheduleBuilder.DailyAtHourAndMinute(00, 00));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            _logger.Debug("Elrob.Webservice has an error...");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            _logger.Debug("Ending Elrob.Webservice...");
        }
    }
}