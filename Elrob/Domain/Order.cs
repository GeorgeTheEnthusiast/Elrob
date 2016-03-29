using System.Collections.Generic;

namespace Elrob.Terminal.Domain
{
    public class Order
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<OrderContent> OrderContents { get; set; }
    }
}
