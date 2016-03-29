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
using Elrob.Webservice.Exceptions;

namespace Elrob.Webservice
{
    [ServiceContract]
    public interface IExcelService
    {
        [FaultContract(typeof(FileWithThatNameAlreadyExistException))]
        [OperationContract]
        ImportDataResponse ImportData(ImportDataRequest importDataRequest);
    }
}
