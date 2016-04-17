using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using Elrob.Webservice.Dto;

namespace Elrob.Webservice
{
    [ServiceContract]
    public interface IExcelService
    {
        [OperationContract]
        ImportDataResponse ImportData(ImportDataRequest importDataRequest);

        string SheetName { get; } 
    }
}
