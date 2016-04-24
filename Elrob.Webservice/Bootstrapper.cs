using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice
{
    using Elrob.Webservice.Controlers;

    using Ninject.Modules;

    public class Bootstrapper : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfigurationManager>().To<ConfigurationManager>();
            this.Bind<IExcelService>().To<ExcelService>();
            this.Bind<IFileController>().To<FileController>();
        }
    }
}