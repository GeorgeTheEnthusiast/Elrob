namespace Elrob.NtService.Jobs
{
    using Elrob.NtService.Extensions;

    using Quartz;
    using Quartz.Spi;

    public class NinjectJobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return Program.Kernel.GetNamedInstance<IJob>(bundle.JobDetail.JobType.FullName);
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}