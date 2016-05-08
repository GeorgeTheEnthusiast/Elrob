using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Webservice
{
    public interface IConfigurationManager
    {
        string ExcelOutputDir { get; }

        string DailyReportRecipient { get; }
    }
}
