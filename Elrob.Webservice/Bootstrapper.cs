using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice
{
    using Elrob.Webservice.Controllers;
    using Elrob.Webservice.Converters.Implementations;
    using Elrob.Webservice.Converters.Interfaces;
    using Elrob.Webservice.Validators;

    using Ninject.Modules;

    using Quartz;
    using Quartz.Spi;

    public class Bootstrapper : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfigurationManager>().To<ConfigurationManager>();
            this.Bind<IExcelService>().To<ExcelService>();
            this.Bind<IFileController>().To<FileController>();
            this.Bind<ISheetValidator>().To<SheetValidator>();
            this.Bind<IExcelRowsReader>().To<ExcelRowsReader>();
            this.Bind<IExcelSheetTools>().To<ExcelSheetTools>();
            this.Bind<IExcelValueParser>().To<ExcelValueParser>();
            this.Bind<IWeekRangeConverter>().To<WeekRangeConverter>();
            this.Bind<IPlaceConverter>().To<PlaceConverter>();
            this.Bind<IOrderProgressConverter>().To<OrderProgressConverter>();
            this.Bind<ISessionFactory>().To<SessionFactory>();
        }
    }
}