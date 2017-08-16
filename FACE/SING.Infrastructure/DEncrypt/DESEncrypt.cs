using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.DEncrypt
{
    /// <summary>  
    /// DES加密/解密类。  
    /// </summary>  
    public static class DESEncrypt
    {
        //密钥  
        private static byte[] arrDESKey = new byte[] { 42, 16, 93, 156, 78, 4, 218, 32 };
        private static byte[] arrDESIV = new byte[] { 55, 103, 246, 79, 36, 99, 167, 3 };

        #region ========加密========   
        /// <summary>
        /// DES 加密
        /// </summary>
        public static string Des(this string value, string keyVal, string ivVal)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(value);
                var des = new DESCryptoServiceProvider { Key = Encoding.ASCII.GetBytes(keyVal.Length > 8 ? keyVal.Substring(0, 8) : keyVal), IV = Encoding.ASCII.GetBytes(ivVal.Length > 8 ? ivVal.Substring(0, 8) : ivVal) };
                var desencrypt = des.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return BitConverter.ToString(result);
            }
            catch { return "加密出错！"; }
        }

        public static string Encode32(string value, string keyStr)
        {
            byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);
            SHA1 ha = new SHA1Managed();
            byte[] hb = ha.ComputeHash(keyByteArray);
            byte[] sKey = new byte[8];
            byte[] sIV = new byte[8];
            for (int i = 0; i < 8; i++)
                sKey[i] = hb[i];
            for (int i = 8; i < 16; i++)
                sIV[i - 8] = hb[i];

            MemoryStream ms = Encode(value, sKey, sIV);
            return ms.ToArray().Bytes2Str();
        }

        /// <summary>  
        /// 加密。  
        /// </summary>  
        /// <param name="m_Need_Encode_String"></param>  
        /// <returns></returns>  
        public static string Encode64(string value, byte[] arrDESKey, byte[] arrDESIV)
        {
            if (value == null)
            {
                throw new Exception("Error: \n源字符串为空！！");
            }
            MemoryStream objMemoryStream = Encode(value, arrDESKey, arrDESIV);
            return Convert.ToBase64String(objMemoryStream.GetBuffer(), 0, (int)objMemoryStream.Length);
        }
        #endregion

        #region ========解密========   
        /// <summary>
        /// DES 解密
        /// </summary>
        public static string UnDes(this string value, string keyVal, string ivVal)
        {
            try
            {
                string[] sInput = value.Split("-".ToCharArray());
                byte[] data = new byte[sInput.Length];
                for (int i = 0; i < sInput.Length; i++)
                {
                    data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
                }
                var des = new DESCryptoServiceProvider { Key = Encoding.ASCII.GetBytes(keyVal.Length > 8 ? keyVal.Substring(0, 8) : keyVal), IV = Encoding.ASCII.GetBytes(ivVal.Length > 8 ? ivVal.Substring(0, 8) : ivVal) };
                var desencrypt = des.CreateDecryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF8.GetString(result);
            }
            catch { return "解密出错！"; }
        }

        /// <summary>  
        /// 解密字符串  
        /// </summary>  
        /// <param name="inputStr">要解密的字符串</param>  
        /// <param name="keyStr">密钥</param>  
        /// <returns>解密后的结果</returns>  
        public static string Decode32(string value, string keyStr)
        {

            byte[] inputByteArray = new byte[value.Length / 2];
            for (int x = 0; x < value.Length / 2; x++)
            {
                int i = (Convert.ToInt32(value.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);
            SHA1 ha = new SHA1Managed();
            byte[] hb = ha.ComputeHash(keyByteArray);
            byte[] sKey = new byte[8];
            byte[] sIV = new byte[8];
            for (int i = 0; i < 8; i++)
                sKey[i] = hb[i];
            for (int i = 8; i < 16; i++)
                sIV[i - 8] = hb[i];

            MemoryStream ms = Decode(inputByteArray, sKey, sIV);

            //return ms.ToArray().Bytes2Str();
            return Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>  
        /// 解密。  
        /// </summary>  
        /// <param name="m_Need_Encode_String"></param>  
        /// <returns></returns>  
        public static string Decode64(string value, byte[] arrDESKey, byte[] arrDESIV)
        {
            if (value == null)
            {
                throw new Exception("Error: \n源字符串为空！！");
            }
           
            byte[] arrInput = Convert.FromBase64String(value);
            MemoryStream objCryptoStream = Decode(arrInput, arrDESKey, arrDESIV);
            StreamReader objStreamReader = new StreamReader(objCryptoStream);
            return objStreamReader.ReadToEnd();
        }
        #endregion

        #region 加密文件  

        /// <summary>  
        /// 加密文件  
        /// </summary>  
        /// <param name="filePath">输入文件路径</param>  
        /// <param name="savePath">加密后输出文件路径</param>  
        /// <param name="keyStr">密码，可以为“”</param>  
        /// <returns></returns>    
        public static bool EncryptFile(string filePath, string savePath, string keyStr)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            FileStream fs = File.OpenRead(filePath);
            byte[] inputByteArray = new byte[fs.Length];
            fs.Read(inputByteArray, 0, (int)fs.Length);
            fs.Close();
            byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);
            SHA1 ha = new SHA1Managed();
            byte[] hb = ha.ComputeHash(keyByteArray);
            byte[] sKey = new byte[8];
            byte[] sIV = new byte[8];
            for (int i = 0; i < 8; i++)
                sKey[i] = hb[i];
            for (int i = 8; i < 16; i++)
                sIV[i - 8] = hb[i];
            des.Key = sKey;
            des.IV = sIV;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            fs = File.OpenWrite(savePath);
            foreach (byte b in ms.ToArray())
            {
                fs.WriteByte(b);
            }
            fs.Close();
            cs.Close();
            ms.Close();
            return true;
        }

        #endregion

        #region 解密文件  

        /// <summary>  
        /// 解密文件  
        /// </summary>  
        /// <param name="filePath">输入文件路径</param>  
        /// <param name="savePath">解密后输出文件路径</param>  
        /// <param name="keyStr">密码，可以为“”</param>  
        /// <returns></returns>      
        public static bool DecryptFile(string filePath, string savePath, string keyStr)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            FileStream fs = File.OpenRead(filePath);
            byte[] inputByteArray = new byte[fs.Length];
            fs.Read(inputByteArray, 0, (int)fs.Length);
            fs.Close();
            byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);
            SHA1 ha = new SHA1Managed();
            byte[] hb = ha.ComputeHash(keyByteArray);
            byte[] sKey = new byte[8];
            byte[] sIV = new byte[8];
            for (int i = 0; i < 8; i++)
                sKey[i] = hb[i];
            for (int i = 8; i < 16; i++)
                sIV[i - 8] = hb[i];
            des.Key = sKey;
            des.IV = sIV;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            fs = File.OpenWrite(savePath);
            foreach (byte b in ms.ToArray())
            {
                fs.WriteByte(b);
            }
            fs.Close();
            cs.Close();
            ms.Close();
            return true;
        }

        #endregion    

        #region private

        private static MemoryStream Encode(string value, byte[] arrDESKey, byte[] arrDESIV)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            MemoryStream objMemoryStream = new MemoryStream();
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(arrDESKey, arrDESIV), CryptoStreamMode.Write);
            StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);
            objStreamWriter.Write(value);
            objStreamWriter.Flush();
            objCryptoStream.FlushFinalBlock();
            objMemoryStream.Flush();

            return objMemoryStream;
        }

        private static MemoryStream Decode(byte[] value, byte[] arrDESKey, byte[] arrDESIV)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            MemoryStream objMemoryStream = new MemoryStream();
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateDecryptor(arrDESKey, arrDESIV), CryptoStreamMode.Read);
            StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);
            objStreamWriter.Write(value);
            objStreamWriter.Flush();
            objCryptoStream.FlushFinalBlock();
            objMemoryStream.Flush();

            return objMemoryStream;
        }

        #endregion
    }
}
