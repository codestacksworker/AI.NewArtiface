using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Dev_SING.Data.BaseTools
{
    public class AssistTools
    {
        /// <summary>
        /// 移除一个对象指定事件的所有注册的方法
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">当前对象</param>
        /// <param name="eventName">事件名</param>
        public static void RemoveEvent<T>(T obj, string eventName)
        {
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;
            EventInfo[] eventInfo = obj.GetType().GetEvents(bindingFlags);
            if (eventInfo == null)
            {
                return;
            }

            foreach (EventInfo info in eventInfo)
            {
                if (string.Compare(info.Name, eventName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    FieldInfo fieldInfo = info.DeclaringType.GetField(info.Name, bindingFlags);
                    if (fieldInfo != null)
                    {
                        fieldInfo.SetValue(obj, null);
                    }
                    break;
                }
            }
        }

        private void ClearAllEvents(object objectHasEvents, string eventName)
        {
            if (objectHasEvents == null)
            {
                return;
            }

            try
            {
                EventInfo[] events = objectHasEvents.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (events == null || events.Length < 1)
                {
                    return;
                }

                for (int i = 0; i < events.Length; i++)
                {
                    EventInfo ei = events[i];

                    if (ei.Name == eventName)
                    {
                        FieldInfo fi = ei.DeclaringType.GetField(ei.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (fi != null)
                        {
                            fi.SetValue(objectHasEvents, null);
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        static public object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;
            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// 52_#_51000001_1_101  解析通道号
        /// </summary>
        /// <param name="channelno"></param>
        /// <returns></returns>
        public static string[] AnalyChannelNo(string channelno)
        {
            if (!string.IsNullOrEmpty(channelno) && channelno.Contains("_"))
            {
                string[] args = channelno.Split('_');
                return new[] { args[0], args[2], args[3], args[4], "1" };
            }
            return null;
        }

        #region  GUID 生成
        private static readonly GuidGenerate Generate = new GuidGenerate();
        public static string guid => Generate.Getguid;

        public static string GuidN => Generate.GetguidN;

        public static string GuidD => Generate.GetguidD;

        public static string GuidB => Generate.GetguidB;

        public static string GuidP => Generate.GetguidP;

        public static string GuidX => Generate.GetguidX;

        protected class GuidGenerate
        {
            public string Getguid => Guid.NewGuid().ToString();// 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  
            public string GetguidN => Guid.NewGuid().ToString("N");// e0a953c3ee6040eaa9fae2b667060e09   
            public string GetguidD => Guid.NewGuid().ToString("D");// 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  
            public string GetguidB => Guid.NewGuid().ToString("B");// {734fd453-a4f8-4c5d-9c98-3fe2d7079760}
            public string GetguidP => Guid.NewGuid().ToString("P");//  (ade24d16-db0f-40af-8794-1e08e2040df3)  
            public string GetguidX => Guid.NewGuid().ToString("X");// {0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}  
        }
        #endregion
    }

    public static class Extend
    {
        public static void Add<T>(this Collection<T> List, T item, int Count)
        {
            //T t = default(T);
            if (List.Count >= Count)
            {
                //t = List.FirstOrDefault();
                //List.Remove(t);
                //t = default(T);
                List.RemoveAt(0);
            }

            List.Add(item);
        }

        public static void Insert<T>(this Collection<T> List, T item, int Count)
        {
            //T t = default(T);
            if (List.Count >= Count)
            {
                //t = List.FirstOrDefault();
                //List.Remove(t);
                //t = default(T);
                List.RemoveAt(List.Count - 1);
            }

            List.Insert(0, item);
        }

        /// <summary>
        /// 从枚举中获取Description
        /// 说明：
        /// 单元测试-->通过
        /// </summary>
        /// <param name="enumName">需要获取枚举描述的枚举</param>
        /// <returns>描述内容</returns>
        public static string GetDescription(this Enum enumName)
        {
            string _description = string.Empty;
            FieldInfo _fieldInfo = enumName.GetType().GetField(enumName.ToString());
            DescriptionAttribute[] _attributes = _fieldInfo.GetDescriptAttr();
            if (_attributes != null && _attributes.Length > 0)
                _description = _attributes[0].Description;
            else
                _description = enumName.ToString();
            return _description;
        }
        /// <summary>
        /// 获取字段Description
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        /// <returns>DescriptionAttribute[] </returns>
        public static DescriptionAttribute[] GetDescriptAttr(this FieldInfo fieldInfo)
        {
            if (fieldInfo != null)
            {
                return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return null;
        }
        /// <summary>
        /// 根据Description获取枚举
        /// 说明：
        /// 单元测试-->通过
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="description">枚举描述</param>
        /// <returns>枚举</returns>
        public static T GetEnumName<T>(string description)
        {
            Type _type = typeof(T);
            foreach (FieldInfo field in _type.GetFields())
            {
                DescriptionAttribute[] _curDesc = field.GetDescriptAttr();
                if (_curDesc != null && _curDesc.Length > 0)
                {
                    if (_curDesc[0].Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
        }
        /// <summary>
        /// 将枚举转换为ArrayList
        /// 说明：
        /// 若不是枚举类型，则返回NULL
        /// 单元测试-->通过
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns>ArrayList</returns>
        public static ArrayList ToArrayList(this Type type)
        {
            if (type.IsEnum)
            {
                ArrayList _array = new ArrayList();
                Array _enumValues = Enum.GetValues(type);
                foreach (Enum value in _enumValues)
                {
                    _array.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
                }
                return _array;
            }
            return null;
        }

        public static IntPtr GetWindowHwnd(this Window window)
        {
            if (window == null)
                return new WindowInteropHelper(window).Handle;

            return IntPtr.Zero;
        }

        //句柄的取得不要在构造 函数中取得，此时的vitual还没有产生，在Loaded中 就可以了
        public static IntPtr GetControlHwnd(this DependencyObject dependecyObject)
        {
            if (dependecyObject != null)
            {
                var hwndSource = (HwndSource)PresentationSource.FromDependencyObject(dependecyObject);
                IntPtr handle = hwndSource.Handle;
                return handle;
            }
            return IntPtr.Zero;
        }

        public static IntPtr GetControlHwnd(this UIElement uielement)
        {
            var hwndSource = (HwndSource)PresentationSource.FromVisual(uielement);
            if (hwndSource != null)
                return hwndSource.Handle;

            return IntPtr.Zero;
        }
    }

}

