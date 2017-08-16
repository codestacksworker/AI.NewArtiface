using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class FaceTagsData : INotifyPropertyChanged
    {
        private int _id;
        private string _tagName;

        public virtual int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged("ID");
            }
        }

        public virtual string TagName
        {
            get
            {
                return this._tagName;
            }
            set
            {
                this._tagName = value;
                OnPropertyChanged("TagName");
            }
        }

        public static FaceTags Convert(FaceTagsData oridata)
        {
            FaceTags target = new FaceTags();

            #region
            target.ID = oridata.ID;
            target.TagName = oridata.TagName;
            #endregion

            return target;
        }

        public static FaceTagsData ConvertToData(FaceTags oridata)
        {
            FaceTagsData target = new FaceTagsData();

            #region
            target.ID = oridata.ID;
            target.TagName = oridata.TagName;
            #endregion

            return target;
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
