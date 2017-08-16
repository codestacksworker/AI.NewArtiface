using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace FACE_ChannelManagement.Models
{
    public class QueryCondition : NotificationObject
    {
        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }

            set
            {
                _searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }
    }
}
