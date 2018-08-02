using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Zhongmubao.Push.Common;
using Zhongmubao.Push.DAL;
using Zhongmubao.Push.Model;

namespace Zhongmubao.Push.Process
{
    public class SmsSend
    {
        /// <summary>
        /// 客户信息表数据服务
        /// </summary>
        private static readonly CustomerService CusServer = new CustomerService();

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="push">系统消息推送</param>
        /// <returns></returns>
        public static string Send(SystemPushMongo push)
        {
            string result;
            try
            {
                Customer smsCustomer = CusServer.GetModel(push.CustomerId);
                string password = Security.Md5(Config.SmsAccount + Config.SmsPassword, false);

                var parameters = new NameValueCollection
                {
                    {"sn", Config.SmsAccount},
                    {"pwd", password},
                    {"mobile", smsCustomer.Phone},
                    {"Content", push.Content},
                    {"Ext", ""},
                    {"stime", ""},
                    {"Rrid", ""},
                    {"msgfmt", ""}
                };

                var client = new WebClient();

                var ret = client.UploadValues(Config.SmsAddress, "POST", parameters);
                result = Encoding.Default.GetString(ret);
            }
            catch (Exception ex)
            {

                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }

            return result;
        }
    }
}
