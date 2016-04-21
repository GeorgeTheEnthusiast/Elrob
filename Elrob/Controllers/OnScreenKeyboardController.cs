using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Terminal.Controllers
{
    public static class OnScreenKeyboardController
    {
        const string OskProcessName = "osk";

        public static void ShowOnScreenKeyboard()
        {
            var processes = Process.GetProcessesByName(OskProcessName);

            if (processes.Length == 0)
            {
                Process.Start(OskProcessName);
            }
        }
    }
}
