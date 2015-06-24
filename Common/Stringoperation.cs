using System;
using System.Text;
namespace Common
{
    public class Stringoperation
    {
        public static String chineseStr(String str)
        {
            if (str == null)
            {
                str = "";
            }
            else
            {
                try
                {
                    byte[] buffer = Encoding.Unicode.GetBytes(str);
                    str = Encoding.GetEncoding("Unicode").GetString(buffer);
                }
                catch (Exception e)
                {
                }
            }
            return str;
        }
        /// <summary>
        /// 由于某一个字段，包含有汉字和数字。而一个汉字是两位占位符的大小，如果单从字符串长度来看，一个汉字的长度为1。
        /// 假如按一个包含汉字字符串长度就等于占位符大小（如果只包含字母和数字的字符串这样计算是对的）来计算的话，
        /// 一个汉字却等于一个占位（显然是错误的），这样就会出现问题了，字段就无法对齐了。因为对齐是以占位大小为标准的。
        /// 此方法扩展自String.PadLeft和String.PadRight
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <param name="totalByteCount">总长度</param>
        /// <param name="c">替换字符</param>
        /// <returns></returns>
        public static String PadLeftEx(string str, int totalByteCount, char c)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount, c);
            return w;
        }
        public static string PadRightEx(string str, int totalByteCount, char c)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount, c);
            return w;
        }
    }
}
