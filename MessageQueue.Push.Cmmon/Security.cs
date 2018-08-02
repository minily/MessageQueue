using System;
using System.Security.Cryptography;
using System.Text;

namespace Zhongmubao.Push.Common
{
    /// <summary>
    /// 安全
    /// 创建:孙阿龙 2015年8月23日
    /// </summary>
    public class Security
    {
        /// <summary>
        /// MD5加密
        /// 创建:孙阿龙 2015年8月23日
        /// </summary>
        /// <param name="str">需要加密的明文</param>
        /// <param name="lowerCase">小写形式返回</param>
        public static string Md5(string str, bool lowerCase = true)
        {
            //new 
            MD5 md5 = new MD5CryptoServiceProvider();
            //获取密文字节数组
            ASCIIEncoding asc = new ASCIIEncoding();
            byte[] bytResult = md5.ComputeHash(asc.GetBytes(str));
            //转换成字符串，并取9到25位 
            //string strResult = BitConverter.ToString(bytResult, 4, 8);  
            //转换成字符串，32位 
            string strResult = BitConverter.ToString(bytResult);
            //BitConverter转换出来的字符串会在每个字符中间产生一个分隔符，需要去除掉 
            strResult = strResult.Replace("-", "");
            return lowerCase ? strResult.ToLower() : strResult.ToUpper();
        }
    }
}
