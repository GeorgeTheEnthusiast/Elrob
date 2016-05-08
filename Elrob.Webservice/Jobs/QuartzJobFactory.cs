using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Jobs
{
    using Ninject;

    using Quartz;
    using Quartz.Impl;
    using Quartz.Spi;

    public static class QuartzJobFactory
    {
        public static void ScheduleJob<T>(IScheduleBuilder scheduleBuilder) where T : IJob
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            var jobName = Guid.NewGuid().ToString();
            var triggerName = Guid.NewGuid().ToString();

            IScheduler sched = schedFact.GetScheduler();
            sched.JobFactory = Global.Kernel.Get<IJobFactory>();
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
        }
    }
}