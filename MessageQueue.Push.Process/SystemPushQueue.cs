using System;
using Zhongmubao.Push.Common;
using Zhongmubao.Push.Model;
using Zhongmubao.Push.MQ;
using Zhongmubao.Push.Repository;

namespace Zhongmubao.Push.Process
{
    /// <summary>
    /// SystemPush消息队列
    /// </summary>
    public class SystemPushQueue
    {
        /// <summary>
        /// Mongodb数据源
        /// </summary>
        private readonly SystemPushRepository _pushRepository = new SystemPushRepository();
        ///// <summary>
        ///// 消息队列封装逻辑类
        ///// </summary>
        private readonly QueueProcessor<SystemPushMongo> _userQueue = new QueueProcessor<SystemPushMongo>("pushQueue", 10, 10000);

        public SystemPushQueue()
        {
            _userQueue.ProcessQueue = MessagePushHandle;
        }

        public void MessagePushHandle(SystemPushMongo push)
        {
            try
            {
                // 1、向对应平台分发消息
                switch (push.Type)
                {
                    case "01":
                        // 短信
                        SmsSend.Send(push);
                        break;
                    case "02":
                        // ios
                        AndroidAndIosPush.Jpush(push, Constants.DataType.Platform.Ios);
                        break;
                    case "03":
                        // android
                        AndroidAndIosPush.Jpush(push, Constants.DataType.Platform.Android);
                        break;
                    case "04":
                        // 微信
                        WeiXinSend.SendWeixinMessage(push);
                        break;
                    default://00
                        SmsSend.Send(push);
                        AndroidAndIosPush.Jpush(push, Constants.DataType.Platform.Ios);
                        AndroidAndIosPush.Jpush(push, Constants.DataType.Platform.Android);
                        WeiXinSend.SendWeixinMessage(push);
                        break;
                }

                // 修改消息状态为已推送
                push.Status = "02";
                _pushRepository.UpdateSystemPush(push);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void Import(SystemPushMongo model)
        {
            _userQueue.Enqueue(model);
        }
    }
}
