using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GMap.NET;

namespace SING.Data.Controls.GmapControl.Models
{
    public class PointLatLngImg : INotifyPropertyChanged
    {
        private PointLatLng point;
        public PointLatLng Point
        {
            get { return this.point; }
            set
            {
                this.point = value;
                OnPropertyChanged("Point");
            }
        }

        private ImageSource img;

        public ImageSource Img
        {
            get { return this.img; }
            set
            {
                this.img = value;
                OnPropertyChanged("Img");
            }
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        private string gander;

        public string Gander
        {
            get { return this.gander; }
            set
            {
                this.gander = value;
                OnPropertyChanged("Gander");
            }
        }

        private string birthday;

        public string Birthday
        {
            get { return this.birthday; }
            set
            {
                this.birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        private string homeAddress;

        public string HomeAddress
        {
            get { return this.homeAddress; }
            set
            {
                this.homeAddress = value;
                OnPropertyChanged("HomeAddress");
            }
        }

        private string isCard;

        public string IDCard
        {
            get { return this.isCard; }
            set
            {
                this.isCard = value;
                OnPropertyChanged("IDCard");
            }
        }

        private string source;

        public string Source
        {
            get { return this.source; }
            set
            {
                this.source = value;
                OnPropertyChanged("Source");
            }
        }

        private string sourceStoreValue;

        public string SourceStoreValue
        {
            get { return this.sourceStoreValue; }
            set
            {
                this.sourceStoreValue = value;
                OnPropertyChanged("SourceStoreValue");
            }
        }

        private string id;

        public string Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                OnPropertyChanged("Id");
            }
        }

        private string channelName;

        public string ChannelName
        {
            get { return this.channelName; }
            set
            {
                this.channelName = value;
                OnPropertyChanged("ChannelName");
            }
        }

        private string location;

        public string Location
        {
            get { return this.location; }
            set
            {
                this.location = value;
                OnPropertyChanged("Location");
            }
        }

        private decimal snapPersonCount;

        public decimal SnapPersonCount
        {
            get { return this.snapPersonCount; }
            set
            {
                this.snapPersonCount = value;
                OnPropertyChanged("SnapPersonCount");
            }
        }

        private decimal snapCount;

        public decimal SnapCount
        {
            get { return this.snapCount; }
            set
            {
                this.snapCount = value;
                OnPropertyChanged("SnapCount");
            }
        }

        private string brand;

        public string Brand
        {
            get { return this.brand; }
            set
            {
                this.brand = value;
                OnPropertyChanged("Brand");
            }
        }

        private string installDate;

        public string InstallDate
        {
            get { return this.installDate; }
            set
            {
                this.installDate = value;
                OnPropertyChanged("InstallDate");
            }
        }


        private Visibility pointVisibility = Visibility.Collapsed;

        public Visibility PointVisibility
        {
            get { return this.pointVisibility; }
            set
            {
                this.pointVisibility = value;
                OnPropertyChanged("PointVisibility");
            }
        }

        private Visibility imgVisibility = Visibility.Collapsed;

        public Visibility ImgVisibility
        {
            get { return this.imgVisibility; }
            set
            {
                this.imgVisibility = value;
                OnPropertyChanged("ImgVisibility");
            }
        }

        private Visibility imgframeVisibility = Visibility.Collapsed;

        public Visibility ImgframeVisibility
        {
            get { return this.imgframeVisibility; }
            set
            {
                this.imgframeVisibility = value;
                OnPropertyChanged("ImgframeVisibility");
            }
        }

        private Visibility nameVisibility = Visibility.Collapsed;

        public Visibility NameVisibility
        {
            get { return this.nameVisibility; }
            set
            {
                this.nameVisibility = value;
                OnPropertyChanged("NameVisibility");
            }
        }

        private Visibility ganderVisibility = Visibility.Collapsed;

        public Visibility GanderVisibility
        {
            get { return this.ganderVisibility; }
            set
            {
                this.ganderVisibility = value;
                OnPropertyChanged("GanderVisibility");
            }
        }

        private Visibility birthdayVisibility = Visibility.Collapsed;

        public Visibility BirthdayVisibility
        {
            get { return this.birthdayVisibility; }
            set
            {
                this.birthdayVisibility = value;
                OnPropertyChanged("BirthdayVisibility");
            }
        }

        private Visibility homeAddressVisibility = Visibility.Collapsed;

        public Visibility HomeAddressVisibility
        {
            get { return this.homeAddressVisibility; }
            set
            {
                this.homeAddressVisibility = value;
                OnPropertyChanged("HomeAddressVisibility");
            }
        }

        private Visibility isCardVisibility = Visibility.Collapsed;

        public Visibility IDCardVisibility
        {
            get { return this.isCardVisibility; }
            set
            {
                this.isCardVisibility = value;
                OnPropertyChanged("IDCardVisibility");
            }
        }

        private Visibility sourceVisibility = Visibility.Collapsed;

        public Visibility SourceVisibility
        {
            get { return this.sourceVisibility; }
            set
            {
                this.sourceVisibility = value;
                OnPropertyChanged("SourceVisibility");
            }
        }

        private Visibility sourceStoreValueVisibility = Visibility.Collapsed;

        public Visibility SourceStoreValueVisibility
        {
            get { return this.sourceStoreValueVisibility; }
            set
            {
                this.sourceStoreValueVisibility = value;
                OnPropertyChanged("SourceStoreValueVisibility");
            }
        }

        private Visibility idVisibility = Visibility.Collapsed;

        public Visibility IdVisibility
        {
            get { return this.idVisibility; }
            set
            {
                this.idVisibility = value;
                OnPropertyChanged("IdVisibility");
            }
        }

        private Visibility channelNameVisibility = Visibility.Collapsed;

        public Visibility ChannelNameVisibility
        {
            get { return this.channelNameVisibility; }
            set
            {
                this.channelNameVisibility = value;
                OnPropertyChanged("ChannelNameVisibility");
            }
        }

        private Visibility locationVisibility = Visibility.Collapsed;

        public Visibility LocationVisibility
        {
            get { return this.locationVisibility; }
            set
            {
                this.locationVisibility = value;
                OnPropertyChanged("LocationVisibility");
            }
        }

        private Visibility snapPersonCountVisibility = Visibility.Collapsed;

        public Visibility SnapPersonCountVisibility
        {
            get { return this.snapPersonCountVisibility; }
            set
            {
                this.snapPersonCountVisibility = value;
                OnPropertyChanged("SnapPersonCountVisibility");
            }
        }

        private Visibility snapCountVisibility = Visibility.Collapsed;

        public Visibility SnapCountVisibility
        {
            get { return this.snapCountVisibility; }
            set
            {
                this.snapCountVisibility = value;
                OnPropertyChanged("SnapCountVisibility");
            }
        }

        private Visibility brandVisibility = Visibility.Collapsed;

        public Visibility BrandVisibility
        {
            get { return this.brandVisibility; }
            set
            {
                this.brandVisibility = value;
                OnPropertyChanged("BrandVisibility");
            }
        }

        private Visibility installDateVisibility = Visibility.Collapsed;

        public Visibility InstallDateVisibility
        {
            get { return this.installDateVisibility; }
            set
            {
                this.installDateVisibility = value;
                OnPropertyChanged("InstallDateVisibility");
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
