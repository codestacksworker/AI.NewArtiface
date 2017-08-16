using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data
{
    public class EnumData: NotificationObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                RaisePropertyChanged("Value");
            }
        }

        private int _value = 0;
    }
}
