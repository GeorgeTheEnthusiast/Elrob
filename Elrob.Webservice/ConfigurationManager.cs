using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Elrob.Webservice
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string ExcelOutputDir => System.Configuration.ConfigurationManager.AppSettings["excelOutputDir"];
    }
}