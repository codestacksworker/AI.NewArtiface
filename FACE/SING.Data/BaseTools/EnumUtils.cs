using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.BaseTools
{
    public abstract class ConstrainedEnumParser<TClass> where TClass : class
        // value type constraint S ("TEnum") depends on reference type T ("TClass") [and on struct]
    {
        // internal constructor, to prevent this class from being inherited outside this code
        internal ConstrainedEnumParser() { }
        // Parse using pragmatic/adhoc hard cast:
        //  - struct + class = enum
        //  - 'guaranteed' call from derived <System.Enum>-constrained type EnumUtils
        public static TEnum Parse<TEnum>(string value, bool ignoreCase = false) where TEnum : struct, TClass
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
        }
        public static bool TryParse<TEnum>(string value, out TEnum result, bool ignoreCase = false, TEnum defaultValue = default(TEnum)) where TEnum : struct, TClass
            // value type constraint S depending on T
        {
            var didParse = Enum.TryParse(value, ignoreCase, out result);
            if (didParse == false)
            {
                result = defaultValue;
            }
            return didParse;
        }
        public static TEnum ParseOrDefault<TEnum>(string value, bool ignoreCase = false, TEnum defaultValue = default(TEnum)) where TEnum : struct, TClass
            // value type constraint S depending on T
        {
            if (string.IsNullOrEmpty(value)) { return defaultValue; }
            TEnum result;
            if (Enum.TryParse(value, ignoreCase, out result)) { return result; }
            return defaultValue;
        }

        #region  枚举值的 整形转字符串
        public static string Parse<TEnum>(int current) where TEnum : struct, IConvertible
        {
            if (Enum.IsDefined(typeof(TEnum), current))
            {
                if (typeof(TEnum).IsEnum)
                {
                    foreach (var bt in System.Enum.GetValues(typeof(TEnum)))
                    {
                        if (System.Convert.ToInt32(bt) == current)
                            return bt.ToString();
                    }
                }
            }
            return "None";
        }
        #endregion
    }

    /// <summary>
    ///The class constraint to parse outside the it for enum
    /// </summary>
    public class EnumUtils : ConstrainedEnumParser<System.Enum>
    // reference type constraint to any <System.Enum>
    {
        // call to parse will then contain constraint to specific <System.Enum>-class

        public static IEnumerable<EnumData> GetEnumDataList<TEnum>() where TEnum : struct, IConvertible
        {
            List<EnumData> result = new List<EnumData>();

            foreach (TEnum bt in (TEnum[]) System.Enum.GetValues(typeof(TEnum)))
            {
                result.Add(new EnumData() {Name = bt.ToString(), Value = System.Convert.ToInt32(bt)});
            }

            return result;
        }

        public static ObservableCollection<EnumData> GetEnumDataObservableList<TEnum>() where TEnum : struct, IConvertible
        {
            ObservableCollection<EnumData> result = new ObservableCollection<EnumData>();

            foreach (TEnum bt in (TEnum[])Enum.GetValues(typeof(TEnum)))
            {
                result.Add(new EnumData() { Name = bt.ToString(), Value = System.Convert.ToInt32(bt) });
            }

            return result;
        }

        public static string GetDescription(Enum obj)
        {
            string objName = obj.ToString();
            Type t = obj.GetType();
            FieldInfo fi = t.GetField(objName);
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return arrDesc[0].Description;
        }
    }

    #region  EnumUtils Test Code
    //WeekDay parsedDayOrArgumentException = EnumUtils.Parse<WeekDay>("monday", ignoreCase: true);
    //WeekDay parsedDayOrDefault;
    //bool didParse = EnumUtils.TryParse<WeekDay>("clubs", out parsedDayOrDefault, ignoreCase: true);
    //parsedDayOrDefault = EnumUtils.ParseOrDefault<WeekDay>("friday", ignoreCase:true, defaultValue:WeekDay.Sunday);
    #endregion
}
