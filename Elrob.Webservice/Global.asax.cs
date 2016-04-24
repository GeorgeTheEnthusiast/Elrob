using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Elrob.Webservice
{
    using System.Reflection;

    using Ninject;

    public class Global : System.Web.HttpApplication
    {
        public static StandardKernel Kernel;

        protected void Application_Start(object sender, EventArgs e)
        {
            Kernel = new StandardKernel();
            Kernel.Load(Assembly.GetExecutingAssembly());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}