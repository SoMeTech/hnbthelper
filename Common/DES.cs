using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
namespace Common
{
    /// <summary>
    /// 加密与解密操作类
    /// </summary>
    public static class DES
    {
        /// <summary>
        /// DES加密。
        /// </summary>
        /// <param name="encryptString">需要加密的字符串</param>
        /// <param name="key">Key，XXXWWWYY</param>
        /// <returns></returns>
        public static string DESEncrypt(string encryptString, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(encryptString);
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        /// <summary>
        /// DES解密。
        /// </summary>
        /// <param name="decryptString">需要解密的字符串</param>
        /// <param name="sKey">Key，XXXWWWYY</param>
        /// <returns></returns>
        public static string DESDecrypt(string decryptString, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[decryptString.Length / 2];
            for (int x = 0; x < decryptString.Length / 2; x++)
            {
                int i = (Convert.ToInt32(decryptString.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        /// <summary>
        ///  慧舟解密身份证和姓名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ssssdecrypt(string str)
        {
            string strreturn = "";
            if ((str == null) || (str.Length < 3) || (!str.StartsWith("^1")))
            {
                return str;
            }
            string strSrc = str.Substring(2);
            string decryptVersion = str.Substring(0, 2);
            char[] arrychar = strSrc.ToCharArray();
            for (int i = 0; i < arrychar.Length; i++)
            {
                int letter1 = arrychar[i] ^ 0x73;
                arrychar[i] = ((char)letter1);
            }
            string ss = new string(arrychar);
            strreturn = Uri.UnescapeDataString(ss);
            return strreturn;
        }
        /// <summary>
        /// 慧舟加密身份证和姓名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ssssencrypt(string str)
        {
            string strencode = "";
            strencode = Uri.EscapeDataString(str);
            String strReturn = "";
            if ((strencode == null) || (strencode.StartsWith("^1")))
            {
                return str;
            }
            char[] arrychar = strencode.ToCharArray();
            char[] arryenchar = new char[arrychar.Length * 2];
            for (int i = 0; i < arrychar.Length; i++)
            {
                int letter = arrychar[i] ^ 0x73;
                arrychar[i] = ((char)letter);
            }
            strReturn = new string(arrychar);
            if (arrychar.Length > 0)
            {
                strReturn = "^1" + strReturn;
            }
            return strReturn;
        }
        /// <summary>
        /// 慧舟加密用户密码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Jm(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            MD5 md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.GetEncoding("GBK").GetBytes("pd" + str));
            return Convert.ToBase64String(bytes);
        }
    }
}
