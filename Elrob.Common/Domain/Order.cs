namespace Elrob.Common.Domain
{
    using System;

    public class Order
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime StartDate { get; set; }

        //public virtual IList<OrderContent> OrderContents { get; set; }
    }
}