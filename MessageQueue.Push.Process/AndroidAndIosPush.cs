using System.Collections.Generic;
using System.Linq;
using cn.jpush.api;
using cn.jpush.api.push.mode;
using Zhongmubao.Push.Common;
using Zhongmubao.Push.DAL;
using Zhongmubao.Push.Model;

namespace Zhongmubao.Push.Process
{
    public class AndroidAndIosPush
    {
        /// <summary>
        /// 客户消息表数据服务
        /// </summary>
        private static readonly CustomerJPushService CusJpServer = new CustomerJPushService();

        /// <summary>
        /// 极光推送（ios和安卓）
        /// </summary>
        /// <param name="push">系统消息推送</param>
        /// <param name="platform"></param>
        public static void Jpush(SystemPushMongo push, Constants.DataType.Platform platform)
        {
            var customerId = push.CustomerId;
            var title = push.Title;
            var content = push.Content;
            var client = new JPushClient(Constants.Jpush.AppKey, Constants.Jpush.MasterSecret);

            var list = CusJpServer.GetListByCusId(customerId);

            // android -->01  iod -->02
            var pushList = list.Where(en => en.Platform.Equals(EnumOperation.Description(platform))).ToArray();


            if (!pushList.Any()) return;

            if (platform == Constants.DataType.Platform.Android)
            {
                var androidHashSet = new HashSet<string>();
                foreach (var customerJPush in pushList)
                {
                    androidHashSet.Add(customerJPush.RegId);
                }
                var payload = new PushPayload(Platform.android(), Audience.s_registrationId(androidHashSet),
                    Notification.android(title, content));

                client.SendPush(payload);
            }
            else
            {
                var iosHashSet = new HashSet<string>();
                foreach (var customerJPush in pushList)
                {
                    iosHashSet.Add(customerJPush.RegId);
                }

#if DEBUG
                var payload = new PushPayload(Platform.ios(), Audience.s_registrationId(iosHashSet), Notification.ios(content), null, new Options());
#endif
#if !DEBUG
                    PushPayload payload = new PushPayload(Platform.ios(), Audience.s_registrationId(iosHashSet), Notification.ios(content));
#endif
                client.SendPush(payload);
            }
        }
    }
}
