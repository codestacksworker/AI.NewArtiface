﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.NewCode.Data
{
    public class UIDataBase: INotifyPropertyChanged
    {
        public T ToData<T>()where T:new()
        {
            T t = new T();
            CopyValue(this, t);
            return t;
        }

        private void CopyValue(object origin, object target)
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
