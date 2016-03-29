using System.Runtime.Serialization;

namespace Elrob.Webservice.Dto
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public string Name { get; set; }
    }
}
