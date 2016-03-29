namespace Elrob.Terminal.Dto
{
    public class OrderContent
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public string DocumentNumber { get; set; }

        public string Name { get; set; }

        public Place Place { get; set; }

        public int PackageQuantity { get; set; }

        public Material Material { get; set; }

        public decimal? Thickness { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public decimal UnitWeight { get; set; }

        public int ToComplete { get; set; }

        public int Completed { get; set; }
    }
}
