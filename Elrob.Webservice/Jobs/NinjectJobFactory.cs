using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elrob.Webservice.Extensions;

namespace Elrob.Webservice.Jobs
{
    using Ninject;
    using Ninject.Parameters;
    using Ninject.Planning.Bindings;

    using Quartz;
    using Quartz.Spi;

    public class NinjectJobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return Global.Kernel.GetNamedInstance<IJob>(bundle.JobDetail.JobType.FullName);
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}