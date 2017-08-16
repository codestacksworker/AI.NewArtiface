using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.BaseTools;
using SING.Data.Help;
using SING.Data.Help.Http;
using SING.Data.Help.Json;

namespace SING.Data.DAL
{
    public partial class DefChannelType
    {
        private int _type;
        private string _description;

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

        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public static List<DefChannelType> FindAll()
        {
            List<DefChannelType> list = null;

            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + "/DefChannelType/FindAll");
                HttpResult httpResult = http.GetHtml(item);
                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;

                    Result result = JsonHelper.DeserializeJsonToObject<Result>(json);
                    if (result.ErrorCode == StatusCode.Success)
                    {
                        if (result.Data == null) return list;

                        json = result.Data.ToString();

                        list = JsonHelper.DeserializeJsonToList<DefChannelType>(json);

                    }
                    else
                    {
                        Logger.Logger.Info(result.Message);
                    }
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【DefChannelType】-->【函数名】: FindAll");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询通道类型异常！【DefChannelType】-->【函数名】：FindAll", ex);
            }

            return list;
        }
    }
}
