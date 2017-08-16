using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.BaseTools;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help.Http;
using SING.Data.Help.Json;

namespace SING.Data.DAL
{
    public partial class Alarm : AlBase
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
        private long _ftImgTime;
        private string _regionName;
        private int _matchedCount;
        private string _rulerName;
        private byte[] _fcapSceneImg;
        private int _fcapFaceX;
        private int _fcapFaceY;
        private int _fcapFaceCx;
        private int _fcapFaceCy;

        [JsonProperty(PropertyName = "fcmp_fobj_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FobjName
        {
            get
            {
                return this._fobjName;
            }
            set
            {
                this._fobjName = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_fobj_sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FobjSex
        {
            get
            {
                return this._fobjSex;
            }
            set
            {
                this._fobjSex = value;
            }
        }

        [JsonProperty(PropertyName = "id_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IdType
        {
            get
            {
                return this._idType;
            }
            set
            {
                this._idType = value;
            }
        }

        [JsonProperty(PropertyName = "id_numb", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string IdNumb
        {
            get
            {
                return this._idNumb;
            }
            set
            {
                this._idNumb = value;
            }
        }

        [JsonProperty(PropertyName = "fcap_obj_img", NullValueHandling = NullValueHandling.Ignore)]
        public virtual byte[] FcapImg
        {
            get
            {
                return this._fcapImg;
            }
            set
            {
                this._fcapImg = value;
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

        [JsonProperty(PropertyName = "ft_image", NullValueHandling = NullValueHandling.Ignore)]
        public virtual byte[] FtImg
        {
            get
            {
                return this._ftImg;
            }
            set
            {
                this._ftImg = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_ft_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FtId
        {
            get
            {
                return this._ftId;
            }
            set
            {
                this._ftId = value;
            }
        }

        [JsonProperty(PropertyName = "ftdb_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FtdbId
        {
            get
            {
                return this._ftdbId;
            }
            set
            {
                this._ftdbId = value;
            }
        }

        [JsonProperty(PropertyName = "template_db_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FtdbName
        {
            get
            {
                return this._ftdbName;
            }
            set
            {
                this._ftdbName = value;
            }
        }

        [JsonProperty(PropertyName = "ft_image_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long FtImgTime
        {
            get
            {
                return this._ftImgTime;
            }
            set
            {
                this._ftImgTime = value;
            }
        }

        [JsonProperty(PropertyName = "region_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string RegionName
        {
            get
            {
                return this._regionName;
            }
            set
            {
                this._regionName = value;
            }
        }

        [JsonProperty(PropertyName = "matched_count", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int MatchedCount
        {
            get
            {
                return this._matchedCount;
            }
            set
            {
                this._matchedCount = value;
            }
        }


        [JsonProperty(PropertyName = "ruler_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string RulerName
        {
            get
            {
                return this._rulerName;
            }
            set
            {
                this._rulerName = value;
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

        public static Result AddAlarms(List<Alarm> alerts)
        {
            Result result = new Result();
            try
            {
                if (alerts == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(alerts);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Alerts/AddSecAlerts", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Alarm】-->【函数名】: AddAlarms");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：新增告警记录异常！【Alarm】-->【函数名】：AddAlarms", ex);
            }

            return result;
        }

        public static List<Alarm> QueryAlarms(string json)
        {
            List<Alarm> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Alerts/QuerySecAlerts", json);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonData = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(jsonData);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        jsonData = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<Alarm>(jsonData);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Alarm】-->【函数名】: QueryAlarms");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询告警记录异常！【Alarm】-->【函数名】：QueryAlarms", ex);
            }

            return list;
        }

        public static Result ModAlarm(string uuid, string oper, int stat, long timeStamp, bool force)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(oper)) return null;

                HttpHelper http = new HttpHelper();

                AlertOpParameter jsonData = ParameterConvert.AlertOpParameterFromPara(uuid, oper, stat, timeStamp, force);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Alerts/AckSecAlert", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Alarm】-->【函数名】: ModAlarm");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：修改告警记录异常！【Alarm】-->【函数名】：ModAlarm", ex);
            }

            return result;
        }

        public static Result SendAlarm(string uuid, string oper, int stat, long timeStamp, bool force)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(oper)) return null;

                HttpHelper http = new HttpHelper();

                AlertOpParameter jsonData = ParameterConvert.AlertOpParameterFromPara(uuid, oper, stat, timeStamp, force);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Alerts/PubSecAlert", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Alarm】-->【函数名】: SendAlarm");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：发送告警记录异常！【Alarm】-->【函数名】：SendAlarm", ex);
            }

            return result;
        }
    }
}
