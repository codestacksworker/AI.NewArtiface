using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.Controls.TreeControl.Models;
using SING.Data.DAL.Data;
using SING.Data.Help;
using SING.Data.Help.Http;
using SING.Data.Help.Json;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.BaseTools;

namespace SING.Data.DAL
{
    public partial class Regions
    {
        private int _id;
        private string _regionName;
        private string _regionDescription;
        private int _parentId;
        private int _regionLevel;
        private int _regionSort;

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

        [JsonProperty(PropertyName = "region_description", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string RegionDescription
        {
            get
            {
                return this._regionDescription;
            }
            set
            {
                this._regionDescription = value;
            }
        }

        [JsonProperty(PropertyName = "parent_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual int ParentId
        {
            get
            {
                return this._parentId;
            }
            set
            {
                this._parentId = value;
            }
        }

        [JsonProperty(PropertyName = "region_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int RegionLevel
        {
            get
            {
                return this._regionLevel;
            }
            set
            {
                this._regionLevel = value;
            }
        }

        [JsonProperty(PropertyName = "region_sort", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int RegionSort
        {
            get
            {
                return this._regionSort;
            }
            set
            {
                this._regionSort = value;
            }
        }

        public static List<Regions> ListAllRegion()
        {
            List<Regions> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Regions/ListAllRegion");

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<Regions>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Regions】-->【函数名】: ListAllRegion");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询所有区域信息异常！【Regions】-->【函数名】：ListAllRegion", ex);
            }

            return list;
        }

        public static List<Regions> QueryRegionByID(int id)
        {
            List<Regions> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(id);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Regions/QueryRegionByID", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<Regions>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Regions】-->【函数名】: QueryRegionByID");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询区域信息异常！【Regions】-->【函数名】：QueryRegionByID", ex);
            }

            return list;
        }

        public static Regions QueryRegionByPID(int parentId)
        {
            Regions region = null;

            try
            {
                if (parentId == 0) return region;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(parentId);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Regions/QueryRegionByPID", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return region;

                        json = result.Data.ToString();

                        region = JsonHelper.DeserializeJsonToObject<Regions>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Regions】-->【函数名】: QueryRegionByPID");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询父区域信息异常！【Regions】-->【函数名】：QueryRegionByPID", ex);
            }

            return region;
        }

        public static Result AddRegion(Regions region)
        {
            Result result = new Result();
            try
            {
                if (region == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(region);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Regions/AddRegion", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Regions】-->【函数名】: AddRegion");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：新增区域信息异常！【Regions】-->【函数名】：AddRegion", ex);
            }

            return result;
        }

        public static Result ModRegion(Regions region)
        {
            Result result = new Result();
            try
            {
                if (region == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(region);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Regions/ModRegion", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Regions】-->【函数名】: ModRegion");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：修改区域信息异常！【Regions】-->【函数名】：ModRegion", ex);
            }

            return result;
        }

        public static Result DelRegionByID(int id, bool delChannel)
        {
            Result result = new Result();
            try
            {
                if (id == 0) return null;

                HttpHelper http = new HttpHelper();

                RegionsParameter jsonData = ParameterConvert.RegionsParameterFromPara(id, delChannel);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Regions/DelRegionByID", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Regions】-->【函数名】: DelRegion");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除区域信息异常！【Regions】-->【函数名】：DelRegion", ex);
            }

            return result;
        }

        public static Result DelRegionByPID(int parentId)
        {
            Result result = new Result();
            try
            {
                if (parentId == 0) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(parentId);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/Regions/DelRegionByPID", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【Regions】-->【函数名】: DelRegionByPID");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除区域信息异常！【Regions】-->【函数名】：DelRegionByPID", ex);
            }

            return result;
        }
    }
}
