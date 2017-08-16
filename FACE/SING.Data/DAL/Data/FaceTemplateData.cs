using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Help;
using System.Windows.Media;

namespace SING.Data.DAL.Data
{
    [Serializable]
    public class FaceTemplateData : INotifyPropertyChanged
    {
        private int _ftdbId;
        private string _uuid;
        private string _objId;
        private string _ftDkey;
        private int _ftType;
        private int _ftIndex;
        private string _ftTime;
        private int _ftQuality;
        private int _faceX;
        private int _faceY;
        private int _faceCx;
        private int _faceCy;
        private string _ftRemarks;
        private byte[] _ftImage;
        private string _imgMd;
        private int _deed;
        private string _ftImgTime;

        public virtual int FTDBID
        {
            get
            {
                return this._ftdbId;
            }
            set
            {
                this._ftdbId = value;
                OnPropertyChanged("FTDBID");
            }
        }

        public virtual string Uuid
        {
            get
            {
                return this._uuid;
            }
            set
            {
                this._uuid = value;
                OnPropertyChanged("Uuid");
            }
        }

        public virtual string ObjId
        {
            get
            {
                return this._objId;
            }
            set
            {
                this._objId = value;
                OnPropertyChanged("ObjId");
            }
        }

        public virtual string FtDkey
        {
            get
            {
                return this._ftDkey;
            }
            set
            {
                this._ftDkey = value;
                OnPropertyChanged("FtDkey");
            }
        }

        public virtual int FtType
        {
            get
            {
                return this._ftType;
            }
            set
            {
                this._ftType = value;
                OnPropertyChanged("FtType");
            }
        }

        public virtual int FtIndex
        {
            get
            {
                return this._ftIndex;
            }
            set
            {
                this._ftIndex = value;
                OnPropertyChanged("FtIndex");
            }
        }

        public virtual string FtTime
        {
            get
            {
                return this._ftTime;
            }
            set
            {
                this._ftTime = value;
                OnPropertyChanged("FtTime");
            }
        }

        public virtual int FtQuality
        {
            get
            {
                return this._ftQuality;
            }
            set
            {
                this._ftQuality = value;
                OnPropertyChanged("FtQuality");
            }
        }

        public virtual int FaceX
        {
            get
            {
                return this._faceX;
            }
            set
            {
                this._faceX = value;
                OnPropertyChanged("FaceX");
            }
        }

        public virtual int FaceY
        {
            get
            {
                return this._faceY;
            }
            set
            {
                this._faceY = value;
                OnPropertyChanged("FaceY");
            }
        }

        public virtual int FaceCx
        {
            get
            {
                return this._faceCx;
            }
            set
            {
                this._faceCx = value;
                OnPropertyChanged("FaceCx");
            }
        }

        public virtual int FaceCy
        {
            get
            {
                return this._faceCy;
            }
            set
            {
                this._faceCy = value;
                OnPropertyChanged("FaceCy");
            }
        }

        public virtual string FtRemarks
        {
            get
            {
                return this._ftRemarks;
            }
            set
            {
                this._ftRemarks = value;
                OnPropertyChanged("FtRemarks");
            }
        }

        public virtual byte[] FtImage
        {
            get
            {
                return this._ftImage;
            }
            set
            {
                this._ftImage = value;
                OnPropertyChanged("FtImage");
            }
        }

        public virtual string ImgMd
        {
            get
            {
                return this._imgMd;
            }
            set
            {
                this._imgMd = value;
                OnPropertyChanged("ImgMd");
            }
        }

        public virtual int Deed
        {
            get
            {
                return this._deed;
            }
            set
            {
                this._deed = value;
                OnPropertyChanged("Deed");
            }
        }

        public virtual string FtImgTime
        {
            get
            {
                return this._ftImgTime;
            }
            set
            {
                this._ftImgTime = value;
                OnPropertyChanged("FtImgTime");
            }
        }

        public static FaceTemplate Convert(FaceTemplateData oridata)
        {
            FaceTemplate target = new FaceTemplate();

            #region

            target.FtdbId = oridata.FTDBID;
            target.Uuid = oridata.Uuid;
            target.ObjId = oridata.ObjId;
            target.FtDkey = oridata.FtDkey;
            target.FtType = oridata.FtType;
            target.FtIndex = oridata.FtIndex;
            target.FtTime = oridata.FtTime.SToLong();
            target.FtQuality = oridata.FtQuality;
            target.FaceX = oridata.FaceX;
            target.FaceY = oridata.FaceY;
            target.FaceCx = oridata.FaceCx;
            target.FaceCy = oridata.FaceCy;
            target.FtRemarks = oridata.FtRemarks;
            target.FtImage = oridata.FtImage;
            target.ImgMd = oridata.ImgMd;
            target.Deed = oridata.Deed;
            target.FtImgTime = oridata.FtImgTime.SToLong();

            #endregion

            return target;
        }

        public static FaceTemplateData ConvertToData(FaceTemplate oridata)
        {
            FaceTemplateData target = new FaceTemplateData();

            #region

            target.FTDBID = oridata.FtdbId;
            target.Uuid = oridata.Uuid;
            target.ObjId = oridata.ObjId;
            target.FtDkey = oridata.FtDkey;
            target.FtType = oridata.FtType;
            target.FtIndex = oridata.FtIndex;
            target.FtTime = oridata.FtTime.LToString();
            target.FtQuality = oridata.FtQuality;
            target.FaceX = oridata.FaceX;
            target.FaceY = oridata.FaceY;
            target.FaceCx = oridata.FaceCx;
            target.FaceCy = oridata.FaceCy;
            target.FtRemarks = oridata.FtRemarks;
            target.FtImage = oridata.FtImage;
            target.ImgMd = oridata.ImgMd;
            target.Deed = oridata.Deed;
            target.FtImgTime = oridata.FtImgTime.LToString();

            #endregion

            return target;
        }

        public static FaceTemplateData CopyData(FaceTemplateData oridata)
        {
            FaceTemplateData target = new FaceTemplateData();

            #region

            target.FTDBID = oridata.FTDBID;
            target.Uuid = oridata.Uuid;
            target.ObjId = oridata.ObjId;
            target.FtDkey = oridata.FtDkey;
            target.FtType = oridata.FtType;
            target.FtIndex = oridata.FtIndex;
            target.FtTime = oridata.FtTime;
            target.FtQuality = oridata.FtQuality;
            target.FaceX = oridata.FaceX;
            target.FaceY = oridata.FaceY;
            target.FaceCx = oridata.FaceCx;
            target.FaceCy = oridata.FaceCy;
            target.FtRemarks = oridata.FtRemarks;
            target.FtImage = oridata.FtImage;
            target.ImgMd = oridata.ImgMd;
            target.Deed = oridata.Deed;
            target.FtImgTime = oridata.FtImgTime;

            #endregion

            return target;
        }

        public static void CopyValue(object origin, object target)
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
