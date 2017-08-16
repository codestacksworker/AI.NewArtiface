using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Models
{
    public class ModelBase : NotificationObject, IDataErrorInfo, IChecked
    {

        #region IChecked
        private int _index;
        private bool _isChecked;

        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                this._index = value;
                this.RaisePropertyChanged(() => this.Index);
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
                this._isChecked = value;
                this.RaisePropertyChanged(() => this.IsChecked);
            }
        }

        #endregion

        #region IDataErrorInfo
        public string Error
        {
            get { return _error; }
        }

        public string _error;

        public string this[string columnName]
        {
            get
            {
                Type tp = this.GetType();
                PropertyInfo pi = tp.GetProperty(columnName);
                var value = pi.GetValue(this, null);
                object[] Attributes = pi.GetCustomAttributes(false);
                if (Attributes != null && Attributes.Length > 0)
                {
                    foreach (object attribute in Attributes)
                    {
                        if (attribute is ValidationAttribute)
                        {
                            ValidationAttribute vAttribute = attribute as ValidationAttribute;
                            if (!vAttribute.IsValid(value))
                            {
                                _error = vAttribute.ErrorMessage;
                                return _error;
                            }
                        }
                    }
                }
                return null;
            }
        }


        #endregion
    }
}
