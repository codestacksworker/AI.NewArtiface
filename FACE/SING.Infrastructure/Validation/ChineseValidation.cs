using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SING.Infrastructure.Validation
{
    public class ChineseValidation 
    {
        private object _type;//默认为不可带空格不可为空的中文 1 不可带空格可为空的中文 2 可带空格不可为空的中文 3 可带空格可为空的中文
        public object Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public static bool Validate(object value, object type)
        {
            string input = string.Empty;
            if (value != null && value.ToString() != "")
            {
                input = value as string;
            }
            try
            {
                string parm = string.Empty;
                if (type != null && type.ToString() != "")
                {
                    switch (type.ToString())
                    {
                        case "1":
                            parm = @"^[\u4e00-\u9fa5]{0,}$";
                            break;
                        case "2":
                            parm = @"(^[\u4e00-\u9fa5]{1,}$)|(^[\u4e00-\u9fa5]{1,}\s{0,}[\u4e00-\u9fa5]{1,}$)";
                            break;
                        case "3":
                            parm = @"(^[\u4e00-\u9fa5]{0,}$)|(^[\u4e00-\u9fa5]{1,}\s{0,}[\u4e00-\u9fa5]{1,}$)";
                            break;
                        default:
                            parm = @"^[\u4e00-\u9fa5]{1,}$";
                            break;
                    }
                }
                else
                {
                    parm = @"^[\u4e00-\u9fa5]{1,}$";
                }
                Regex rg = new Regex(parm);
                Match mh = rg.Match(input);
                if (!mh.Success)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }
    }
}
