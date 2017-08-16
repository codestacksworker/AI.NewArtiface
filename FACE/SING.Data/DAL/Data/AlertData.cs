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
    public class AlertData : AlDataBase
    {
        private string _fobjName;
        private int _fobjSex;
        private int _idType;
        private string _idNumb;
        private byte[] _fcapImg;
        private double _channelLongitude;
        private double _channelLatitude;
        private int _channelDirect;
        private string _channelName;
        private string _channelArea;
        private double _channelThreshold;
        private int _ftdbId;
        private string _ftdbName;
        private string _ftId;
        private byte[] _ftImg;
        private string _ftImgTime;
        private int _regionId;
        private string _regionName;
        private int _matchedCount;
        private string _rulerName;
        private byte[] _fcapSceneImg;
        private int _fcapFaceX;
        private int _fcapFaceY;
        private int _fcapFaceCx;
        private int _fcapFaceCy;

        public virtual string FobjName
        {
            get
            {
                return this._fobjName;
            }
            set
            {
                this._fobjName = value;
                OnPropertyChanged("FobjName");
            }
        }

        public virtual int FobjSex
        {
            get
            {
                return this._fobjSex;
            }
            set
            {
                this._fobjSex = value;
                OnPropertyChanged("FobjSex");
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

        public virtual byte[] FcapImg
        {
            get
            {
                return this._fcapImg;
            }
            set
            {
                this._fcapImg = value;
                OnPropertyChanged("FcapImg");
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

        public virtual double ChannelThreshold
        {
            get
            {
                return this._channelThreshold;
            }
            set
            {
                this._channelThreshold = value;
                OnPropertyChanged("ChannelThreshold");
            }
        }

        public virtual int FtdbId
        {
            get
            {
                return this._ftdbId;
            }
            set
            {
                this._ftdbId = value;
                OnPropertyChanged("FtdbId");
            }
        }

        public virtual string FtdbName
        {
            get
            {
                return this._ftdbName;
            }
            set
            {
                this._ftdbName = value;
                OnPropertyChanged("FtdbName");
            }
        }

        public virtual string FtId
        {
            get
            {
                return this._ftId;
            }
            set
            {
                this._ftId = value;
                OnPropertyChanged("FtId");
            }
        }

        public virtual byte[] FtImg
        {
            get
            {
                return this._ftImg;
            }
            set
            {
                this._ftImg = value;
                OnPropertyChanged("FtImg");
            }
        }

        public virtual string FtImgTime
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

        public virtual int RegionId
        {
            get
            {
                return this._regionId;
            }
            set
            {
                this._regionId = value;
                OnPropertyChanged("RegionId");
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

        public virtual int MatchedCount
        {
            get
            {
                return this._matchedCount;
            }
            set
            {
                this._matchedCount = value;
                OnPropertyChanged("MatchedCount");
            }
        }

        public virtual string RulerName
        {
            get
            {
                return this._rulerName;
            }
            set
            {
                this._rulerName = value;
                OnPropertyChanged("RulerName");
            }
        }

        public virtual byte[] FcapSceneImg
        {
            get
            {
                return this._fcapSceneImg;
            }
            set
            {
                this._fcapSceneImg = value;
                OnPropertyChanged("FcapSceneImg");
            }
        }

        public virtual int FcapFaceX
        {
            get
            {
                return this._fcapFaceX;
            }
            set
            {
                this._fcapFaceX = value;
                OnPropertyChanged("FcapFaceX");
            }
        }

        public virtual int FcapFaceY
        {
            get
            {
                return this._fcapFaceY;
            }
            set
            {
                this._fcapFaceY = value;
                OnPropertyChanged("FcapFaceY");
            }
        }

        public virtual int FcapFaceCx
        {
            get
            {
                return this._fcapFaceCx;
            }
            set
            {
                this._fcapFaceCx = value;
                OnPropertyChanged("FcapFaceCx");
            }
        }

        public virtual int FcapFaceCy
        {
            get
            {
                return this._fcapFaceCy;
            }
            set
            {
                this._fcapFaceCy = value;
                OnPropertyChanged("FcapFaceCy");
            }
        }

        public static Alert Convert(AlertData oridata)
        {
            Alert target = new Alert();

            #region

            target.Uuid = oridata.Uuid;
            target.FcapId = oridata.FcapId;
            target.FobjId = oridata.FobjId;
            target.FobjName = oridata.FobjName;
            target.FobjSex = oridata.FobjSex;
            target.IdType = oridata.IdType;
            target.IdNumb = oridata.IdNumb;
            target.FcapTime = oridata.FcapTime.SToLong();
            target.AlertTime = oridata.AlertTime.SToLong();
            target.ChannelId = oridata.ChannelId;
            target.FcapImg = oridata.FcapImg;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.ChannelName = oridata.ChannelName;
            target.ChannelArea = oridata.ChannelArea;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.FtImg = oridata.FtImg;
            target.FtId = oridata.FtId;
            target.FtdbId = oridata.FtdbId;
            target.FtdbName = oridata.FtdbName;
            target.RulerId = oridata.RulerId;
            target.FtImgTime = oridata.FtImgTime.SToLong();
            target.FcmpSocre = oridata.FcmpSocre;
            target.AckStat = oridata.AckStat;
            target.AckTime = oridata.AckTime.SToLong();
            target.Acker = oridata.Acker;
            target.PubStat = oridata.PubStat;
            target.PubTime = oridata.PubTime.SToLong();
            target.Puber = oridata.Puber;
            target.RegionName = oridata.RegionName;
            target.MatchedCount = oridata.MatchedCount;
            target.RulerName = oridata.RulerName;
            target.FcapSceneImg = oridata.FcapSceneImg;
            target.FcapFaceX = oridata.FcapFaceX;
            target.FcapFaceY = oridata.FcapFaceY;
            target.FcapFaceCx = oridata.FcapFaceCx;
            target.FcapFaceCy = oridata.FcapFaceCy;

            #endregion

            return target;
        }

        public static AlertData ConvertToData(Alert oridata)
        {
            AlertData target = new AlertData();

            #region

            target.Uuid = oridata.Uuid;
            target.FcapId = oridata.FcapId;
            target.FobjId = oridata.FobjId;
            target.FobjName = oridata.FobjName;
            target.FobjSex = oridata.FobjSex;
            target.IdType = oridata.IdType;
            target.IdNumb = oridata.IdNumb;
            target.FcapTime = oridata.FcapTime.LToString();
            target.AlertTime = oridata.AlertTime.LToString();
            target.ChannelId = oridata.ChannelId;
            target.FcapImg = oridata.FcapImg;
            target.ChannelLongitude = oridata.ChannelLongitude;
            target.ChannelLatitude = oridata.ChannelLatitude;
            target.ChannelDirect = oridata.ChannelDirect;
            target.ChannelName = oridata.ChannelName;
            target.ChannelArea = oridata.ChannelArea;
            target.ChannelThreshold = oridata.ChannelThreshold;
            target.FtImg = oridata.FtImg;
            target.FtId = oridata.FtId;
            target.FtdbId = oridata.FtdbId;
            target.FtdbName = oridata.FtdbName;
            target.RulerId = oridata.RulerId;
            target.FtImgTime = oridata.FtImgTime.LToString();
            target.FcmpSocre = oridata.FcmpSocre;
            target.AckStat = oridata.AckStat;
            target.AckTime = oridata.AckTime.LToString();
            target.Acker = oridata.Acker;
            target.PubStat = oridata.PubStat;
            target.PubTime = oridata.PubTime.LToString();
            target.Puber = oridata.Puber;
            target.RegionName = oridata.RegionName;
            target.MatchedCount = oridata.MatchedCount;
            target.RulerName = oridata.RulerName;
            target.FcapSceneImg = oridata.FcapSceneImg;
            target.FcapFaceX = oridata.FcapFaceX;
            target.FcapFaceY = oridata.FcapFaceY;
            target.FcapFaceCx = oridata.FcapFaceCx;
            target.FcapFaceCy = oridata.FcapFaceCy;

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
    }
}
