using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.BaseTools;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Help.Http;
using SING.Data.Help.Json;

namespace SING.Data.DAL
{
    public partial class FaceCapture
    {
        private string _fcapId;
        private string _fcapDcid;
        private long _fcapTime;
        private int _fcapQuality;
        private int _fcapType;
        private int _fcapFaceX;
        private int _fcapFaceY;
        private int _fcapFaceCx;
        private int _fcapFaceCy;
        private int _fcapSex;
        private int _fcapAge;
        private byte[] _fcapObjImg;
        private byte[] _fcapSceneImg;
        private double _channelLongitude;
        private double _channelLatitude;
        private int _channelDirect;
        private byte[] _fcapObjFeat;
        private string _channelName;

        private string _channelDescription;
        private string _channelAddr;
        private int _channelPort;
        private int _channelType;
        private int _regionId;
        private string _channelNo;
        private string _channelGuid;
        private string _channelArea;
        private string _sdkVer;
        private int _minFaceWidth;
        private int _minImgQuality;
        private int _minCapDistance;
        private int _maxSaveDistance;
        private int _maxYaw;
        private int _maxYoll;
        private int _maxPitch;
        private double _channelThreshold;
        private int _capStat;
        private int _important;


        [JsonProperty(PropertyName = "fcap_id")]
        public virtual string FcapId
        {
            get
            {
                return this._fcapId;
            }
            set
            {
                this._fcapId = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_dcid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FcapDcid
        {
            get
            {
                return this._fcapDcid;
            }
            set
            {
                this._fcapDcid = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long FcapTime
        {
            get
            {
                return this._fcapTime;
            }
            set
            {
                this._fcapTime = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_quality", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapQuality
        {
            get
            {
                return this._fcapQuality;
            }
            set
            {
                this._fcapQuality = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapType
        {
            get
            {
                return this._fcapType;
            }
            set
            {
                this._fcapType = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_face_x", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapFaceX
        {
            get
            {
                return this._fcapFaceX;
            }
            set
            {
                this._fcapFaceX = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_face_y", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapFaceY
        {
            get
            {
                return this._fcapFaceY;
            }
            set
            {
                this._fcapFaceY = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_face_cx", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapFaceCx
        {
            get
            {
                return this._fcapFaceCx;
            }
            set
            {
                this._fcapFaceCx = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_face_cy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapFaceCy
        {
            get
            {
                return this._fcapFaceCy;
            }
            set
            {
                this._fcapFaceCy = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapSex
        {
            get
            {
                return this._fcapSex;
            }
            set
            {
                this._fcapSex = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_age", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcapAge
        {
            get
            {
                return this._fcapAge;
            }
            set
            {
                this._fcapAge = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_obj_img", NullValueHandling = NullValueHandling.Ignore)]
        public virtual byte[] FcapObjImg
        {
            get
            {
                return this._fcapObjImg;
            }
            set
            {
                this._fcapObjImg = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_scene_img", NullValueHandling = NullValueHandling.Ignore)]
        public virtual byte[] FcapSceneImg
        {
            get
            {
                return this._fcapSceneImg;
            }
            set
            {
                this._fcapSceneImg = value;
            }
        }

        [JsonProperty(PropertyName = "channel_longitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual double ChannelLongitude
        {
            get
            {
                return this._channelLongitude;
            }
            set
            {
                this._channelLongitude = value;
            }
        }

        [JsonProperty(PropertyName = "channel_latitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual double ChannelLatitude
        {
            get
            {
                return this._channelLatitude;
            }
            set
            {
                this._channelLatitude = value;
            }
        }

        [JsonProperty(PropertyName = "channel_direct", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int ChannelDirect
        {
            get
            {
                return this._channelDirect;
            }
            set
            {
                this._channelDirect = value;
            }
        }

        [JsonProperty(PropertyName = "channel_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string ChannelName
        {
            get
            {
                return this._channelName;
            }
            set
            {
                this._channelName = value;
            }
        }

        [JsonProperty(PropertyName = "channel_description", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelDescription
        {
            get
            {
                return this._channelDescription;
            }
            set
            {
                this._channelDescription = value;
            }
        }

        [JsonProperty(PropertyName = "channel_addr", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelAddr
        {
            get
            {
                return this._channelAddr;
            }
            set
            {
                this._channelAddr = value;
            }
        }

        [JsonProperty(PropertyName = "channel_port", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int ChannelPort
        {
            get
            {
                return this._channelPort;
            }
            set
            {
                this._channelPort = value;
            }
        }

        [JsonProperty(PropertyName = "channel_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int ChannelType
        {
            get
            {
                return this._channelType;
            }
            set
            {
                this._channelType = value;
            }
        }

        [JsonProperty(PropertyName = "region_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int RegionId
        {
            get
            {
                return this._regionId;
            }
            set
            {
                this._regionId = value;
            }
        }

        [JsonProperty(PropertyName = "channel_no", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string ChannelNo
        {
            get
            {
                return this._channelNo;
            }
            set
            {
                this._channelNo = value;
            }
        }

        [JsonProperty(PropertyName = "channel_guid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelGuid
        {
            get
            {
                return this._channelGuid;
            }
            set
            {
                this._channelGuid = value;
            }
        }

        [JsonProperty(PropertyName = "channel_area", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelArea
        {
            get
            {
                return this._channelArea;
            }
            set
            {
                this._channelArea = value;
            }
        }

        [JsonProperty(PropertyName = "sdk_ver", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string SdkVer
        {
            get
            {
                return this._sdkVer;
            }
            set
            {
                this._sdkVer = value;
            }
        }

        [JsonProperty(PropertyName = "min_face_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MinFaceWidth
        {
            get
            {
                return this._minFaceWidth;
            }
            set
            {
                this._minFaceWidth = value;
            }
        }

        [JsonProperty(PropertyName = "min_img_quality", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MinImgQuality
        {
            get
            {
                return this._minImgQuality;
            }
            set
            {
                this._minImgQuality = value;
            }
        }

        [JsonProperty(PropertyName = "min_cap_distance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MinCapDistance
        {
            get
            {
                return this._minCapDistance;
            }
            set
            {
                this._minCapDistance = value;
            }
        }

        [JsonProperty(PropertyName = "max_save_distance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MaxSaveDistance
        {
            get
            {
                return this._maxSaveDistance;
            }
            set
            {
                this._maxSaveDistance = value;
            }
        }

        [JsonProperty(PropertyName = "max_yaw", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MaxYaw
        {
            get
            {
                return this._maxYaw;
            }
            set
            {
                this._maxYaw = value;
            }
        }

        [JsonProperty(PropertyName = "max_roll", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MaxYoll
        {
            get
            {
                return this._maxYoll;
            }
            set
            {
                this._maxYoll = value;
            }
        }

        [JsonProperty(PropertyName = "max_pitch", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MaxPitch
        {
            get
            {
                return this._maxPitch;
            }
            set
            {
                this._maxPitch = value;
            }
        }

        [JsonProperty(PropertyName = "channel_threshold", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual double ChannelThreshold
        {
            get
            {
                return this._channelThreshold;
            }
            set
            {
                this._channelThreshold = value;
            }
        }

        [JsonProperty(PropertyName = "cap_stat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int CapStat
        {
            get
            {
                return this._capStat;
            }
            set
            {
                this._capStat = value;
            }
        }

        [JsonProperty(PropertyName = "important", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Important
        {
            get
            {
                return this._important;
            }
            set
            {
                this._important = value;
            }
        }

        [JsonIgnore]
        public virtual byte[] FcapObjFeat
        {
            get
            {
                return this._fcapObjFeat;
            }
            set
            {
                this._fcapObjFeat = value;
            }
        }

        public static List<FaceCapture> QueryCapLog(string json)
        {
            List<FaceCapture> list = null;

            try
            {

                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceCapture/QueryCapLog", json);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonData = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(jsonData);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        jsonData = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceCapture>(jsonData);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceCapture】-->【函数名】: QueryCapLog");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询抓拍记录信息异常！【FaceCapture】-->【函数名】：QueryCapLog", ex);
            }

            return list;
        }

        public static List<FaceCapture> QueryFaceCap(string json)
        {
            List<FaceCapture> list = null;

            try
            {

                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceCapture/QueryFaceCap", json);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonData = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(jsonData);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        jsonData = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceCapture>(jsonData);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceCapture】-->【函数名】: QueryFaceCap");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询抓拍记录信息异常！【FaceCapture】-->【函数名】：QueryFaceCap", ex);
            }

            return list;
        }

        public static FaceCapture QueryCapImg(string fcapId, long fcaptime)
        {
            List<FaceCapture> list = null;

            try
            {

                HttpHelper http = new HttpHelper();

                CapParameter jsonObj = ParameterConvert.CapParaFromPara(fcapId, fcaptime);

                string postData = JsonHelper.SerializeObject(jsonObj);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceCapture/QueryCapImg", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonData = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(jsonData);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return null;

                        jsonData = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceCapture>(jsonData);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceCapture】-->【函数名】: QueryFaceCap");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询抓拍记录信息异常！【FaceCapture】-->【函数名】：QueryFaceCap", ex);
            }

            return list?.FirstOrDefault();
        }

        public static Result DelFaceCap(string fcapId)
        {
            Result result = new Result();

            try
            {
                if (string.IsNullOrEmpty(fcapId)) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(fcapId);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceCapture/DelFaceCap", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    result = JsonHelper.DeserializeJsonToObject<Result>(json);

                    if (result.ErrorCode != StatusCode.Success)
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    result.ErrorCode = StatusCode.Fail;
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceCapture】-->【函数名】: DelFaceCap");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除抓拍记录信息异常！【FaceCapture】-->【函数名】：DelFaceCap", ex);
            }

            return result;
        }
    }
}
