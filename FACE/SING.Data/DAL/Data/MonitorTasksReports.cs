using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    public class MonitorTasksReports : INotifyPropertyChanged
    {
        private string uuid;
        private string name;
        private int channelCount;
        private int fobjCount;
        private int alertCount;
        private int cameraCount;
        private string createTime;
        //private ObservableCollection<>
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

        public int FobjCount
        {
            get
            {
                return fobjCount;
            }

            set
            {
                fobjCount = value;
                OnPropertyChanged("FobjCount");
            }
        }

        public int AlertCount
        {
            get
            {
                return alertCount;
            }

            set
            {
                alertCount = value;
                OnPropertyChanged("FobjCount");
            }
        }

        public int CameraCount
        {
            get
            {
                return cameraCount;
            }

            set
            {
                cameraCount = value;
                OnPropertyChanged("FobjCount");
            }
        }

        public string CreateTime
        {
            get
            {
                return createTime;
            }

            set
            {
                createTime = value;
                OnPropertyChanged("FobjCount");
            }
        }

        public static void CopyValue(object origin, object target)
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
