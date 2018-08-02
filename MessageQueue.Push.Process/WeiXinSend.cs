using System;
using System.IO;
using System.Net;
using System.Text;
using Zhongmubao.Push.Common;
using Zhongmubao.Push.DAL;
using Zhongmubao.Push.Model;

namespace Zhongmubao.Push.Process
{
    class WeiXinSend
    {
        /// <summary>
        /// 系统设置表数据服务
        /// </summary>
        private static readonly SystemConfigService SysConfigService = new SystemConfigService();
        /// <summary>
        /// 客户信息表数据服务
        /// </summary>
        private static readonly CustomerService CusServer = new CustomerService();

        /// <summary>
        /// 发送微信
        /// </summary>
        /// <param name="push">系统消息推送</param>
        public static void SendWeixinMessage(SystemPushMongo push)
        {
            try
            {
                var title = push.Title;
                var content = push.Content;
                var wxCustomer = CusServer.GetModel(push.CustomerId);
                if (null == wxCustomer/*|| string.IsNullOrEmpty(wxCustomer.OpenId)*/)
                {
                    throw new Exception("CustomerId=" + push.CustomerId + "的客户不存在");
                }
                var openId = wxCustomer.OpenId;

                var sysConfig = SysConfigService.GetModel(Config.WeiXinKey);
                var accessToken = sysConfig.Value;

                // 获取消息模板
                var datainfo = MessageTemplete(openId,title,content);

                GetPage("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token= " + accessToken, datainfo, "UTF-8");

            }
            catch (Exception ex)
            {
                //LogHelper.Error("红包-发生改变微信通知出现异常", exception);
                throw ex;
            }
        }
        public static string MessageTemplete(string openId, string title, string content)
        {
            var data = "{" +
                   "\"touser\":\"" + openId + "\"," +
                   "\"template_id\":\"sRzhOlJ0rUFX0AooLhWMc6pap20bHdQAQEvmnDFBH2M\"," +
                   "\"url\":\"\"," +
                   "\"topcolor\":\"#f43534\"," +
                   "\"data\":{" +
                           "\"first\": {" +
                               "\"value\":\"" + title + "\"," +
                               "\"color\":\"#173177\"" +
                           "}," +
                           "\"keyword1\":{" +
                               "\"value\":\"" + content + "\"," +
                               "\"color\":\"#173177\"" +
                           "}," +
                           "\"keyword2\": {" +
                               "\"value\":\"" + DateTime.Now + "\"," +
                               "\"color\":\"#173177\"" +
                           "}," +
                           "\"remark\":{" +
                               "\"value\":\"" + string.Empty + "\"," +
                               "\"color\":\"#173177\"" +
                           "}}}";
            return data;
        }

        public static string GetPage(string posturl, string postData, string strEncode)
        {
            Stream instream = null;
            HttpWebResponse response = null;
            var encoding = Encoding.GetEncoding(strEncode);
            var data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                var request = WebRequest.Create(posturl) as HttpWebRequest;

                var cookieContainer = new CookieContainer();
                if (request != null)
                {
                    request.CookieContainer = cookieContainer;
                    request.AllowAutoRedirect = true;
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    //request.ContentType = "multipart/form-data";
                    request.ContentLength = data.Length;
                    var outstream = request.GetRequestStream();
                    outstream.Write(data, 0, data.Length);
                    outstream.Close();
                    //发送请求并获取相应回应数据
                    response = request.GetResponse() as HttpWebResponse;
                }

                //response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                if (response != null)
                {
                    instream = response.GetResponseStream();
                }
                var sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                var content = sr.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                //LogHelper.Error(Config.Platform, ex.Message, ex);
                throw ex;
            }
        }

    }
}
