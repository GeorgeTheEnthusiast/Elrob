using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Dto
{
    public class ImportDataResponse
    {
        public List<OrderContent> OrderContents { get; set; }

        public string ResponseMessage { get; set; }
    }
}