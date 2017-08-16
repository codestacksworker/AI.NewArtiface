using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Help
{
    public static class TimeConvert
    {
        public static DateTime Convert(long lTime)
        {
            if (lTime == 0) return DateTime.Now;

            DateTime s = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            long Time = long.Parse(lTime + "0000000");

            TimeSpan toNow = new TimeSpan(Time);

            DateTime dtResult = s.Add(toNow);

            return dtResult;
        }

        public static long Convert(DateTime time)
        {
            if (time == null) return 0L;

            DateTime s = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            TimeSpan toNow = time.Subtract(s);

            long timeStamp = toNow.Ticks;

            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 7));

            return timeStamp;
        }

        public static long Convert(string sTime)
        {
            if (string.IsNullOrEmpty(sTime)) return 0L;
            DateTime time = DateTime.ParseExact(sTime, "yyyyMMdd HH:mm:ss", new CultureInfo("en-US"));
            return Convert(time);
        }

        public static string Convert(long lTime, string format)
        {
            if (lTime == 0) return null;

            return Convert(lTime).ToString(format);
        }

        public static DateTime SToDateTime(this string sTime)
        {
            if (string.IsNullOrEmpty(sTime)) return DateTime.Now;
            return DateTime.ParseExact(sTime, "yyyyMMdd HH:mm:ss", new CultureInfo("en-US"));
        }

        public static string LToString(this long lTime)
        {
            if (lTime == 0) return null;

            return lTime.LToDateTime().ToString("yyyyMMdd HH:mm:ss");
        }

        public static long SToLong(this string sTime)
        {
            if (string.IsNullOrEmpty(sTime)) return 0L;
            DateTime time = DateTime.ParseExact(sTime, "yyyyMMdd HH:mm:ss", new CultureInfo("en-US"));
            return time.DToLong();
        }

        public static DateTime LToDateTime(this long lTime)
        {
            if (lTime == 0) return DateTime.Now;

            DateTime s = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            long Time = long.Parse(lTime + "0000000");

            TimeSpan toNow = new TimeSpan(Time);

            DateTime dtResult = s.Add(toNow);

            return dtResult;
        }

        public static long DToLong(this DateTime time)
        {
            if (time == null) return 0L;

            DateTime s = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            TimeSpan toNow = time.Subtract(s);

            long timeStamp = toNow.Ticks;

            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 7));

            return timeStamp;
        }

        public static string DToString(this DateTime time)
        {
            if (time == null) return null;
            return time.ToString("yyyyMMdd HH:mm:ss"); 
        }

        public static DateTime SToShortDate(this string sTime)
        {
            if (string.IsNullOrEmpty(sTime)) return DateTime.Now;
            return DateTime.ParseExact(sTime, "yyyyMMdd", new CultureInfo("en-US"));
        }

        public static long SToShortDateLong(this string sTime)
        {
            if (string.IsNullOrEmpty(sTime)) return 0L;
            return sTime.SToShortDate().DToLong();
        }

        public static string DToShortDateString(this DateTime time)
        {
            if (time == null) return null;
            return time.ToString("yyyyMMdd");
        }

        public static string LToShortDateString(this long lTime)
        {
            if (lTime == 0) return null;
            return lTime.LToDateTime().ToString("yyyyMMdd");
        }

        public static string DToVideoTime(this DateTime time)
        {
            if (time == null) return string.Empty;
            return time.ToString("yyyy-MM-dd-HH-mm-ss"); 
        }
    }
}
