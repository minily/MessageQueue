using System.Configuration;

namespace Zhongmubao.Push.Common
{
    public class Config
    {
        public static string SmsAccount = ConfigurationManager.AppSettings["SmsAccount"];
        public static string SmsPassword = ConfigurationManager.AppSettings["SmsPassword"];
        public static string SmsAddress = ConfigurationManager.AppSettings["SmsAddress"];
        /// <summary>
        /// 微信key
        /// </summary>
        public static string WeiXinKey = ConfigurationManager.AppSettings["WeiXinKey"];
        /// <summary>
        /// 微信消息模板路径
        /// </summary>
        public static string MessageTempPath = ConfigurationManager.AppSettings["MessageTempPath"];
    }
}
