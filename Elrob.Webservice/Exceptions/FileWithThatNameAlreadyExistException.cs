using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Elrob.Webservice.Exceptions
{
    [DataContract]
    public class FileWithThatNameAlreadyExistException
    {
        [DataMember]
        public string FilePath { get; set; }

        public FileWithThatNameAlreadyExistException(string filePath)
        {
            FilePath = filePath;
        }
    }
}