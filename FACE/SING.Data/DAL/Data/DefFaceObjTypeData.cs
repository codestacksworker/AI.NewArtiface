using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.DAL.Data
{
    public class DefFaceObjTypeData
    {
        private int _type;
        private string _description;

        public virtual int Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public static DefFaceObjType Convert(DefFaceObjTypeData oridata)
        {
            DefFaceObjType target = new DefFaceObjType();

            #region
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            #endregion

            return target;
        }

        public static DefFaceObjTypeData ConvertToData(DefFaceObjType oridata)
        {
            DefFaceObjTypeData target = new DefFaceObjTypeData();

            #region
            target.Type = oridata.Type;
            target.Description = oridata.Description;
            #endregion

            return target;
        }
    }
}
