using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SING.Data.DAL;
using SING.Data.DAL.Data;

namespace SING.Data.Help
{
    public class BasicData
    {
        private static List<FaceTemplateDBData> _FtdbDatas;
        public static List<FaceTemplateDBData> FTDBDatas
        {
            get
            {
                //if (null == _FtdbDatas)
                {
                    try
                    {
                        _FtdbDatas = new List<FaceTemplateDBData>();

                        List<FaceTemplateDB> data = null;

                        data = FaceTemplateDB.ListAllTDB();

                        for (int i = 0; i < data.Count; i++)
                        {
                            _FtdbDatas.Add(FaceTemplateDBData.ConvertToData(data[i]));
                        }
                    }
                    catch (Exception ex)
                    {
                        _FtdbDatas = null;
                    }

                }
                return _FtdbDatas;
            }
            set
            {

                _FtdbDatas = value;
            }
        }

        private static List<DefDbTypeData> _DefDbTypes;
        public static List<DefDbTypeData> DefDbTypes
        {
            get
            {
                if (null == _DefDbTypes)
                {
                    try
                    {
                        _DefDbTypes = new List<DefDbTypeData>();

                        List<DefDbType> data = null;

                        data = DefDbType.FindAll();

                        for (int i = 0; i < data.Count; i++)
                        {
                            _DefDbTypes.Add(DefDbTypeData.ConvertToData(data[i]));
                        }
                    }
                    catch (Exception ex)
                    {
                        _DefDbTypes = null;
                    }

                }
                return _DefDbTypes;
            }
        }

        private static List<DefChannelTypeData> _DefChannelTypes;
        public static List<DefChannelTypeData> DefChannelTypes
        {
            get
            {
                if (null == _DefChannelTypes)
                {
                    try
                    {
                        _DefChannelTypes = new List<DefChannelTypeData>();

                        List<DefChannelType> data = null;

                        data = DefChannelType.FindAll();

                        for (int i = 0; i < data.Count; i++)
                        {
                            _DefChannelTypes.Add(DefChannelTypeData.ConvertToData(data[i]));
                        }
                    }
                    catch (Exception ex)
                    {
                        _DefChannelTypes = null;
                    }

                }
                return _DefChannelTypes;
            }
        }

        private static List<DefFaceObjTypeData> _DefFaceObjTypes;
        public static List<DefFaceObjTypeData> DefFaceObjTypes
        {
            get
            {
                if (null == _DefFaceObjTypes)
                {
                    try
                    {
                        _DefFaceObjTypes = new List<DefFaceObjTypeData>();

                        List<DefFaceObjType> data = null;

                        data = DefFaceObjType.FindAll();

                        for (int i = 0; i < data.Count; i++)
                        {
                            _DefFaceObjTypes.Add(DefFaceObjTypeData.ConvertToData(data[i]));
                        }
                    }
                    catch (Exception ex)
                    {
                        _DefFaceObjTypes = null;
                    }

                }
                return _DefFaceObjTypes;
            }
        }

        private static List<FaceTagsData> _FaceTagsDatas;
        public static List<FaceTagsData> FaceTagsDatas
        {
            get
            {
                //if (null == _FaceTagsDatas)
                {
                    try
                    {
                        _FaceTagsDatas = new List<FaceTagsData>();

                        List<FaceTags> data = null;

                        data = FaceTags.FindAll();

                        for (int i = 0; i < data.Count; i++)
                        {
                            _FaceTagsDatas.Add(FaceTagsData.ConvertToData(data[i]));
                        }
                    }
                    catch (Exception ex)
                    {
                        _FaceTagsDatas = null;
                    }

                }
                return _FaceTagsDatas;
            }
            set
            {

                _FaceTagsDatas = value;
            }
        }
    }
}
