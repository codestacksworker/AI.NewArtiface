using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Controls.TreeControl.Models
{
    public class DataItemCollection : ObservableCollection<DataItem>
    {
        private DataItem owner;
        private DataItem Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public DataItemCollection(DataItem owner)
        {
            this.Owner = owner;
        }

        protected override void SetItem(int index, DataItem item)
        {
            item.Parent = this.Owner;

            base.SetItem(index, item);
        }

        protected override void ClearItems()
        {
            foreach (DataItem item in this)
            {
                item.Parent = null;
            }
            base.ClearItems();
        }

        protected override void InsertItem(int index, DataItem item)
        {
            item.Parent = this.Owner;

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            this[index].Parent = null;

            base.RemoveItem(index);
        }
    }
}
