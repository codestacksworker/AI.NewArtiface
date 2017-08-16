using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.BaseTools;
using SING.Data.DAL.ScheduleConvert;
using SING.Data.Help;
using SING.Data.Help.Http;
using SING.Data.Help.Json;

namespace SING.Data.DAL
{
    public partial class DefDbType
    {
        private int _type;
        private string _description;
        private int _level;

        public virtual int Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public virtual string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public virtual int Level
        {
            get { return this._level; }
            set { this._level = value; }
        }

        public static List<DefDbType> FindAll()
        {
            List<DefDbType> list = null;

            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/DefDbType/FindAll");
                HttpResult httpResult = http.GetHtml(item);
                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<DefDbType>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【DefDbType】-->【函数名】: FindAll");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询模板库类型异常！【DefDbType】-->【函数名】：FindAll", ex);
            }

            return list;
        }
    }
}
