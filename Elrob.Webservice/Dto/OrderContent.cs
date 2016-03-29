using System.Runtime.Serialization;

namespace Elrob.Webservice.Dto
{
    [DataContract]
    public class OrderContent
    {
        [DataMember]
        public Order Order { get; set; }

        [DataMember]
        public string DocumentNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Place Place { get; set; }

        [DataMember]
        public int PackageQuantity { get; set; }

        [DataMember]
        public Material Material { get; set; }

        [DataMember]
        public decimal? Thickness { get; set; }

        [DataMember]
        public decimal? Width { get; set; }

        [DataMember]
        public decimal? Height { get; set; }

        [DataMember]
        public decimal UnitWeight { get; set; }

        [DataMember]
        public int ToComplete { get; set; }
    }
}
