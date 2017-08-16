using Dev_SING.Data.BaseTools;
using SING.Data.BaseTools;
using SING.Data.Help.Http;
using SING.Data.Help.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SING.Data.DAL.NewCode
{
    public abstract class DataAcess
    {
        protected virtual Response Request<T>(T t)
        {
            Response response = null;

            try
            {

                string url = GetUrl();
                if (string.IsNullOrEmpty(url))
                    return response;

                HttpHelper http = new HttpHelper();
                string postData = JsonHelper.SerializeObject(t);
                HttpItem item = http.InitializeHttpItem(AppConfig.Instance.DcUrl + url, postData);
                HttpResult httpResult = http.GetHtml(item);
                if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = httpResult.Html;
                    response = JsonToModel<Response>(json);
                }
                else
                {
                    Logger.Logger.Info("【Info】：HTTP连接失败！【DataAcess】-->【函数名】: Request");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error("【Error】：查询所有通道信息异常！【DataAcess】-->【函数名】：Request", ex);
            }

            return response;
        }

        protected T JsonToModel<T>(string json) where T : class
        {
            return JsonHelper.DeserializeJsonToObject<T>(json);
        }

        public T ToUIData<T>() where T : new()
        {
            T t = new T();
            CopyValue(this, t);
            return t;
        }

        private void CopyValue(object origin, object target)
        {
            System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
            System.Reflection.PropertyInfo[] fields = (origin.GetType()).GetProperties();
            for (int i = 0; i < fields.Length; i++)
            {
                for (int j = 0; j < properties.Length; j++)
                {

                    if (fields[i].Name.ToUpper() == properties[j].Name.ToUpper() && properties[j].CanWrite)
                    {
                        properties[j].SetValue(target, fields[i].GetValue(origin, null), null);
                    }
                }
            }
        }

        private string GetUrl()
        {
            string url = string.Empty;
            //string className = MethodBase.GetCurrentMethod().ReflectedType.Name;
            StackTrace trace = new StackTrace();

            int i = 0;
            while (trace.GetFrame(i++) != null)
            {
                MethodBase methodName = trace.GetFrame(i).GetMethod();
                foreach (var attr in methodName.GetCustomAttributes<UrlAttribute>())
                {
                    if (attr != null)
                    {
                        UrlAttribute urlattr = attr as UrlAttribute;
                        return urlattr.Url;
                    }
                }
            }
            return url;
        }
    }

    public class DataProcess : DataAcess
    {
        /// <summary>
        /// 根据查询条件返回分页数据
        /// </summary>
        /// <typeparam name="TCondtion">查询条件类型</typeparam>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <param name="pager"></param>
        /// <returns></returns>
        public Pager<TCondtion, TResult> RequestForPager<TCondtion, TResult>(Pager<TCondtion> pager)
            where TCondtion : DataAcess, new()
            where TResult : DataAcess, new()
        {
            Pager<TCondtion, TResult> result = null;

            Response response = base.Request<Pager<TCondtion>>(pager);

            if (response == null)
                return result;

            result = new Pager<TCondtion, TResult>();

            foreach (var m in response.Map.Values)
            {
                try
                {
                    if (m != null && !string.IsNullOrEmpty(m.ToString()))
                        result = JsonToModel<Pager<TCondtion, TResult>>(m.ToString());
                }
                catch (Exception ex)
                {

                }
            }

            return result;
        }

        /// <summary>
        /// 根据查询条件，返回集合类型的数据(查询条件与返回结果的类型一样)
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public List<TResult> RequestForList<TResult>() where TResult : class
        {
            List<TResult> result = null;

            Response response = Request(this);
            if (response == null)
                return result;

            result = new List<TResult>();

            foreach (var m in response.Map.Values)
            {
                if (m != null && !string.IsNullOrEmpty(m.ToString()))
                    result.Add(JsonToModel<TResult>(m.ToString()));
            }

            return result;
        }

        /// <summary>
        /// 根据查询条件，返回集合类型的数据
        /// </summary>
        /// <typeparam name="TCondition"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<TResult> RequestForList<TCondition, TResult>(TCondition condition)
            where TCondition : class
            where TResult : class
        {
            List<TResult> result = null;

            Response response = Request(condition);
            if (response == null)
                return result;

            result = new List<TResult>();

            foreach (var m in response.Map.Values)
            {
                if (m != null && !string.IsNullOrEmpty(m.ToString()))
                    result.Add(JsonToModel<TResult>(m.ToString()));
            }

            return result;
        }

        /// <summary>
        /// 根据查询条件,返回基本类型的数据
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public TResult RequestForValue<TResult>()
        {
            TResult result = default(TResult);

            Response response = Request(this);

            if (response == null)
                return result;

            foreach (var m in response.Map.Values)
            {
                if (m != null && !string.IsNullOrEmpty(m.ToString()))
                    result = (TResult)AssistTools.ChangeType(m, typeof(TResult));
            }

            return result;
        }

        /// <summary>
        /// 操作单个对象，结果返回单个对象
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public TResult Request<TResult>() where TResult : DataAcess, new()
        {
            TResult result = default(TResult);

            Response response = Request(this);

            if (response == null)
                return result;

            foreach (var m in response.Map.Values)
            {
                if (m != null && !string.IsNullOrEmpty(m.ToString()))
                    result = JsonToModel<TResult>(m.ToString());
            }

            return result;
        }

        /// <summary>
        /// 操作单个对象，结果返回是否成功
        /// </summary>
        /// <returns></returns>
        public bool Request()
        {
            bool result = false;

            Response response = Request(this);

            if (response == null)
                return result;

            if (response.Error == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据ID数据操作一组数据，结果返回是否成功
        /// </summary>
        /// <param name="idarr"></param>
        /// <returns></returns>
        public bool Request(string[] idarr)
        {
            Response response = Request<string[]>(idarr);

            if (response == null)
                return false;

            if (response.Error == 0)
                return true;
            else
                return false;
        }
    }
}
