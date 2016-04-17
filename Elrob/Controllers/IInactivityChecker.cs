using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Terminal.Controllers
{
    public interface IInactivityChecker
    {
        void ResetTimer();

        void StartTimer();

        void StopTimer();
    }
}
