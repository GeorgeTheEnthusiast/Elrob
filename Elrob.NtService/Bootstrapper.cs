namespace Elrob.NtService
{
    using Elrob.Common.DataAccess;
    using Elrob.NtService.Controllers;
    using Elrob.NtService.Converters.Implementations;
    using Elrob.NtService.Converters.Interfaces;
    using Elrob.NtService.Jobs;

    using Ninject.Modules;

    using NLog.Internal;

    using Quartz;
    using Quartz.Spi;

    public class Bootstrapper : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfigurationManager>().To<ConfigurationManager>();
            this.Bind<IDailyReportController>().To<DailyReportController>();
            this.Bind<IEmailSenderController>().To<EmailSenderController>();
            this.Bind<IJob>().To<DailyReportJob>();
            this.Bind<IWeekRangeConverter>().To<WeekRangeConverter>();
            this.Bind<IJobFactory>().To<NinjectJobFactory>();
            this.Bind<IPlaceConverter>().To<PlaceConverter>();
            this.Bind<IOrderProgressConverter>().To<OrderProgressConverter>();
            this.Bind<ISessionFactory>().To<SessionFactory>();
        }
    }
}