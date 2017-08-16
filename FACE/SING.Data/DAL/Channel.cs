using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.BaseTools;
using SING.Data.DAL.Data;
using SING.Data.Help;
using SING.Data.Help.Http;
using SING.Data.Help.Json;
using SING.Data.DAL.ScheduleConvert;

namespace SING.Data.DAL
{
    //[JsonObject(MemberSerialization.OptIn)]
    public partial class Channel
    {
        private string _uuid;
        private string _channelName;
        private string _channelDescription;
        private int _channelType;
        private string _channelAddr;
        private int _channelPort;
        private string _channelUid;
        private string _channelPsw;
        private string _channelNo;
        private string _channelGuid;
        private int _minFaceWidth;
        private int _minImgQuality;
        private int _minCapDistance;
        private int _maxSaveDistance;
        private int _maxYaw;
        private int _maxYoll;
        private int _maxPitch;
        private double _channelLongitude;
        private double _channelLatitude;
        private string _channelArea;
        private int _channelDirect;
        private double _channelThreshold;
        private int _capStat;
        private int _isDel;
        private long _lastTimestamp;
        private int _regionId;
        private int _important;
        private int _reserved;
        private string _sdkVer;

        [JsonProperty(PropertyName = "uuid")]
        public virtual string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
            }
        }

        [JsonProperty(PropertyName = "channel_name", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty(PropertyName = "channel_uid", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelUid
        {
            get
            {
                return this._channelUid;
            }
            set
            {
                this._channelUid = value;
            }
        }

        [JsonProperty(PropertyName = "channel_psw", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ChannelPsw
        {
            get
            {
                return this._channelPsw;
            }
            set
            {
                this._channelPsw = value;
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

        [DefaultValue(0.0)]
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

        [DefaultValue(0.0)]
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
        [JsonProperty(PropertyName = "is_del", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IsDel
        {
            get
            {
                return this._isDel;
            }
            set
            {
                this._isDel = value;
            }
        }

        [JsonIgnore]
        [JsonProperty(PropertyName = "last_timestamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long LastTimestamp
        {
            get
            {
                return this._lastTimestamp;
            }
            set
            {
                this._lastTimestamp = value;
            }
        }

        [JsonIgnore]
        public virtual int Reserved
        {
            get
            {
                return this._reserved;
            }
            set
            {
                this._reserved = value;
            }
        }
        [JsonIgnore]
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

        public static List<Channel> ListAllChannel(int startNum = 0, int count = 1000000)
        {
            List<Channel> list = null;

            try
            {
                HttpHelper http = new HttpHelper();
                ChannelParameter jsonData = ParameterConvert.ChannelParameterFromPara(0,startNum, count);
                string postData = JsonHelper.SerializeObject(jsonData);
                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Channel/ListAllChannel", postData);
                HttpResult httpResult = http.GetHtml(item);
                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<Channel>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: ListAllChannel");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询所有通道信息异常！【Channel】-->【函数名】：ListAllChannel", ex);
            }

            return list;
        }

        public static List<Channel> QueryChannel(int regionId, int startNum = 0, int count = 1000000)
        {
            List<Channel> list = null;

            try
            {
                if (regionId == 0) return list;
                HttpHelper http = new HttpHelper();
                ChannelParameter jsonData = ParameterConvert.ChannelParameterFromPara(regionId, startNum, count);
                string postData = JsonHelper.SerializeObject(jsonData);
                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Channel/QueryChannelsByRegionID", postData);
                HttpResult httpResult = http.GetHtml(item);
                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<Channel>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: QueryChannelByRegionID");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询区域通道信息异常！【Channel】-->【函数名】：QueryChannelByRegionID", ex);
            }

            return list;
        }

        public static Channel QueryChannel(string uuid)
        {
            Channel channel = null;

            try
            {
                if (string.IsNullOrEmpty(uuid)) return channel;
                HttpHelper http = new HttpHelper();
                string postData = JsonHelper.SerializeObject(uuid);
                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Channel/QueryChannel", postData);
                HttpResult httpResult = http.GetHtml(item);
                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return channel;

                        json = result.Data.ToString();

                       List<Channel> list = JsonHelper.DeserializeJsonToList<Channel>(json);

                        if (list != null && list.Count > 0)
                        {
                            channel = list[0];
                        }
                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: QueryChannel");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询通道信息异常！【Channel】-->【函数名】：QueryChannel", ex);
            }

            return channel;
        }

        public static Result AddChannel(Channel channel)
        {
            Result result = new Result();
            try
            {
                if (channel == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(channel);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/AddChannel", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: AddChannel");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：新增通道信息异常！【Channel】-->【函数名】：AddChannel", ex);
            }

            return result;
        }

        public static Result ModChannel(Channel channel)
        {
            Result result = new Result();
            try
            {
                if (channel == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(channel);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/ModChannel", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: ModChannel");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：修改通道信息异常！【Channel】-->【函数名】：ModChannel", ex);
            }

            return result;
        }

        public static Result DelChannel(string uuid)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(uuid)) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(uuid);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/DelChannel", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: DelChannel");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除通道信息异常！【Channel】-->【函数名】：DelChannel", ex);
            }

            return result;
        }

        public static Result DelChannel(int regionId)
        {
            Result result = new Result();
            try
            {
                if (regionId == 0) return null;
                HttpHelper http = new HttpHelper();
                string postData = JsonHelper.SerializeObject(regionId);
                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/DelChannelByRegionID", postData);
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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: DelChannelByRegionID");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除通道信息异常！【Channel】-->【函数名】：DelChannelByRegionID", ex);
            }

            return result;
        }

        public static List<string> OpenChannel(List<string> channelIDs)
        {
            List<string> list = null;
            try
            {
                if (channelIDs == null || channelIDs.Count == 0) return list;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(channelIDs);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/OpenChannel", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        list = null;
                    }
                    else
                    {
                        json = result.Data?.ToString();
                        list = JsonHelper.DeserializeJsonToList<string>(json);
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: OpenChannel");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：打开抓拍通道信息异常！【Channel】-->【函数名】：OpenChannel", ex);
            }

            return list;
        }

        public static List<string> CloseChannel(List<string> channelIDs)
        {

            List<string> list = null;
            try
            {
                if (channelIDs == null || channelIDs.Count == 0) return list;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(channelIDs);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/CloseChannel", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        list = null;
                    }
                    else
                    {
                        json = result.Data.ToString();
                        list = JsonHelper.DeserializeJsonToList<string>(json);
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    list = new List<string>();
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: CloseChannel");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：关闭抓拍通道信息异常！【Channel】-->【函数名】：CloseChannel", ex);
            }

            return list;
        }

        public static List<string> OpenAllChannel()
        {
            List<string> list = null;
            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/OpenAllChannel");

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        list = null;
                    }
                    else
                    {
                        json = result.Data.ToString();
                        list = JsonHelper.DeserializeJsonToList<string>(json);
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: OpenAllChannel");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：打开所有抓拍通道信息异常！【Channel】-->【函数名】：OpenAllChannel", ex);
            }

            return list;
        }

        public static List<string> CloseAllChannel()
        {
            List<string> list = null;
            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/Channel/CloseAllChannel");

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        list = null;
                    }
                    else
                    {
                        json = result.Data.ToString();
                        list = JsonHelper.DeserializeJsonToList<string>(json);
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: CloseAllChannel");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：关闭所有抓拍通道信息异常！【Channel】-->【函数名】：CloseAllChannel", ex);
            }

            return list;
        }

        public static Result ChannelIsExist(string channelNo)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(channelNo)) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(channelNo);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Channel/ChannelIsExist", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    result = JsonHelper.DeserializeJsonToObject<Result>(json);
                }
                else
                {
                    result.ErrorCode = StatusCode.Fail;
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: ChannelIsExist");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：验证通道是否存在异常！【Channel】-->【函数名】：ChannelIsExist", ex);
            }

            return result;
        }
    }
}
