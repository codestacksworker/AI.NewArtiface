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
    public class FcmpCaptureAlarmData : INotifyPropertyChanged
    {
        private string _uuid;
        private string _fcmpCapId;
        private string _fcmpCapChannel;
        private string _fcmpTime;
        private int _fcmpOrder;
        private double _fcmpSocre;
        private string _fcmpFobjId;
        private string _fcmpFobjName;
        private int _fcmpFobjType;
        private int _fcmpFobjSex;
        private int _fcmpType;
        private double _channelLongitude;
        private double _channelLatitude;
        private int _channelDirect;
        private string _fcapTime;
        private string _fcmpFtId;
        private int _ftdbId;
        private string _templateDbName;
        private string _channelName;
        private byte[] _fcapObjImg;
        private byte[] _ftImage;
        private string _channelArea;
        private long _ftImgTime;
        private string _idNumb;
        private int _idType;

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

        public virtual string FcmpCapId
        {
            get
            {
                return this._fcmpCapId;
            }
            set
            {
                this._fcmpCapId = value;
                OnPropertyChanged("FcmpCapId");
            }
        }

        public virtual string FcmpCapChannel
        {
            get
            {
                return this._fcmpCapChannel;
            }
            set
            {
                this._fcmpCapChannel = value;
                OnPropertyChanged("FcmpCapChannel");
            }
        }

        public virtual string FcmpTime
        {
            get
            {
                return this._fcmpTime;
            }
            set
            {
                this._fcmpTime = value;
                OnPropertyChanged("FcmpTime");
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

        public virtual string FcmpFobjId
        {
            get
            {
                return this._fcmpFobjId;
            }
            set
            {
                this._fcmpFobjId = value;
                OnPropertyChanged("FcmpFobjId");
            }
        }

        public virtual string FcmpFobjName
        {
            get
            {
                return this._fcmpFobjName;
            }
            set
            {
                this._fcmpFobjName = value;
                OnPropertyChanged("FcmpFobjName");
            }
        }

        public virtual int FcmpFobjType
        {
            get
            {
                return this._fcmpFobjType;
            }
            set
            {
                this._fcmpFobjType = value;
                OnPropertyChanged("FcmpFobjType");
            }
        }

        public virtual int FcmpFobjSex
        {
            get
            {
                return this._fcmpFobjSex;
            }
            set
            {
                this._fcmpFobjSex = value;
                OnPropertyChanged("FcmpFobjSex");
            }
        }

        public virtual int FcmpType
        {
            get
            {
                return this._fcmpType;
            }
            set
            {
                this._fcmpType = value;
                OnPropertyChanged("FcmpType");
            }
        }

        public virtual double ChannelLongitude
        {
            get
            {
                return this._channelLongitude;
            }
            set
            {
                this._channelLongitude = value;
                OnPropertyChanged("ChannelLongitude");
            }
        }

        public virtual double ChannelLatitude
        {
            get
            {
                return this._channelLatitude;
            }
            set
            {
                this._channelLatitude = value;
                OnPropertyChanged("ChannelLatitude");
            }
        }

        public virtual int ChannelDirect
        {
            get
            {
                return this._channelDirect;
            }
            set
            {
                this._channelDirect = value;
                OnPropertyChanged("ChannelDirect");
            }
        }

        public virtual string FcapTime
        {
            get
            {
                return this._fcapTime;
            }
            set
            {
                this._fcapTime = value;
                OnPropertyChanged("FcapTime");
            }
        }

        public virtual string FcmpFtId
        {
            get
            {
                return this._fcmpFtId;
            }
            set
            {
                this._fcmpFtId = value;
                OnPropertyChanged("FcmpFtId");
            }
        }

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

        public virtual string ChannelName
        {
            get
            {
                return this._channelName;
            }
            set
            {
                this._channelName = value;
                OnPropertyChanged("ChannelName");
            }
        }

        public virtual byte[] FcapObjImg
        {
            get
            {
                return this._fcapObjImg;
            }
            set
            {
                this._fcapObjImg = value;
                OnPropertyChanged("FcapObjImg");
            }
        }

        public virtual byte[] FtImage
        {
            get
            {
                return this._ftImage;
            }
            set
            {
                this._ftImage = value;
                OnPropertyChanged("FtImage");
            }
        }

        public virtual string ChannelArea
        {
            get
            {
                return this._channelArea;
            }
            set
            {
                this._channelArea = value;
                OnPropertyChanged("ChannelArea");
            }
        }

        public virtual long FtImgTime
        {
            get
            {
                return this._ftImgTime;
            }
            set
            {
                this._ftImgTime = value;
                OnPropertyChanged("FtImgTime");
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

        public static FcmpCaptureAlarm Convert(FcmpCaptureAlarmData oridata)
        {
            FcmpCaptureAlarm target = new FcmpCaptureAlarm();

            #region

            target.Uuid = oridata.Uuid;
            target.FcmpCapId = oridata.FcmpCapId;
            target.FcmpCapChannel = oridata.FcmpCapChannel;
            target.FcmpTime = TimeConvert.Convert(oridata.FcmpTime);
            target.FcmpOrder = oridata.FcmpOrder;
            target.FcmpSocre = oridata.FcmpSocre;
            target.FcmpFobjId = oridata.FcmpFobjId;
            target.FcmpFobjName = oridata.FcmpFobjName;
            target.FcmpFobjType = oridata.FcmpFobjType;
            target.FcmpFobjSex = oridata.FcmpFobjSex;
            target.FcmpType = oridata.FcmpType;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.FcapTime = TimeConvert.Convert(oridata.FcapTime);
            target.FcmpFtId = oridata.FcmpFtId;
            target.FTDBID = oridata.FTDBID;
            target.ChannelName = oridata.ChannelName;
            target.FcapObjImg = oridata.FcapObjImg;
            target.FtImage = oridata.FtImage;
            target.ChannelArea = oridata.ChannelArea;
            target.FtImgTime = oridata.FtImgTime;
            target.IdNumb = oridata.IdNumb;
            target.IdType = oridata.IdType;

            #endregion

            return target;
        }

        public static FcmpCaptureAlarmData ConvertToData(FcmpCaptureAlarm oridata)
        {
            FcmpCaptureAlarmData target = new FcmpCaptureAlarmData();

            #region

            target.Uuid = oridata.Uuid;
            target.FcmpCapId = oridata.FcmpCapId;
            target.FcmpCapChannel = oridata.FcmpCapChannel;
            target.FcmpTime = TimeConvert.Convert(oridata.FcmpTime, "yyyyMMdd HH:mm:ss");
            target.FcmpOrder = oridata.FcmpOrder;
            target.FcmpSocre = (int)oridata.FcmpSocre;
            target.FcmpFobjId = oridata.FcmpFobjId;
            target.FcmpFobjName = oridata.FcmpFobjName;
            target.FcmpFobjType = oridata.FcmpFobjType;
            target.FcmpFobjSex = oridata.FcmpFobjSex;
            target.FcmpType = oridata.FcmpType;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.FcapTime = TimeConvert.Convert(oridata.FcapTime, "yyyyMMdd HH:mm:ss");
            target.FcmpFtId = oridata.FcmpFtId;
            target.FTDBID = oridata.FTDBID;
            target.ChannelName = oridata.ChannelName;
            target.FcapObjImg = oridata.FcapObjImg;
            target.FtImage = oridata.FtImage;
            target.ChannelArea = oridata.ChannelArea;
            target.FtImgTime = oridata.FtImgTime;
            target.IdNumb = oridata.IdNumb;
            target.IdType = oridata.IdType;

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
