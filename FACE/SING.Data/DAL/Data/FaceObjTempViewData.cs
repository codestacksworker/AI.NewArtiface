using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class FaceObjTempViewData : INotifyPropertyChanged
    {
        private int _ftdbId;
        private string _templateDbName;
        private string _uuid;
        private string _mainFtID;
        private string _name;
        private int _type;
        private int _sst;
        private string _age;
        private int _sex;
        private string _timeStamp;
        private string _remarks;
        private string _idNumb;
        private int _idType;
        private string _birthDate;
        private string _addr;
        private string _ethnic;
        private string _tag;
        private List<FaceTemplateData> _temps;
        private FaceTemplateData _temp;
        private int _fcmpOrder;
        private double _fcmpSocre;

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

        public virtual string Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
                OnPropertyChanged("Age");
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

        public virtual List<FaceTemplateData> Temps
        {
            get
            {
                return this._temps;
            }
            set
            {
                this._temps = value;
                OnPropertyChanged("Temps");
            }
        }

        public virtual FaceTemplateData Temp
        {
            get
            {
                return this._temp;
            }
            set
            {
                this._temp = value;
                OnPropertyChanged("Temp");
            }
        }

        public virtual int FcmpOrder
        {
            get
            {
                return this._fcmpOrder;
            }
            set
            {
                this._fcmpOrder = value;
                OnPropertyChanged("FcmpOrder");
            }
        }

        public virtual double FcmpSocre
        {
            get
            {
                return this._fcmpSocre;
            }
            set
            {
                this._fcmpSocre = value;
                OnPropertyChanged("FcmpSocre");
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

        public static void DeepCopyValue(object origin, object target)
        {
            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.PropertyInfo[] fields = (origin.GetType()).GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {
                    if (fields[i].Name.ToUpper() == properties[j].Name.ToUpper() && properties[j].CanWrite)
                    {
                        List<FaceTemplateData> temps = fields[i].GetValue(origin, null) as List<FaceTemplateData>;
                        if (temps != null)
                        {
                            properties[j].SetValue(target, CopyTemps(temps), null);
                            break;
                        }

                        FaceTemplateData data = fields[i].GetValue(origin, null) as FaceTemplateData;
                        if (data != null)
                        {
                            properties[j].SetValue(target, FaceTemplateData.CopyData(data), null);
                            break;
                        }

                        properties[j].SetValue(target, fields[i].GetValue(origin, null), null);
                    }
                }
            }
        }


        public static List<FaceTemplateData> CopyTemps(List<FaceTemplateData> temps)
        {
            List<FaceTemplateData> result = new List<FaceTemplateData>() { null, null, null, null, null };
            if (temps == null) return result;
            for (int i = 0; i < temps.Count; i++)
            {
                FaceTemplateData data = temps[i] as FaceTemplateData;
                if (data != null)
                {
                    result[i] = FaceTemplateData.CopyData(data);
                }
            }
            return result;
        }
    }
}
