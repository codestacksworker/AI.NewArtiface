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
    public partial class FaceObject
    {
        private int _ftdbId;
        private string _uuid;
        private string _mainFtID;
        private string _name;
        private int _type;
        private int _sst;
        private int _sex;
        private long _timeStamp;
        private string _remarks;
        private string _idNumb;
        private int _idType;
        private long _birthDate;
        private string _addr;
        private string _ethnic;
        private string _tag;
        private int _reserved;

        [JsonProperty(PropertyName = "ftdb_id")]
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

        [JsonProperty(PropertyName = "main_ftID", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string MainFtID
        {
            get
            {
                return this._mainFtID;
            }
            set
            {
                this._mainFtID = value;
            }
        }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        [JsonProperty(PropertyName = "sst", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Sst
        {
            get
            {
                return this._sst;
            }
            set
            {
                this._sst = value;
            }
        }

        [JsonProperty(PropertyName = "sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int Sex
        {
            get
            {
                return this._sex;
            }
            set
            {
                this._sex = value;
            }
        }

        [JsonProperty(PropertyName = "timestamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long TimeStamp
        {
            get
            {
                return this._timeStamp;
            }
            set
            {
                this._timeStamp = value;
            }
        }

        [JsonProperty(PropertyName = "remarks", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Remarks
        {
            get
            {
                return this._remarks;
            }
            set
            {
                this._remarks = value;
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

        [JsonProperty(PropertyName = "birth_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long BirthDate
        {
            get
            {
                return this._birthDate;
            }
            set
            {
                this._birthDate = value;
            }
        }

        [JsonProperty(PropertyName = "addr", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Addr
        {
            get
            {
                return this._addr;
            }
            set
            {
                this._addr = value;
            }
        }

        [JsonProperty(PropertyName = "ethnic", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Ethnic
        {
            get
            {
                return this._ethnic;
            }
            set
            {
                this._ethnic = value;
            }
        }


        [JsonProperty(PropertyName = "tag", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
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
        public static List<FaceObject> ListAllFaceObj(int ftdbid, int startNum = 0, int count = 1000000)
        {
            List<FaceObject> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                FaceObjRelation jsonData = ParameterConvert.FaceObjRelationFromPara(ftdbid, "", startNum, count);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceObject/ListAllFaceObj", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceObject>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceObject】-->【函数名】: ListAllFaceObj");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询人脸对象信息异常！【FaceObject】-->【函数名】：ListAllFaceObj", ex);
            }

            return list;
        }

        public static List<FaceObject> QueryFaceObj(string json)
        {
            List<FaceObject> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceObject/QueryFaceObj", json);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonData = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(jsonData);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        jsonData = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceObject>(jsonData);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceObject】-->【函数名】: QueryFaceObj");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询人脸对象信息异常！【FaceObject】-->【函数名】：QueryFaceObj", ex);
            }

            return list;
        }

        public static List<FaceObject> QueryFaceObjByID(int ftdbid, string uuid)
        {
            List<FaceObject> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                FaceObjRelation jsonData = ParameterConvert.FaceObjRelationFromPara(ftdbid, uuid);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceObject/QueryFaceObjByID", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceObject>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceObject】-->【函数名】: QueryFaceObjByID");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询人脸对象信息异常！【FaceObject】-->【函数名】：QueryFaceObjByID", ex);
            }

            return list;
        }

        public static Result AddFaceObj(FaceObject fobj)
        {
            Result result = new Result();

            try
            {
                if (fobj == null) return null;

                HttpHelper http = new HttpHelper();
                
                string postData = JsonHelper.SerializeObject(fobj);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceObject/AddFaceObj", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceObject】-->【函数名】: AddFaceObj");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：新增人脸对象信息异常！【FaceObject】-->【函数名】：AddFaceObj", ex);
            }

            return result;
        }

        public static Result ModFaceObj(FaceObject fobj)
        {
            Result result = new Result();
            try
            {
                if (fobj == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(fobj);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceObject/ModFaceObj", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceObject】-->【函数名】: ModFaceObj");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：修改人脸对象信息异常！【FaceObject】-->【函数名】：ModFaceObj", ex);
            }
            return result;
        }

        public static Result DelFaceObj(int ftdbid, string uuid)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(uuid)) return null;

                HttpHelper http = new HttpHelper();

                FaceObjRelation jsonData = ParameterConvert.FaceObjRelationFromPara(ftdbid, uuid);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceObject/DelFaceObj", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceObject】-->【函数名】: DelFaceObj");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：删除人脸对象信息异常！【FaceObject】-->【函数名】：DelFaceObj", ex);
            }
            return result;
        }
    }
}
