using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SING.Data.DAL.Data;

namespace SING.Data.DAL.NewCode.Data
{
    public class RegionsData : UIDataBase
    {
        private int id;
        private string regionName;
        private string regionDescription;
        private int parentId;
        private int regionLevel;
        private int regionSort;

        private List<Channel> channelList; //通道列表
        private List<int> childRegionIdList;    //子区域id列表
        private List<string> childRegionNameList;   //子区域名称列表

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;OnPropertyChanged("Id");
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
                regionName = value;OnPropertyChanged("RegionName");
            }
        }

        public string RegionDescription
        {
            get
            {
                return regionDescription;
            }

            set
            {
                regionDescription = value;OnPropertyChanged("RegionDescription");
            }
        }

        public int ParentId
        {
            get
            {
                return parentId;
            }

            set
            {
                parentId = value;OnPropertyChanged("ParentId");
            }
        }

        public int RegionLevel
        {
            get
            {
                return regionLevel;
            }

            set
            {
                regionLevel = value;OnPropertyChanged("RegionLevel");
            }
        }

        public int RegionSort
        {
            get
            {
                return regionSort;
            }

            set
            {
                regionSort = value;OnPropertyChanged("RegionSort");
            }
        }

        public List<Channel> ChannelList
        {
            get
            {
                return channelList;
            }

            set
            {
                channelList = value;OnPropertyChanged("ChannelList");
            }
        }

        public List<int> ChildRegionIdList
        {
            get
            {
                return childRegionIdList;
            }

            set
            {
                childRegionIdList = value;OnPropertyChanged("ChildRegionIdList");
            }
        }

        public List<string> ChildRegionNameList
        {
            get
            {
                return childRegionNameList;
            }

            set
            {
                childRegionNameList = value;OnPropertyChanged("ChildRegionNameList");
            }
        }
    }
}
