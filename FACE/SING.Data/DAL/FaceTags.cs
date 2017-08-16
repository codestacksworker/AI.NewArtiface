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
    public partial class FaceTags
    {
        private int _id;
        private string _tagName;

        [JsonProperty(PropertyName = "id")]
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

        [JsonProperty(PropertyName = "tag_name")]
        public virtual string TagName
        {
            get
            {
                return this._tagName;
            }
            set
            {
                this._tagName = value;
            }
        }

        public static List<FaceTags> FindAll()
        {
            List<FaceTags> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTags/ListAllTags");

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);

                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceTags>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTags】-->【函数名】: FindAll");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询所有标签异常！【FaceTags】-->【函数名】：FindAll", ex);
            }

            return list;
        }

        public static List<FaceTags> SuggestTags(string tagName, int count)
        {
            List<FaceTags> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTags/SuggestTags");

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);

                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceTags>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTags】-->【函数名】: SuggestTags");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询标签异常！【FaceTags】-->【函数名】：SuggestTags", ex);
            }

            return list;
        }

        public static Result AddTag(string tagName)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(tagName)) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(tagName);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTags/AddTag", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTags】-->【函数名】: AddTag");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：添加标签异常！【FaceTags】-->【函数名】：AddTag", ex);
            }

            return result;
        }

        public static Result AddTagToFaceObj(int tagId, string objId)
        {
            Result result = new Result();
            try
            {
                if (tagId == 0 || string.IsNullOrEmpty(objId)) return null;

                HttpHelper http = new HttpHelper();

                FaceTagsParameter jsonData = ParameterConvert.FaceTagsParameterFromPara(tagId, objId);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTags/AddTagToFaceObj", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTags】-->【函数名】: AddTagToFaceObj");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：新增人脸对象标签信息异常！【FaceTags】-->【函数名】：AddTagToFaceObj", ex);
            }

            return result;
        }

        public static Result DelTagFromFaceObj(int tagId, string objId)
        {
            Result result = new Result();
            try
            {
                if (tagId == 0 || string.IsNullOrEmpty(objId)) return null;

                HttpHelper http = new HttpHelper();

                FaceTagsParameter jsonData = ParameterConvert.FaceTagsParameterFromPara(tagId, objId);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTags/DelTagFromFaceObj", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTags】-->【函数名】: DelTagFromFaceObj");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除人脸对象标签信息异常！【FaceTags】-->【函数名】：DelTagFromFaceObj", ex);
            }
            return result;
        }
    }
}
