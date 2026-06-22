using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SSLCertificateTracker.Subclass
{
    public class SortableBindingList<CertiificateModel> : BindingList<CertiificateModel>
    {
        private bool isSorting;
        private PropertyDescriptorCollection properties;
        
        ListSortDirection sortDirectionValue;
        PropertyDescriptor sortPropertyValue;

        public SortableBindingList() : base() 
        {
            properties = TypeDescriptor.GetProperties(typeof(CertiificateModel));
            sortDirectionValue = ListSortDirection.Ascending;
            sortPropertyValue = properties.Find("HostName", true);
            RaiseListChangedEvents = true;
        }

        #region ListProperties
        //Overrides default properties of a BindingList to allow me to make a BindingList Sortable.
        private bool isSortedValue;
        protected override bool IsSortedCore
        {
            get { return isSortedValue; }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyValue; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionValue; }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        #endregion

        private void InternalSort()
        {
            if (properties == null) return;

            isSorting = true;

            IEnumerable<CertiificateModel> query = base.Items;

            query = query.OrderBy(HostName => sortPropertyValue.GetValue(HostName));

            int newIndex = 0;

            foreach (object item in query)
            {
                this.Items[newIndex] = (CertiificateModel)item;
                newIndex++;
            }

            isSortedValue = true;
            isSorting = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
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

        protected override void SetItem(int index, CertiificateModel item)
        {
            base.SetItem(index, item);
            if (!isSorting)
                this.InternalSort();
        }

        protected override void InsertItem(int index, CertiificateModel item)
        {
            base.InsertItem(index, item);
            if (!isSorting)
                this.InternalSort();
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            if (!isSorting)
                this.InternalSort();
        }

    }
}
