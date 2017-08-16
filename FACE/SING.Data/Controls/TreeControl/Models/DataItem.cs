using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using SING.Data.DAL;
using SING.Data.DAL.Data;

namespace SING.Data.Controls.TreeControl.Models
{
    [ContentProperty("Children")]
    public class DataItem : DependencyObject, INotifyPropertyChanged
    {
        public DataItem()
        {
            this.items = new DataItemCollection(this);
        }

        private string text;
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                OnPropertyChanged("Text");
                if (Status == "Region")
                    Region.RegionName = value;
                else if (Status == "Channel")
                    Channel.ChannelName = value;
            }
        }
        private DataItem parent;
        public DataItem Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
                OnPropertyChanged("Parent");
            }
        }
        private DataItemCollection items;

        public DataItemCollection Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
                OnPropertyChanged("Items");
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }
            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }
            }
        }

        private Visibility _menuDropVisibility = Visibility.Visible;

        public Visibility MenuDropVisibility
        {
            get
            {
                return this._menuDropVisibility;
            }
            set
            {
                if (this._menuDropVisibility != value)
                {
                    this._menuDropVisibility = value;
                    OnPropertyChanged("MenuDropVisibility");
                }
            }
        }

        private ChannelData _channel;
        public ChannelData Channel
        {
            get
            {
                return _channel;
            }

            set
            {
                _channel = value;
                OnPropertyChanged("Channel");
                Text = value.ChannelName;
                Status = "Channel";
            }
        }

        private RegionsData _region;
        public RegionsData Region
        {
            get
            {
                return _region;
            }

            set
            {
                _region = value;
                OnPropertyChanged("Region");
                Text = value.RegionName;
                Status = "Region";
            }
        }

        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        /// <summary>
        /// 区域编辑状态
        /// </summary>
        private bool isInEdit = false;
        public bool IsInEdit
        {
            get
            {
                return this.isInEdit;
            }
            set
            {
                if (this.isInEdit != value)
                {
                    this.isInEdit = value;
                    OnPropertyChanged("IsInEdit");
                }
            }
        }

        public static DataItem Convert(ChannelData oridata)
        {
            DataItem item = new DataItem();
            item.Id = oridata.Uuid;
            item.Channel = oridata;
            item.Text = oridata.ChannelName;
            return item;
        }

        public static DataItem Convert(RegionsData oridata)
        {
            DataItem item = new DataItem();
            item.Id = oridata.ID.ToString();
            item.Region = oridata;
            item.Text = oridata.RegionName;
            return item;
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
