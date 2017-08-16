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
    public class FaceObjectData : INotifyPropertyChanged
    {
        private int _ftdbId;
        private string _uuid;
        private string _mainFtID;
        private string _name;
        private int _type;
        private int _sst;
        private int _sex;
        private string _timeStamp;
        private string _remarks;
        private string _idNumb;
        private int _idType;
        private string _birthDate;
        private string _addr;
        private string _ethnic;
        private string _tag;

        public virtual int FTDBID
        {
            get
            {
                return this._ftdbId;
            }
            set
            {
                this._ftdbId = value;
                OnPropertyChanged("FTDBID");
            }
        }

        public virtual string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
                OnPropertyChanged("Uuid");
            }
        }

        public virtual string MainFtID
        {
            get
            {
                return this._mainFtID;
            }
            set
            {
                this._mainFtID = value;
                OnPropertyChanged("MainFtID");
            }
        }

        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                OnPropertyChanged("Name");
            }
        }

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

        public virtual int Sst
        {
            get
            {
                return this._sst;
            }
            set
            {
                this._sst = value;
                OnPropertyChanged("Sst");
            }
        }

        public virtual int Sex
        {
            get
            {
                return this._sex;
            }
            set
            {
                this._sex = value;
                OnPropertyChanged("Sex");
            }
        }

        public virtual string TimeStamp
        {
            get
            {
                return this._timeStamp;
            }
            set
            {
                this._timeStamp = value;
                OnPropertyChanged("TimeStamp");
            }
        }

        public virtual string Remarks
        {
            get
            {
                return this._remarks;
            }
            set
            {
                this._remarks = value;
                OnPropertyChanged("Remarks");
            }
        }

        public virtual string IdNumb
        {
            get
            {
                return this._idNumb;
            }
            set
            {
                this._idNumb = value;
                OnPropertyChanged("IdNumb");
            }
        }

        public virtual int IdType
        {
            get
            {
                return this._idType;
            }
            set
            {
                this._idType = value;
                OnPropertyChanged("IdType");
            }
        }

        public virtual string BirthDate
        {
            get
            {
                return this._birthDate;
            }
            set
            {
                this._birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public virtual string Addr
        {
            get
            {
                return this._addr;
            }
            set
            {
                this._addr = value;
                OnPropertyChanged("Addr");
            }
        }

        public virtual string Ethnic
        {
            get
            {
                return this._ethnic;
            }
            set
            {
                this._ethnic = value;
                OnPropertyChanged("Ethnic");
            }
        }

        public virtual string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
                OnPropertyChanged("Tag");
            }
        }

        public static FaceObject Convert(FaceObjectData oridata)
        {
            FaceObject target = new FaceObject();
            target.FTDBID = oridata.FTDBID;
            target.Uuid = oridata.Uuid;
            target.MainFtID = oridata.MainFtID;
            target.Name = oridata.Name;
            target.Type = oridata.Type;
            target.Sst = oridata.Sst;
            target.Sex = oridata.Sex;
            target.TimeStamp = TimeConvert.Convert(oridata.TimeStamp);
            target.Remarks = oridata.Remarks;
            target.IdNumb = oridata.IdNumb;
            target.IdType = oridata.IdType;
            target.BirthDate = oridata.BirthDate.SToShortDateLong();
            target.Addr = oridata.Addr;
            target.Ethnic = oridata.Ethnic;
            target.Tag = oridata.Tag;
            return target;
        }

        public static FaceObjectData ConvertToData(FaceObject oridata)
        {
            FaceObjectData target = new FaceObjectData();
            target.FTDBID = oridata.FTDBID;
            target.Uuid = oridata.Uuid;
            target.MainFtID = oridata.MainFtID;
            target.Name = oridata.Name;
            target.Type = oridata.Type;
            target.Sst = oridata.Sst;
            target.Sex = oridata.Sex;
            target.TimeStamp = oridata.TimeStamp.LToString();
            target.Remarks = oridata.Remarks;
            target.IdNumb = oridata.IdNumb;
            target.IdType = oridata.IdType;
            target.BirthDate = oridata.BirthDate.LToShortDateString();
            target.Addr = oridata.Addr;
            target.Ethnic = oridata.Ethnic;
            target.Tag = oridata.Tag;
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
