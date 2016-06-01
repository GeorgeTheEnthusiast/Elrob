namespace Elrob.NtService.Jobs
{
    using System;

    using Ninject;

    using Quartz;
    using Quartz.Impl;
    using Quartz.Spi;

    public static class QuartzJobFactory
    {
        public static IScheduler ScheduleJob<T>(IScheduleBuilder scheduleBuilder) where T : IJob
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            var jobName = Guid.NewGuid().ToString();
            var triggerName = Guid.NewGuid().ToString();

            IScheduler sched = schedFact.GetScheduler();
            sched.JobFactory = Program.Kernel.Get<IJobFactory>();
            sched.Start();

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(jobName)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(triggerName)
                .StartNow()
                .WithSchedule(scheduleBuilder)
                .Build();

            sched.ScheduleJob(job, trigger);

            return sched;
        }
    }
}