using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Controlers
{
    public interface IFileController
    {
        string SaveFile(byte[] fileBytes, string fileName);
    }
}