using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.BaseTools
{
    public static class Extends
    {
        public static void Cast<T, TU>(this T origin, TU target)
            where T : new()
            where TU : new()
        {
            if (origin == null)
                return;

            if (target == null)
                return;

            PropertyInfo[] properties = (target.GetType()).GetProperties();
            PropertyInfo[] fields = (origin.GetType()).GetProperties();
            foreach (PropertyInfo t in fields)
            {
                foreach (PropertyInfo t1 in properties)
                {
                    if (t.Name.ToUpper() == t1.Name.ToUpper() && t1.CanWrite)
                    {
                        t1.SetValue(target, t.GetValue(origin, null), null);
                    }
                }
            }
        }

        public static T PopulateEntityFromCollection<T>(this T entity, IDataReader collection) where T : new()
        {
            //初始化 如果为null
            if (entity == null)
            {
                entity = new T();
            }
            //得到类型
            Type type = typeof(T);
            //取得属性集合
            PropertyInfo[] pi = type.GetProperties();
            foreach (PropertyInfo item in pi)
            {
                //给属性赋值
                if (collection[item.Name] != null)
                {
                    item.SetValue(entity, Convert.ChangeType(collection[item.Name], item.PropertyType), null);
                }
            }
            return entity;
        }
    }

    public class ReflectorHelper
    {

    }
}
