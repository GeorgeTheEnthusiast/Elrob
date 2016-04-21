using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Dto;
using Elrob.Terminal.View;

namespace Elrob.Terminal.Common
{
    public class Delegates
    {
        public delegate void ImportDataSucceeded(OrderPreviewViewModel orderViewModel);
    }
}
