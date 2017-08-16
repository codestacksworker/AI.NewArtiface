using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Help;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class FaceTemplateDBData : INotifyPropertyChanged
    {
        private int _id;
        private string _templateDbName;
        private string _templateDbDescription;
        private int _templateDbType;
        private int _isUsed;
        private int _templateDbSize;
        private string _createTime;
        private int _isDeleted;
        private int _templateDbCapacity = 10000;
        private bool _IsSelected;

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

        public virtual string TemplateDbName
        {
            get
            {
                return this._templateDbName;
            }
            set
            {
                this._templateDbName = value;
                OnPropertyChanged("TemplateDbName");
            }
        }

        public virtual string TemplateDbDescription
        {
            get
            {
                return this._templateDbDescription;
            }
            set
            {
                this._templateDbDescription = value;
                OnPropertyChanged("TemplateDbDescription");
            }
        }

        public virtual int TemplateDbType
        {
            get
            {
                return this._templateDbType;
            }
            set
            {
                this._templateDbType = value;
                OnPropertyChanged("TemplateDbType");
            }
        }

        public virtual int IsUsed
        {
            get
            {
                return this._isUsed;
            }
            set
            {
                this._isUsed = value;
                OnPropertyChanged("IsUsed");
            }
        }

        public virtual int TemplateDbSize
        {
            get
            {
                return this._templateDbSize;
            }
            set
            {
                this._templateDbSize = value;
                OnPropertyChanged("TemplateDbSize");
            }
        }

        public virtual string CreateTime
        {
            get
            {
                return this._createTime;
            }
            set
            {
                this._createTime = value;
                OnPropertyChanged("CreateTime");
            }
        }

        public virtual int IsDeleted
        {
            get
            {
                return this._isDeleted;
            }
            set
            {
                this._isDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }

        public virtual int TemplateDbCapacity
        {
            get
            {
                return this._templateDbCapacity;
            }
            set
            {
                this._templateDbCapacity = value;
                OnPropertyChanged("TemplateDbCapacity");
            }
        }

        public virtual bool ISSELECTED
        {
            get
            {
                return this._IsSelected;
            }
            set
            {
                this._IsSelected = value;
                OnPropertyChanged("ISSELECTED");
            }
        }

        public static FaceTemplateDB Convert(FaceTemplateDBData oridata)
        {
            FaceTemplateDB target = new FaceTemplateDB();

            #region

            target.ID = oridata.ID;
            target.TemplateDbName = oridata.TemplateDbName;
            target.TemplateDbDescription = oridata.TemplateDbDescription;
            target.TemplateDbType = oridata.TemplateDbType;
            target.IsUsed = oridata.IsUsed;
            target.TemplateDbSize = oridata.TemplateDbSize;
            target.CreateTime = TimeConvert.Convert(oridata.CreateTime);
            target.IsDeleted = oridata.IsDeleted;
            target.TemplateDbCapacity = oridata.TemplateDbCapacity;

            #endregion

            return target;
        }

        public static FaceTemplateDBData ConvertToData(FaceTemplateDB oridata)
        {
            FaceTemplateDBData target = new FaceTemplateDBData();

            #region

            target.ID = oridata.ID;
            target.TemplateDbName = oridata.TemplateDbName;
            target.TemplateDbDescription = oridata.TemplateDbDescription;
            target.TemplateDbType = oridata.TemplateDbType;
            target.IsUsed = oridata.IsUsed;
            target.TemplateDbSize = oridata.TemplateDbSize;
            target.CreateTime = TimeConvert.Convert(oridata.CreateTime, "yyyyMMdd HH:mm:ss");
            target.IsDeleted = oridata.IsDeleted;
            target.TemplateDbCapacity = oridata.TemplateDbCapacity;

            #endregion

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
