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
    //public partial class FaceTemplate
    //{
    //    private int _ftdbId;
    //    private string _uuid;
    //    private string _objId;
    //    private string _ftDkey;
    //    private int _ftType;
    //    private int _ftIndex;
    //    private long _ftTime;
    //    private int _ftQuality;
    //    private int _faceX;
    //    private int _faceY;
    //    private int _faceCx;
    //    private int _faceCy;
    //    private string _ftRemarks;
    //    private byte[] _ftImage;    
    //    private string _imgMd;
    //    private int _deed;
    //    private long _ftImgTime;
    //    private byte[] _ftFea;


    //    [JsonProperty(PropertyName = "ftdb_id")]
    //    public virtual int FTDBID
    //    {
    //        get
    //        {
    //            return this._ftdbId;
    //        }
    //        set
    //        {
    //            this._ftdbId = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "uuid")]
    //    public virtual string Uuid
    //    {
    //        get
    //        {
    //            return this._uuid;
    //        }
    //        set
    //        {
    //            this._uuid = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "obj_id", NullValueHandling = NullValueHandling.Ignore)]
    //    public virtual string ObjId
    //    {
    //        get
    //        {
    //            return this._objId;
    //        }
    //        set
    //        {
    //            this._objId = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_dkey", NullValueHandling = NullValueHandling.Ignore)]
    //    public virtual string FtDkey
    //    {
    //        get
    //        {
    //            return this._ftDkey;
    //        }
    //        set
    //        {
    //            this._ftDkey = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual int FtType
    //    {
    //        get
    //        {
    //            return this._ftType;
    //        }
    //        set
    //        {
    //            this._ftType = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_index", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual int FtIndex
    //    {
    //        get
    //        {
    //            return this._ftIndex;
    //        }
    //        set
    //        {
    //            this._ftIndex = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual long FtTime
    //    {
    //        get
    //        {
    //            return this._ftTime;
    //        }
    //        set
    //        {
    //            this._ftTime = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_quality", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual int FtQuality
    //    {
    //        get
    //        {
    //            return this._ftQuality;
    //        }
    //        set
    //        {
    //            this._ftQuality = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "face_x", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual int FaceX
    //    {
    //        get
    //        {
    //            return this._faceX;
    //        }
    //        set
    //        {
    //            this._faceX = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "face_y", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual int FaceY
    //    {
    //        get
    //        {
    //            return this._faceY;
    //        }
    //        set
    //        {
    //            this._faceY = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "face_cx", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual int FaceCx
    //    {
    //        get
    //        {
    //            return this._faceCx;
    //        }
    //        set
    //        {
    //            this._faceCx = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "face_cy", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual int FaceCy
    //    {
    //        get
    //        {
    //            return this._faceCy;
    //        }
    //        set
    //        {
    //            this._faceCy = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_remarks", NullValueHandling = NullValueHandling.Ignore)]
    //    public virtual string FtRemarks
    //    {
    //        get
    //        {
    //            return this._ftRemarks;
    //        }
    //        set
    //        {
    //            this._ftRemarks = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_image", NullValueHandling = NullValueHandling.Ignore)]
    //    public virtual byte[] FtImage
    //    {
    //        get
    //        {
    //            return this._ftImage;
    //        }
    //        set
    //        {
    //            this._ftImage = value;                 
    //        }
    //    }

    //    [JsonProperty(PropertyName = "imgmd", NullValueHandling = NullValueHandling.Ignore)]
    //    public virtual string ImgMd
    //    {
    //        get
    //        {
    //            return this._imgMd;
    //        }
    //        set
    //        {
    //            this._imgMd = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "deed", NullValueHandling = NullValueHandling.Ignore)]
    //    public virtual int Deed
    //    {
    //        get
    //        {
    //            return this._deed;
    //        }
    //        set
    //        {
    //            this._deed = value;
    //        }
    //    }

    //    [JsonProperty(PropertyName = "ft_image_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
    //    public virtual long FtImgTime
    //    {
    //        get
    //        {
    //            return this._ftImgTime;
    //        }
    //        set
    //        {
    //            this._ftImgTime = value;
    //        }
    //    }

    //    [JsonIgnore]
    //    public virtual byte[] FtFea
    //    {
    //        get
    //        {
    //            return this._ftFea;
    //        }
    //        set
    //        {
    //            this._ftFea = value;
    //        }
    //    }

    //    public static List<FaceTemplate> ListAllFaceT(int ftdbid, int startNum = 0, int count = 1000000)
    //    {
    //        List<FaceTemplate> list = null;

    //        try
    //        {
    //            HttpHelper http = new HttpHelper();

    //            FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, startNum, count);

    //            string postData = JsonHelper.SerializeObject(jsonData);

    //            HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTemplate/ListAllFaceT", postData);

    //            HttpResult httpResult = http.GetHtml(item);

    //            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                string json = httpResult.Html;

    //                Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
    //                if (result.ErrorCode == StatusCode.Success)
    //                {
    //                    if (result.Data == null) return list;

    //                    json = result.Data.ToString();

    //                    list = JsonHelper.DeserializeJsonToList<FaceTemplate>(json);

    //                }
    //                else
    //                {
    //                    Logger.Logger.Info(result.Message);
    //                }
    //            }
    //            else
    //            {
    //                Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: ListAllFaceT");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Logger.Logger.Error("【Error】：查询模板异常！【FaceTemplate】-->【函数名】：ListAllFaceT", ex);
    //        }

    //        return list;
    //    }

    //    public static List<FaceTemplate> QueryFaceTByObjID(int ftdbid, string objId)
    //    {
    //        List<FaceTemplate> list = null;

    //        try
    //        {
    //            HttpHelper http = new HttpHelper();

    //            FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, null, objId);

    //            string postData = JsonHelper.SerializeObject(jsonData);

    //            HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTemplate/QueryFaceTByObjID", postData);

    //            HttpResult httpResult = http.GetHtml(item);

    //            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                string json = httpResult.Html;

    //                Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
    //                if (result.ErrorCode == StatusCode.Success)
    //                {
    //                    if (result.Data == null) return list;

    //                    json = result.Data.ToString();

    //                    list = JsonHelper.DeserializeJsonToList<FaceTemplate>(json);

    //                }
    //                else
    //                {
    //                    Logger.Logger.Info(result.Message);
    //                }
    //            }
    //            else
    //            {
    //                Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: QueryFaceTByObjID");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Logger.Logger.Error("【Error】：查询模板异常！【FaceTemplate】-->【函数名】：QueryFaceTByObjID", ex);
    //        }

    //        return list;
    //    }

    //    public static FaceTemplate QueryFaceTByID(int ftdbid, string uuid)
    //    {
    //        FaceTemplate ftdb = null;

    //        try
    //        {
    //            if (string.IsNullOrEmpty(uuid)) return ftdb;

    //            HttpHelper http = new HttpHelper();

    //            FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, uuid);

    //            string postData = JsonHelper.SerializeObject(jsonData);

    //            HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTemplate/QueryFaceTByID", postData);

    //            HttpResult httpResult = http.GetHtml(item);

    //            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                string json = httpResult.Html;

    //                Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
    //                if (result.ErrorCode == StatusCode.Success)
    //                {
    //                    if (result.Data == null) return ftdb;

    //                    json = result.Data.ToString();

    //                    ftdb = JsonHelper.DeserializeJsonToObject<FaceTemplate>(json);

    //                }
    //                else
    //                {
    //                    Logger.Logger.Info(result.Message);
    //                }
    //            }
    //            else
    //            {
    //                Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: QueryFaceTByID");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Logger.Logger.Error("【Error】：查询模板异常！【FaceTemplate】-->【函数名】：QueryFaceTByID", ex);
    //        }

    //        return ftdb;
    //    }

    //    public static Result AddFaceT(FaceTemplate ft)
    //    {
    //        Result result = new Result();
    //        try
    //        {
    //            if (ft == null) return null;

    //            HttpHelper http = new HttpHelper();

    //            string postData = JsonHelper.SerializeObject(ft);

    //            HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/AddFaceT", postData);

    //            HttpResult httpResult = http.GetHtml(item);

    //            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                string json = httpResult.Html;

    //                result = JsonHelper.DeserializeJsonToObject<Result>(json);

    //                if (result.ErrorCode != StatusCode.Success)
    //                {
    //                    Logger.Logger.Info(result.Message);
    //                }
    //            }
    //            else
    //            {
    //                result.ErrorCode = StatusCode.Fail;
    //                Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: AddFaceT");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            result.ErrorCode = StatusCode.Exception;
    //            Logger.Logger.Error("【Error】：新增模板信息异常！【FaceTemplate】-->【函数名】：AddFaceT", ex);
    //        }

    //        return result;
    //    }

    //    public static Result ModFaceT(FaceTemplate ft)
    //    {
    //        Result result = new Result();
    //        try
    //        {
    //            if (ft == null) return null;

    //            HttpHelper http = new HttpHelper();

    //            string postData = JsonHelper.SerializeObject(ft);

    //            HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/ModFaceT", postData);

    //            HttpResult httpResult = http.GetHtml(item);

    //            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                string json = httpResult.Html;

    //                result = JsonHelper.DeserializeJsonToObject<Result>(json);

    //                if (result.ErrorCode != StatusCode.Success)
    //                {
    //                    Logger.Logger.Info(result.Message);
    //                }
    //            }
    //            else
    //            {
    //                result.ErrorCode = StatusCode.Fail;
    //                Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: ModFaceT");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            result.ErrorCode = StatusCode.Exception;
    //            Logger.Logger.Error("【Error】：修改模板信息异常！【FaceTemplate】-->【函数名】：ModFaceT", ex);
    //        }
    //        return result;
    //    }

    //    public static Result DelFaceT(int ftdbid, string uuid)
    //    {
    //        Result result = new Result();
    //        try
    //        {
    //            if (string.IsNullOrEmpty(uuid)) return null;

    //            HttpHelper http = new HttpHelper();

    //            FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, uuid);

    //            string postData = JsonHelper.SerializeObject(jsonData);

    //            HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/DelFaceT", postData);

    //            HttpResult httpResult = http.GetHtml(item);

    //            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                string json = httpResult.Html;

    //                result = JsonHelper.DeserializeJsonToObject<Result>(json);

    //                if (result.ErrorCode != StatusCode.Success)
    //                {
    //                    Logger.Logger.Info(result.Message);
    //                }
    //            }
    //            else
    //            {
    //                result.ErrorCode = StatusCode.Fail;
    //                Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: DelFaceT");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            result.ErrorCode = StatusCode.Exception;
    //            Logger.Logger.Error("【Error】：删除模板信息异常！【FaceTemplate】-->【函数名】：DelFaceT", ex);
    //        }
    //        return result;
    //    }

    //    public static Result DelFaceTByObjID(int ftdbid, string objId)
    //    {
    //        Result result = new Result();
    //        try
    //        {
    //            if (string.IsNullOrEmpty(objId)) return null;

    //            HttpHelper http = new HttpHelper();

    //            FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, "", objId);

    //            string postData = JsonHelper.SerializeObject(jsonData);

    //            HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/DelFaceTByObjID", postData);

    //            HttpResult httpResult = http.GetHtml(item);

    //            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                string json = httpResult.Html;

    //                result = JsonHelper.DeserializeJsonToObject<Result>(json);

    //                if (result.ErrorCode != StatusCode.Success)
    //                {
    //                    Logger.Logger.Info(result.Message);
    //                }
    //            }
    //            else
    //            {
    //                result.ErrorCode = StatusCode.Fail;
    //                Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: DelFaceTByObjID");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            result.ErrorCode = StatusCode.Exception;
    //            Logger.Logger.Error("【Error】：删除模板信息异常！【FaceTemplate】-->【函数名】：DelFaceTByObjID", ex);
    //        }
    //        return result;
    //    }
    //}


    [Serializable]
    public class FaceTemplate
    {
        private string uuid;
        private string objId;
        private string ftDkey;
        private int ftType;
        private int ftIndex;
        private long ftImageTime;
        private long ftTime;
        private int ftQuality;
        private int faceX;
        private int faceY;
        private int faceCx;
        private int faceCy;
        private string ftRemarks;
        private string imgmd;
        private int ftdbId;
        private int _deed;
        private byte[] _ftImage;
        private byte[] _ftFea;
        [JsonProperty(PropertyName = "uuid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;
            }
        }
        [JsonProperty(PropertyName = "objId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ObjId
        {
            get
            {
                return objId;
            }

            set
            {
                objId = value;
            }
        }
        [JsonProperty(PropertyName = "ftDkey", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FtDkey
        {
            get
            {
                return ftDkey;
            }

            set
            {
                ftDkey = value;
            }
        }
        [JsonProperty(PropertyName = "ftType", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FtType
        {
            get
            {
                return ftType;
            }

            set
            {
                ftType = value;
            }
        }
        [JsonProperty(PropertyName = "ftIndex", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FtIndex
        {
            get
            {
                return ftIndex;
            }

            set
            {
                ftIndex = value;
            }
        }
        [JsonProperty(PropertyName = "ftImageTime", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long FtImgTime
        {
            get
            {
                return ftImageTime;
            }

            set
            {
                ftImageTime = value;
            }
        }
        [JsonProperty(PropertyName = "ftTime", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long FtTime
        {
            get
            {
                return ftTime;
            }

            set
            {
                ftTime = value;
            }
        }
        [JsonProperty(PropertyName = "ftQuality", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FtQuality
        {
            get
            {
                return ftQuality;
            }

            set
            {
                ftQuality = value;
            }
        }
        [JsonProperty(PropertyName = "faceX", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FaceX
        {
            get
            {
                return faceX;
            }

            set
            {
                faceX = value;
            }
        }
        [JsonProperty(PropertyName = "faceY", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FaceY
        {
            get
            {
                return faceY;
            }

            set
            {
                faceY = value;
            }
        }
        [JsonProperty(PropertyName = "faceCx", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FaceCx
        {
            get
            {
                return faceCx;
            }

            set
            {
                faceCx = value;
            }
        }
        [JsonProperty(PropertyName = "faceCy", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FaceCy
        {
            get
            {
                return faceCy;
            }

            set
            {
                faceCy = value;
            }
        }
        [JsonProperty(PropertyName = "ftRemarks", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string FtRemarks
        {
            get
            {
                return ftRemarks;
            }

            set
            {
                ftRemarks = value;
            }
        }
        [JsonProperty(PropertyName = "imgmd", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ImgMd
        {
            get
            {
                return imgmd;
            }

            set
            {
                imgmd = value;
            }
        }
        [JsonProperty(PropertyName = "ftdbId", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int FtdbId
        {
            get
            {
                return ftdbId;
            }

            set
            {
                ftdbId = value;
            }
        }

        [JsonProperty(PropertyName = "ftImage", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonIgnore]
        public virtual int Deed
        {
            get
            {
                return this._deed;
            }
            set
            {
                this._deed = value;
            }
        }

        [JsonProperty(PropertyName = "ftFea", NullValueHandling = NullValueHandling.Ignore)]
        public virtual byte[] FtFea
        {
            get
            {
                return this._ftFea;
            }
            set
            {
                this._ftFea = value;
            }
        }

        public static List<FaceTemplate> ListAllFaceT(int ftdbid, int startNum = 0, int count = 1000000)
        {
            List<FaceTemplate> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, startNum, count);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTemplate/ListAllFaceT", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceTemplate>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: ListAllFaceT");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询模板异常！【FaceTemplate】-->【函数名】：ListAllFaceT", ex);
            }

            return list;
        }

        public static List<FaceTemplate> QueryFaceTByObjID(int ftdbid, string objId)
        {
            List<FaceTemplate> list = null;

            try
            {
                HttpHelper http = new HttpHelper();

                FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, null, objId);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTemplate/QueryFaceTByObjID", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<FaceTemplate>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: QueryFaceTByObjID");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询模板异常！【FaceTemplate】-->【函数名】：QueryFaceTByObjID", ex);
            }

            return list;
        }

        public static FaceTemplate QueryFaceTByID(int ftdbid, string uuid)
        {
            FaceTemplate ftdb = null;

            try
            {
                if (string.IsNullOrEmpty(uuid)) return ftdb;

                HttpHelper http = new HttpHelper();

                FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, uuid);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/FaceTemplate/QueryFaceTByID", postData);

                HttpResult httpResult = http.GetHtml(item);

                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return ftdb;

                        json = result.Data.ToString();

                        ftdb = JsonHelper.DeserializeJsonToObject<FaceTemplate>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: QueryFaceTByID");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询模板异常！【FaceTemplate】-->【函数名】：QueryFaceTByID", ex);
            }

            return ftdb;
        }

        public static Result AddFaceT(FaceTemplate ft)
        {
            Result result = new Result();
            try
            {
                if (ft == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(ft);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/AddFaceT", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: AddFaceT");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：新增模板信息异常！【FaceTemplate】-->【函数名】：AddFaceT", ex);
            }

            return result;
        }

        public static Result ModFaceT(FaceTemplate ft)
        {
            Result result = new Result();
            try
            {
                if (ft == null) return null;

                HttpHelper http = new HttpHelper();

                string postData = JsonHelper.SerializeObject(ft);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/ModFaceT", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: ModFaceT");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：修改模板信息异常！【FaceTemplate】-->【函数名】：ModFaceT", ex);
            }
            return result;
        }

        public static Result DelFaceT(int ftdbid, string uuid)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(uuid)) return null;

                HttpHelper http = new HttpHelper();

                FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, uuid);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/DelFaceT", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: DelFaceT");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除模板信息异常！【FaceTemplate】-->【函数名】：DelFaceT", ex);
            }
            return result;
        }

        public static Result DelFaceTByObjID(int ftdbid, string objId)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(objId)) return null;

                HttpHelper http = new HttpHelper();

                FaceTempRelation jsonData = ParameterConvert.FaceTRelationFromPara(ftdbid, "", objId);

                string postData = JsonHelper.SerializeObject(jsonData);

                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.CoreUrl + "/FaceTemplate/DelFaceTByObjID", postData);

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
                    Logger.Logger.Info("【Info】：HTTP连接失败！【FaceTemplate】-->【函数名】: DelFaceTByObjID");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = StatusCode.Exception;
                Logger.Logger.Error("【Error】：删除模板信息异常！【FaceTemplate】-->【函数名】：DelFaceTByObjID", ex);
            }
            return result;
        }
    }
}
