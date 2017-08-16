using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class AlertDetailData : UIDataBase
    {
        private string fcapImgUuid;// 抓拍图片ID 根据抓拍图片ID，到图片服务器获取抓拍图片
        private string fcapImgUrl;//抓拍图片URL 用于回显抓拍图片

        private string fcmpImgUuid;// 目标人图片ID 根据目标人图片ID，到图片服务器获取目标人图片
        private string fcmpImgUrl;// 目标人图片URL 用于回显目标人图片

        private string fcapUuid;// 抓拍id

        private string channelName;// 通道名称 

        private int sex;// 目标人性别  0 未知 1 男 2 女

        private string sexTag;// 性别标识 String 回显性别中文值
        private string name;// 目标人姓名 
        private int appearNumber; //出现次数 
        private string regionName;// 区域名称 String
        private double threshold;// 质量系数 double
        private long ftImgTime; //图片采集时间 long
        
        public string FcapImgUuid
        {
            get
            {
                return fcapImgUuid;
            }

            set
            {
                fcapImgUuid = value;
                OnPropertyChanged("FcapImgUuid");
            }
        }

        public string FcapImgUrl
        {
            get
            {
                return fcapImgUrl;
            }

            set
            {
                fcapImgUrl = value;
                OnPropertyChanged("FcapImgUrl");
            }
        }

        public string FcmpImgUuid
        {
            get
            {
                return fcmpImgUuid;
            }

            set
            {
                fcmpImgUuid = value;
                OnPropertyChanged("FcmpImgUuid");
            }
        }

        public string FcmpImgUrl
        {
            get
            {
                return fcmpImgUrl;
            }

            set
            {
                fcmpImgUrl = value;
                OnPropertyChanged("FcmpImgUrl");
            }
        }

        public string FcapUuid
        {
            get
            {
                return fcapUuid;
            }

            set
            {
                fcapUuid = value;
                OnPropertyChanged("FcapUuid");
            }
        }

        public string ChannelName
        {
            get
            {
                return channelName;
            }

            set
            {
                channelName = value;
                OnPropertyChanged("ChannelName");
            }
        }

        public int Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
                OnPropertyChanged("Sex");
            }
        }

        public string SexTag
        {
            get
            {
                return sexTag;
            }

            set
            {
                sexTag = value;
                OnPropertyChanged("SexTag");
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

        public int AppearNumber
        {
            get
            {
                return appearNumber;
            }

            set
            {
                appearNumber = value;
                OnPropertyChanged("AppearNumber");
            }
        }

        public string RegionName
        {
            get
            {
                return regionName;
            }

            set
            {
                regionName = value;
                OnPropertyChanged("RegionName");
            }
        }

        public double Threshold
        {
            get
            {
                return threshold;
            }

            set
            {
                threshold = value;
                OnPropertyChanged("Threshold");
            }
        }

        public long FtImgTime
        {
            get
            {
                return ftImgTime;
            }

            set
            {
                ftImgTime = value;
                OnPropertyChanged("FtImgTime");
            }
        }
    }
}
