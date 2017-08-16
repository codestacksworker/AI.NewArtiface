using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.DEncrypt
{
    public static class Md5Encrypt
    {
        #region Md516

        public static string Md516(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            }

            var encoding = Encoding.Default;

            var original = value.FormatByte(encoding);

            return original.Md516();
        }

        public static string Md516(this byte[] value)
        {
            return MD516(value);
        }

        public static string MD516(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            }

            var md5 = new MD5CryptoServiceProvider();

            byte[] original =BaseEncrypt.HashAlgorithmBase(md5, value);

            string t2 = BitConverter.ToString(original, 4, 8);

            t2 = t2.Replace("-", "");

            return t2;
        }

        #endregion

        #region Md532

        public static string Md532(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            }

            var encoding = Encoding.UTF8;

            var original = value.FormatByte(encoding);

            return original.Md532();
        }

        /// <summary>
        /// 加权MD5加密
        /// </summary>
        public static string Md532(this string value, string salt)
        {
            return salt == null ? value.Md532() : (value + "『" + salt + "』").Md532();
        }

        public static string Md532(this byte[] value)
        {
            return MD532(value);
        }

        public static string MD532(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            }

            MD5 md5 = MD5.Create();

            byte[] original = BaseEncrypt.HashAlgorithmBase(md5, value);

            return original.Bytes2Str();
        }
        #endregion

        #region Md564

        public static string Md564(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            }

            var encoding = Encoding.UTF8;

            var original = value.FormatByte(encoding);

            return original.Md564();
        }

        public static string Md564(this byte[] value)
        {
            return MD564(value);
        }

        public static string MD564(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            }

            MD5 md5 = MD5.Create();

            byte[] original =BaseEncrypt.HashAlgorithmBase(md5, value);

            return Convert.ToBase64String(original, 0, original.Length);
        }
        #endregion
    }
}
