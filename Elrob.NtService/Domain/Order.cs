namespace Elrob.NtService.Domain
{
    using System;

    public class Order
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime StartDate { get; set; }
    }
}
