using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.View
{
    public class OrderPreviewViewModel
    {
        public Order Order { get; set; }

        public List<OrderContent> OrderContents { get; set; }

        public List<Material> Materials { get; set; }

        public List<Place> Places { get; set; }
    }
}
