using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Webservice.Controllers
{
    public interface IEmailSenderController
    {
        void SendEmail(string message, string subject);
    }
}
