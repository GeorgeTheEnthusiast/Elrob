using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Terminal.Common
{
    public class CustomBindingList<T> : BindingList<T>
    {
        private bool isSorting;

        /// <summary>
        /// Raised when the list is sorted.
        /// </summary>
        public event EventHandler Sorted;

        public CustomBindingList()
            : this(null)
        { }

        public CustomBindingList(IEnumerable<T> contents)
            : this(contents, null)
        { }

        public CustomBindingList(IEnumerable<T> contents, ISortComparer<T> comparer)
        {
            if (contents != null)
                AddRange(contents);

            if (comparer == null)
                SortComparer = new GenericSortComparer<T>();
            else
                SortComparer = comparer;
        }

        #region Properties
        private ISortComparer<T> sortComparer;
        public ISortComparer<T> SortComparer
        {
            get { return sortComparer; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("SortComparer", "Value cannot be null.");
                sortComparer = value;
            }
        }

        private bool isSorted;
        protected override bool IsSortedCore
        {
            get { return isSorted; }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        private ListSortDirection sortDirection;
        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection; }
        }

        private PropertyDescriptor sortProperty;
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty; }
        }
        #endregion

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            if (prop == null)
                return;

            isSorting = true;
            sortDirection = direction;
            sortProperty = prop;
            this.SortComparer.SortProperty = prop;
            this.SortComparer.SortDirection = direction;
            ((List<T>)this.Items).Sort(this.SortComparer);
            isSorted = true;
            isSorting = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
            OnSorted(null, new EventArgs());
        }

        protected override void RemoveSortCore()
        {
            throw new NotSupportedException();
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (!isSorting)
                base.OnListChanged(e);
        }

        protected virtual void OnSorted(object sender, EventArgs e)
        {
            if (Sorted != null)
                Sorted(sender, e);
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            if (!isSorting)
                this.ApplySortCore(this.SortPropertyCore, this.SortDirectionCore);
        }

        protected override void SetItem(int index, T item)
        {
            base.SetItem(index, item);
            if (!isSorting)
                this.ApplySortCore(this.SortPropertyCore, this.SortDirectionCore);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            if (!isSorting)
                this.ApplySortCore(this.SortPropertyCore, this.SortDirectionCore);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items != null)
                foreach (T item in items)
                    this.Items.Add(item);
        }
    }
}
