using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class DefChannelTypeData : INotifyPropertyChanged
    {
        private int _type;
        private string _description;

        public virtual int Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
                OnPropertyChanged("Type");
            }
        }

        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
                OnPropertyChanged("Description");
            }
        }

        public static DefChannelType Convert(DefChannelTypeData oridata)
        {
            DefChannelType target = new DefChannelType();

            #region
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            #endregion

            return target;
        }

        public static DefChannelTypeData ConvertToData(DefChannelType oridata)
        {
            DefChannelTypeData target = new DefChannelTypeData();

            #region
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            #endregion

            return target;
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
