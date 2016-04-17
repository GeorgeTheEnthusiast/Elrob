using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elrob.Terminal.Handlers
{
    public delegate void MouseMovedEvent();

    public delegate void KeyDownEvent();

    public class GlobalApplicationHandler : IMessageFilter
    {
        private const int WM_MOUSEMOVE = 0x0200;

        private const int WM_KEYDOWN = 0x0100;

        public event MouseMovedEvent TheMouseMoved;

        public event KeyDownEvent KeyDown;
        
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
            {
                if (TheMouseMoved != null)
                {
                    TheMouseMoved();
                }
            }
            else if (m.Msg == WM_KEYDOWN)
            {
                if (KeyDown != null)
                {
                    KeyDown();
                }
            }
            
            return false;
        }
    }
}
