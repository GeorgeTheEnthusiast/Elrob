using System.Runtime.Serialization;

namespace Elrob.Webservice.Dto
{
    [DataContract(Namespace = Namespaces.Dto)]
    public class Material
    {
        [DataMember]
        public string Name { get; set; }
    }
}
