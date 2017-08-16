using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Helper
{
  public static class ResHelper
    {
        public static void ChangeCulture(string langName)
        {
            Resource.ResourceService.GetInstance().ChangeCulture(langName);
        }

        public static String GetValue(string key)
        {
            return Resource.ResourceService.GetInstance().GetValue(key);
        }
    }
}
