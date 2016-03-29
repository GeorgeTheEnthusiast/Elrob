using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Terminal.Common
{
    public interface ISortComparer<T> : IComparer<T>
    {
        PropertyDescriptor SortProperty { get; set; }
        ListSortDirection SortDirection { get; set; }
    }
}
