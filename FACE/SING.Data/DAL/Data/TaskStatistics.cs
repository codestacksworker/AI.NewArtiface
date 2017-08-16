using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Help.Http;
using SING.Data.Help.Json;

namespace SING.Data.DAL.Data
{
    public class TaskStatistics : INotifyPropertyChanged
    {
        private string uuid;
        private string name;
        private int channelCount;
        private int alarmCount;
        private int objectCount;
        private int subscribeState;
        private int state;
        private string loginUid;

        //任务UUid
        public string Uuid
        {
            get
            {
                return uuid;
            }

            set
            {
                uuid = value;
                OnPropertyChanged("Uuid");
            }
        }

        //任务名称
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        //布控通道数
        public int ChannelCount
        {
            get
            {
                return channelCount;
            }

            set
            {
                channelCount = value;
                OnPropertyChanged("ChannelCount");
            }
        }

        //告警次数
        public int AlarmCount
        {
            get
            {
                return alarmCount;
            }

            set
            {
                alarmCount = value;
                OnPropertyChanged("AlarmCount");
            }
        }

        //目标人数
        public int ObjectCount
        {
            get
            {
                return objectCount;
            }

            set
            {
                objectCount = value;
                OnPropertyChanged("ObjectCount");
            }
        }

        //当前用户订阅状态
        public int SubscribeState
        {
            get
            {
                return subscribeState;
            }

            set
            {
                subscribeState = value;
                OnPropertyChanged("SubscribeState");
            }
        }

        //任务状态
        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        //登陆用户id
        public string LoginUid
        {
            get
            {
                return loginUid;
            }

            set
            {
                loginUid = value;
                OnPropertyChanged("LoginUid");
            }
        }

        //public List<Pager<TaskStatistics>> QueryStatistics(Pager<TaskStatistics> pager)
        //{
        //    List<Pager<TaskStatistics>> list = null;

        //    try
        //    {
        //        HttpHelper http = new HttpHelper();
        //        string postData = JsonHelper.SerializeObject(pager);
        //        HttpItem item = http.InitializeHttpItem("http://192.168.1.211:8080/facecore/facetemplate/queryFaceTemplateByPager.do", postData);
        //        HttpResult httpResult = http.GetHtml(item);
        //        if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            string json = httpResult.Html;
        //            Pager<TaskStatistics> result = JsonHelper.DeserializeJsonToObject<Pager<TaskStatistics>>(json);
        //        }
        //        else
        //        {
        //            Logger.Logger.Info("【Info】：HTTP连接失败！【Channel】-->【函数名】: ListAllChannel");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Logger.Error("【Error】：查询所有通道信息异常！【Channel】-->【函数名】：ListAllChannel", ex);
        //    }

        //    return list;
        //}

        #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
