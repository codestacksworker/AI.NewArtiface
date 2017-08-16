using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_DynamicComparison.Models
{
    public class ConstModel
    {
        private static string widthStr = "Width";
        private static string heightStr = "Height";

        public static string WidthStr
        {
            get
            {
                return widthStr;
            }
            set { widthStr = value; }
        }

        public static string HeightStr
        {
            get
            {
                return heightStr;
            }
            set { heightStr = value; }
        }
    }
}
