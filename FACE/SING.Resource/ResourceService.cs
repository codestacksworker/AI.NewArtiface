using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SING.Resource
{
    public sealed class ResourceWrapper
    {
        private static readonly ResourceService res = ResourceService.GetInstance();
        
        public ResourceService Res
        {
            get { return res; }
        }
    }

    public  class ResourceService: INotifyPropertyChanged
    {
        #region singleton members

        private static readonly ResourceService _current = new ResourceService();
        //public static ResourceService Current
        //{
        //    get { return _current; }
        //}
        public static ResourceService GetInstance()
        {
            return _current;
        }

        #endregion

        #region all resources

        private readonly Lang.Title _title = new Lang.Title();
        public Lang.Title Title
        {
            get { return this._title; }
        }

        private readonly Lang.Button _button = new Lang.Button();
        public Lang.Button Button
        {
            get { return this._button; }
        }

        private readonly Lang.Filter _filter = new Lang.Filter();
        public Lang.Filter Filter
        {
            get { return this._filter; }
        }

        private readonly Lang.Message _message = new Lang.Message();
        public Lang.Message Message
        {
            get { return this._message; }
        }

        private readonly Lang.Entity _entity = new Lang.Entity();
        public Lang.Entity Entity
        {
            get { return this._entity; }
        }

        #endregion

        public void ChangeCulture(string name)
        {
            CultureInfo lang = CultureInfo.CurrentCulture;
            if (!string.IsNullOrEmpty(name))
            {
                lang = CultureInfo.GetCultureInfo(name);
            }
            if (lang != null)
            {
                Lang.Title.Culture = lang;
                this.RaisePropertyChanged(() => this.Title);

                Lang.Button.Culture = lang;
                this.RaisePropertyChanged(() => this.Button);

                Lang.Filter.Culture = lang;
                this.RaisePropertyChanged(() => this.Filter);

                Lang.Message.Culture = lang;
                this.RaisePropertyChanged(() => this.Message);
                
                Lang.Entity.Culture = lang;
                this.RaisePropertyChanged(() => this.Entity);
            }
        }

        public string GetValue(string key)
        {
            string result = null;

            result = Lang.Message.ResourceManager.GetString(key, Lang.Message.Culture);
            if (!string.IsNullOrEmpty(result))
                return result;

            result = Lang.Entity.ResourceManager.GetString(key, Lang.Entity.Culture);
            if (!string.IsNullOrEmpty(result))
                return result;

            result = Lang.Filter.ResourceManager.GetString(key, Lang.Filter.Culture);
            if (!string.IsNullOrEmpty(result))
                return result;

            result = Lang.Button.ResourceManager.GetString(key, Lang.Button.Culture);
            if (!string.IsNullOrEmpty(result))
                return result;

            result = Lang.Title.ResourceManager.GetString(key,Lang.Title.Culture);
            if (!string.IsNullOrEmpty(result))
                return result;

            return result;
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RaisePropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            RaisePropertyChanged(propertyName);
        }

        protected static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion

    }
}
