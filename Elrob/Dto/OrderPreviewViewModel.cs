using System.Collections.Generic;

namespace Elrob.Terminal.Dto
{
    public class OrderPreviewViewModel
    {
        public Order Order { get; set; }

        public List<OrderContent> OrderContents { get; set; }

        public List<Material> Materials { get; set; }

        public List<Place> Places { get; set; }
    }
}
