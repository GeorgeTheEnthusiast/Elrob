using System.Collections.Generic;

namespace Elrob.Terminal.Domain
{
    public class OrderContent
    {
        public virtual int Id { get; set; }

        public virtual Order Order { get; set; }

        public virtual string DocumentNumber { get; set; }

        public virtual string Name { get; set; }

        public virtual Place Place { get; set; }

        public virtual int PackageQuantity { get; set; }

        public virtual Material Material { get; set; }

        public virtual decimal? Thickness { get; set; }

        public virtual decimal? Width { get; set; }

        public virtual decimal? Height { get; set; }

        public virtual decimal UnitWeight { get; set; }

        public virtual int ToComplete { get; set; }

        //public virtual IList<OrderProgress> OrderProgresses { get; set; }
    }
}
