using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Logger;

namespace SING.Infrastructure.DEncrypt
{
    /// <summary>  
    /// 得到随机安全码（哈希加密）。  
    /// </summary>  
    public class HashEncode
    {
        public HashEncode()
        {
            //  
            // TODO: 在此处添加构造函数逻辑  
            //  
        }

        /// <summary>  
        /// 得到随机哈希加密字符串  
        /// </summary>  
        /// <returns></returns>  
        public static string GetSecurity()
        {
            string value = HashEncoding(GetRandomValue());
            return value;
        }

        /// <summary>  
        /// 得到一个随机数值  
        /// </summary>  
        /// <returns></returns>  
        public static string GetRandomValue()
        {
            Random Seed = new Random();
            string RandomVaule = Seed.Next(1, int.MaxValue).ToString();
            return RandomVaule;
        }

        /// <summary>  
        /// 哈希加密一个字符串  
        /// </summary>  
        /// <param name="Security"></param>  
        /// <returns></returns>  
        public static string HashEncoding(string value)
        {
            byte[] Value;
            UnicodeEncoding Code = new UnicodeEncoding();
            byte[] Message = Code.GetBytes(value);
            SHA512Managed Arithmetic = new SHA512Managed();
            Value = Arithmetic.ComputeHash(Message);
            value = "";
            foreach (byte o in Value)
            {
                value += (int) o + "O";
            }
            return value;
        }

        /// <summary>  
        /// 方法二  
        /// HashAlgorithm加密  
        /// 这种加密是  字母加-加字符    
        /// Example: password是admin 加密变成后19-A2-85-41-44-B6-3A-8F-76-17-A6-F2-25-01-9B-12  
        /// </summary>  
        /// <param name="password"></param>  
        /// <returns></returns>  
        public String HashEncrypt(string value)
        {
            Byte[] hashedBytes = null;
            try
            {
                Byte[] clearBytes = new UnicodeEncoding().GetBytes(value);
                hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            }
            catch (Exception ex)
            {
                Logger.Error("==============你引起了一个错误是==============" + ex.Message.ToString());
            }
            return BitConverter.ToString(hashedBytes); //MD5加密  
        }

        /// <summary>  
        /// 方法三:  
        /// MD5  +   HashCode加密  
        /// Example: password是admin 加密变成后 895b7da64943134be17b825ce118456c  
        /// </summary>  
        /// <returns></returns>  
        public String MD5HashCodeEncrypt(string value)
        {
            return HashEncrypt(value).Md532(); //在HashEncrypt基础上再MD5  
        }

        /// <summary>  
        /// 方法四:  
        /// HashCode +MD5 加密  
        /// Example: password是admin 加密变成后EB-1D-6D-E2-FC-F1-CD-94-4D-75-78-E6-3D-7A-12-32  
        /// </summary>  
        /// <param name="EncryptPwd"></param>  
        /// <returns></returns>  
        public String HashCodeMD5Encrypt(string value)
        {
            return HashEncrypt(value.Md532()); //在MD5基础再HashCode  
        }

        /// <summary>  
        /// 方法五  
        /// </summary>  
        /// <param name="EncryptPwd"></param>  
        /// <returns></returns>  
        public String HashMD5Encrypt(string value)
        {
            return HashCodeMD5Encrypt(HashCodeMD5Encrypt(value)); //在HashCodeMD5Encrypt基础再HashCode  
        }

        /// <summary>  
        /// 方法六  
        /// 哈哈是不是有点晕呢？  
        /// 大家伙可以继续写.  
        /// </summary>  
        /// <param name="EncryptPwd"></param>  
        /// <returns></returns>  
        public String MD5HashEncrypt(string value)
        {
            return MD5HashCodeEncrypt(MD5HashCodeEncrypt(value)); //在MD5基础再HashCode  
        }
    }
}
