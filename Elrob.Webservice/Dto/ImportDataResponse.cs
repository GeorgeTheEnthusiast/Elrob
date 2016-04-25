using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Dto
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = Namespaces.Dto)]
    public class ImportDataResponse
    {
        [DataMember]
        public List<OrderContent> OrderContents { get; set; }

        [DataMember]
        public string ResponseMessage { get; set; }
    }
}