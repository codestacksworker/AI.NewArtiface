using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace FACE_AlertRecord.Models
{
    public class TarLibraryData : INotifyPropertyChanged
    {
        private string _tarLibName;
        private string _tarPeople;
        private string _describe;
        private string _libStatus;
        private string _tarPeopleNum;
        private string _templateNum;
        private bool   _isChecked;

        public string TarLibName
        {
            get
            {
                return _tarLibName;
            }

            set
            {
                _tarLibName = value;
                OnPropertyChanged("TarLibName");
            }
        }

        public string TarPeople
        {
            get
            {
                return _tarPeople;
            }

            set
            {
                _tarPeople = value;
                OnPropertyChanged("TarPeople");
            }
        }

        public string Describe
        {
            get
            {
                return _describe;
            }

            set
            {
                _describe = value;
                OnPropertyChanged("Describe");
            }
        }

        public string LibStatus
        {
            get
            {
                return _libStatus;
            }

            set
            {
                _libStatus = value;
                OnPropertyChanged("LibStatus");
            }
        }

        public string TarPeopleNum
        {
            get
            {
                return _tarPeopleNum;
            }

            set
            {
                _tarPeopleNum = value;
                OnPropertyChanged("TarPeopleNum");
            }
        }

        public string TemplateNum
        {
            get
            {
                return _templateNum;
            }

            set
            {
                _templateNum = value;
                OnPropertyChanged("TemplateNum");
            }
        }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }


        private ObservableCollection<TarLibraryData> _tarLibChildList = new ObservableCollection<TarLibraryData>();

        public ObservableCollection<TarLibraryData> TarLibChildList
        {
            get
            {
                return _tarLibChildList;
            }

            set
            {
                _tarLibChildList = value;
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
