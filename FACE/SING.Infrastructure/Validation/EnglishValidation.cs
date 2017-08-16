using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SING.Infrastructure.Validation
{
    public class EnglishValidation 
    {
        private object _type;//默认为不可带空格不可为空的英文 1 不可带空格可为空的英文 2 可带空格不可为空的英文 3 可带空格可为空的英文
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
                string parm = "";
                if (type != null && type.ToString() != "")
                {
                    switch (type.ToString())
                    {
                        case "1":
                            parm = @"^[A-Za-z]{0,}$";
                            break;
                        case "2":
                            parm = @"(^[A-Za-z]{1,}$)|(^[A-Za-z]{1,}\s{0,}[A-Za-z]{1,}$)";
                            break;
                        case "3":
                            parm = @"(^[A-Za-z]{0,}$)|(^[A-Za-z]{1,}\s{0,}[A-Za-z]{1,}$)";
                            break;
                        default:
                            parm = @"^[A-Za-z]{1,}$";
                            break;
                    }
                }
                else
                {
                    parm = @"^[A-Za-z]{1,}$";
                }
                Regex rg = new Regex(parm);
                Match mh = rg.Match(input.Trim());
                if (!mh.Success)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
