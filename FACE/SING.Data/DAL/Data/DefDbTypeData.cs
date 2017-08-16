using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class DefDbTypeData : INotifyPropertyChanged
    {
        private int _type;
        private string _description;
        private int _level;

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

        public virtual int Level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
                OnPropertyChanged("Level");
            }
        }

        public static DefDbType Convert(DefDbTypeData oridata)
        {
            DefDbType target = new DefDbType();

            #region
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            target.Level = oridata.Level;
            #endregion

            return target;
        }

        public static DefDbTypeData ConvertToData(DefDbType oridata)
        {
            DefDbTypeData target = new DefDbTypeData();

            #region
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            target.Level = oridata.Level;
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
