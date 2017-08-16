using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Controls.TreeControl.Models;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class RegionsData : INotifyPropertyChanged
    {
        private int _id;
        private string _regionName;
        private string _regionDescription;
        private int _parentId;
        private int _regionLevel;
        private int _regionSort;

        public virtual int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged("ID");
            }
        }

        public virtual string RegionName
        {
            get
            {
                return this._regionName;
            }
            set
            {
                this._regionName = value;
                OnPropertyChanged("RegionName");
            }
        }

        public virtual string RegionDescription
        {
            get
            {
                return this._regionDescription;
            }
            set
            {
                this._regionDescription = value;
                OnPropertyChanged("RegionDescription");
            }
        }

        public virtual int ParentId
        {
            get
            {
                return this._parentId;
            }
            set
            {
                this._parentId = value;
                OnPropertyChanged("ParentId");
            }
        }

        public virtual int RegionLevel
        {
            get
            {
                return this._regionLevel;
            }
            set
            {
                this._regionLevel = value;
                OnPropertyChanged("RegionLevel");
            }
        }

        public virtual int RegionSort
        {
            get
            {
                return this._regionSort;
            }
            set
            {
                this._regionSort = value;
                OnPropertyChanged("RegionSort");
            }
        }

        public static Regions Convert(RegionsData oridata)
        {
            Regions target = new Regions();
            target.ID = oridata.ID;
            target.RegionName = oridata.RegionName;
            target.RegionDescription = oridata.RegionDescription;
            target.ParentId = oridata.ParentId;
            target.RegionLevel = oridata.RegionLevel;
            target.RegionSort = oridata.RegionSort;
            return target;
        }

        public static RegionsData ConvertToData(Regions oridata)
        {
            RegionsData target = new RegionsData();
            target.ID = oridata.ID;
            target.RegionName = oridata.RegionName;
            target.RegionDescription = oridata.RegionDescription;
            target.ParentId = oridata.ParentId;
            target.RegionLevel = oridata.RegionLevel;
            target.RegionSort = oridata.RegionSort;
            return target;
        }

        public static void CopyValue(object origin, object target)
        {
            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.PropertyInfo[] fields = (origin.GetType()).GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {

                    if (fields[i].Name.ToUpper() == properties[j].Name.ToUpper() && properties[j].CanWrite)
                    {
                        properties[j].SetValue(target, fields[i].GetValue(origin, null), null);
                    }
                }
            }
        }

        #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
