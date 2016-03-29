using System.Runtime.Serialization;

namespace Elrob.Webservice.Dto
{
    [DataContract]
    public class Material
    {
        [DataMember]
        public string Name { get; set; }
    }
}
