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
    public partial class FaceTemplateDB
    {
        private int _id;
        private string _templateDbName;
        private string _templateDbDescription;
        private int _templateDbType;
        private int _isUsed;
        private int _templateDbSize;
        private long _createTime;
        private int _isDeleted;
        private int _templateDbCapacity;

        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
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

        [JsonProperty(PropertyName = "template_db_description", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string TemplateDbDescription
        {
            get
            {
                return this._templateDbDescription;
            }
            set
            {
                this._templateDbDescription = value;
            }
        }

        [JsonProperty(PropertyName = "template_db_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int TemplateDbType
        {
            get
            {
                return this._templateDbType;
            }
            set
            {
                this._templateDbType = value;
            }
        }

        [JsonProperty(PropertyName = "is_used", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IsUsed
        {
            get
            {
                return this._isUsed;
            }
            set
            {
                this._isUsed = value;
            }
        }

        [JsonProperty(PropertyName = "template_db_size", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int TemplateDbSize
        {
            get
            {
                return this._templateDbSize;
            }
            set
            {
                this._templateDbSize = value;
            }
        }

        [JsonProperty(PropertyName = "create_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual long CreateTime
        {
            get
            {
                return this._createTime;
            }
            set
            {
                this._createTime = value;
            }
        }

        [JsonProperty(PropertyName = "is_deleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int IsDeleted
        {
            get
            {
                return this._isDeleted;
            }
            set
            {
                this._isDeleted = value;
            }
        }

        [JsonProperty(PropertyName = "template_db_capacity", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int TemplateDbCapacity
        {
            get
            {
                return this._templateDbCapacity;
            }
            set
            {
                this._templateDbCapacity = value;
            }
        }




        public static List<FaceTemplateDB> ListAllTDB()
        {
            List<FaceTemplateDB> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl+"/FaceTemplateDB/ListAllTDB");

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    string json =  httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceTemplateDB>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplateDB】-->【函数名】: ListAllTDB");
                }
            }
            catch(Exception ex)
            {
                Logger.Logger.Error("【Error】：查询模板库表信息异常！【FaceTemplateDB】-->【函数名】：ListAllTDB", ex);
            }

            return list;
        }

        public static FaceTemplateDB QueryTDBByID(int id)
        {
            FaceTemplateDB ftdb = null;

            try
            {
                if (id == 0) return ftdb;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(id);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTemplateDB/QueryTDBByID", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return ftdb;

                        json = result.Data.ToString();

                        ftdb = JsonHelper.DeserializeJsonToObject<FaceTemplateDB>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplateDB】-->【函数名】: QueryTDBByID");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询模板库表信息异常！【FaceTemplateDB】-->【函数名】：QueryTDBByID", ex);
            }

            return ftdb;
        }

        public static Result AddTDB(FaceTemplateDB ftdb)
        {
            Result result = new Result();
            try
            {
                if (ftdb == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(ftdb);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplateDB/AddTDB", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    result = JsonHelper.DeserializeJsonToObject<Result>(json);

                    if (result.ErrorCode != StatusCode.Success)
                    {
                        Logger.Logger.Info(result.Message);
                    }
                    //if (result.ErrorCode == StatusCode.Success)
                    //{

                    //    if (result.ID == 0) return id;
                    //    id = result.ID;
                    //}
                    //else
                    //{
                    //    Logger.Logger.Info(result.Message);
                    //}
                }
                else
                {
                    result.ErrorCode = StatusCode.Fail;
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplateDB】-->【函数名】: AddTDB");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：新增模板库表信息异常！【FaceTemplateDB】-->【函数名】：AddTDB", ex);
            }

            return result;
        }

        public static Result ModTDB(FaceTemplateDB ftdb)
        {
            Result result = new Result();
            try
            {
                if (ftdb == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(ftdb);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplateDB/ModTDB", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplateDB】-->【函数名】: ModTDB");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：修改模板库表信息异常！【FaceTemplateDB】-->【函数名】：ModTDB", ex);
            }
            return result;
        }

        public static Result DelTDB(int tdbid)
        {
            Result result = new Result();
            try
            {
                if (tdbid == 0) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(tdbid);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplateDB/DelTDB", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplateDB】-->【函数名】: DelTDB");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除模板库表信息异常！【FaceTemplateDB】-->【函数名】：DelTDB", ex);
            }
            return result;
        }
    }
}
