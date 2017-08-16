using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Help.Http;
using SING.Data.Help.Json;
using SING.Data.BaseTools;

namespace SING.Data.DAL
{
    public partial class FcmpCaptureAlarm
    {
        private string _uuid;
        private string _fcmpCapId;
        private string _fcmpCapChannel;
        private long _fcmpTime;
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
        private long _fcapTime;
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

        [JsonProperty(PropertyName = "fcmp_cap_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FcmpCapId
        {
            get
            {
                return this._fcmpCapId;
            }
            set
            {
                this._fcmpCapId = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_cap_channel", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FcmpCapChannel
        {
            get
            {
                return this._fcmpCapChannel;
            }
            set
            {
                this._fcmpCapChannel = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long FcmpTime
        {
            get
            {
                return this._fcmpTime;
            }
            set
            {
                this._fcmpTime = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_order", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcmpOrder
        {
            get
            {
                return this._fcmpOrder;
            }
            set
            {
                this._fcmpOrder = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_socre", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual double FcmpSocre
        {
            get
            {
                return this._fcmpSocre;
            }
            set
            {
                this._fcmpSocre = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_fobj_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FcmpFobjId
        {
            get
            {
                return this._fcmpFobjId;
            }
            set
            {
                this._fcmpFobjId = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_fobj_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FcmpFobjName
        {
            get
            {
                return this._fcmpFobjName;
            }
            set
            {
                this._fcmpFobjName = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_fobj_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcmpFobjType
        {
            get
            {
                return this._fcmpFobjType;
            }
            set
            {
                this._fcmpFobjType = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_fobj_sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcmpFobjSex
        {
            get
            {
                return this._fcmpFobjSex;
            }
            set
            {
                this._fcmpFobjSex = value;
            }
        }

        [JsonProperty(PropertyName = "fcmp_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FcmpType
        {
            get
            {
                return this._fcmpType;
            }
            set
            {
                this._fcmpType = value;
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

        [JsonProperty(PropertyName = "fcmp_ft_id", NullValueHandling  = NullValueHandling.Ignore)]
        public virtual string FcmpFtId
        {
            get
            {
                return this._fcmpFtId;
            }
            set
            {
                this._fcmpFtId = value;
            }
        }

        [JsonProperty(PropertyName = "template_db_name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string TemplateDbName
        {
            get
            {
                return this._templateDbName;
            }
            set
            {
                this._templateDbName = value;
            }
        }

        [JsonProperty(PropertyName = "ftdb_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int FTDBID
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

        [JsonProperty(PropertyName = "ft_image", NullValueHandling = NullValueHandling.Ignore)]
        public virtual byte[] FtImage
        {
            get
            {
                return this._ftImage;
            }
            set
            {
                this._ftImage = value;
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

        [JsonProperty(PropertyName = "fobj_id_numb", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty(PropertyName = "fobj_id_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
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

        public static List<FcmpCaptureAlarm> QueryCmpLog(string json)
        {
            List<FcmpCaptureAlarm> list = null;

            try
            {

                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FcmpCaptureAlarm/QueryCmpLog", json);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonData = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(jsonData);

                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        jsonData = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FcmpCaptureAlarm>(jsonData);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FcmpCaptureAlarm】-->【函数名】: QueryCmpLog");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询比对记录信息异常！【FcmpCaptureAlarm】-->【函数名】：QueryCmpLog", ex);
            }

            return list;
        }

        public static List<FcmpCaptureAlarm> QueryCmpLogWithImg(string json)
        {
            List<FcmpCaptureAlarm> list = null;

            try
            {

                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FcmpCaptureAlarm/QueryCmpLogWithImg ", json);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonData = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(jsonData);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        jsonData = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FcmpCaptureAlarm>(jsonData);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FcmpCaptureAlarm】-->【函数名】: QueryCmpLogWithImg");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询比对记录信息异常！【FcmpCaptureAlarm】-->【函数名】：QueryCmpLogWithImg", ex);
            }

            return list;
        }

        public static Result DelFaceCmp(string uuid)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(uuid)) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(uuid);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FcmpCaptureAlarm/DelFaceCmp", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FcmpCaptureAlarm】-->【函数名】: DelFaceCmp");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除比对记录信息异常！【FcmpCaptureAlarm】-->【函数名】：DelFaceCmp", ex);
            }
            return result;
        }
    }
}
