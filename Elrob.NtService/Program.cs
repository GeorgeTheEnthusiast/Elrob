using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.NtService
{
    using System.Reflection;
    using System.ServiceProcess;

    using Ninject;

    using NLog;

    using Topshelf;

    public class Program
    {
        public static StandardKernel Kernel;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            try
            {
                Kernel = new StandardKernel();
                Kernel.Load(Assembly.GetExecutingAssembly());

                _logger.Info("Starting Topshelf configuration...");

                HostFactory.Run(
                    x =>
                        {
                            x.Service<NTService>(
                                s =>
                                    {
                                        s.ConstructUsing(name => new NTService());
                                        s.WhenStarted(nt => nt.OnStart());
                                        s.WhenStopped(nt => nt.OnStop());
                                    });
                            x.RunAsLocalSystem();

                            x.SetDescription("Usługa Elrob.NTService uruchamiająca zadania cykliczne (np. raporty dzienne)");
                            x.SetDisplayName("Elrob.NTService");
                            x.SetServiceName("Elrob.NTService");
                            x.StartAutomatically();
                        });
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.Info("Exiting Elrob.NTService...");
        }
    }
}
