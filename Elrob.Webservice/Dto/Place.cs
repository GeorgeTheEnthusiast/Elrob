using System.Runtime.Serialization;

namespace Elrob.Webservice.Dto
{
    [DataContract]
    public class Place
    {
        [DataMember]
        public string Name { get; set; }
    }
}
