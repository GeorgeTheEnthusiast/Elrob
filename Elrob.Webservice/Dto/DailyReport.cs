using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Dto
{
    public class DailyReport
    {
        public string PlaceName { get; set; }

        public string OrderContentName { get; set; }

        public string OrderContentDocumentNumber { get; set; }

        public int PercentageProgress { get; set; }
    }
}