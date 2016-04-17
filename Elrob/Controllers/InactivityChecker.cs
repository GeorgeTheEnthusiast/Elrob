using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elrob.Terminal.Common;

namespace Elrob.Terminal.Controllers
{
    public class InactivityChecker : IInactivityChecker
    {
        private static Stopwatch Stopwatch { get; set; }

        private static Thread CheckerThread { get; set; }

        public static InactivityChecker Instance { get; set; }

        static InactivityChecker()
        {
            if (Instance == null)
            {
                Instance = new InactivityChecker();
                Stopwatch = new Stopwatch();
                CheckerThread = new Thread(Checker);
            }
        }

        private static void Checker()
        {
            while (Stopwatch.Elapsed.Minutes < 5)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
            
            UISafeThread.CloseAllForms();
        }

        public void ResetTimer()
        {
            Stopwatch.Restart();
        }

        public void StartTimer()
        {
            CheckerThread.Start();
        }

        public void StopTimer()
        {
            CheckerThread.Abort();
        }
    }
}
