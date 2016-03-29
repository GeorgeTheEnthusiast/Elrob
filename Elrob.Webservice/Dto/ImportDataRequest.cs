using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Dto
{
    public class ImportDataRequest
    {
        public byte[] FileBytes { get; set; }

        public string FileName { get; set; }
    }
}