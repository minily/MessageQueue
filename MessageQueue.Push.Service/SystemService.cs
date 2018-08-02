using System;
using System.Collections.Generic;
using Zhongmubao.Push.Model;
using Zhongmubao.Push.Process;
using Zhongmubao.Push.Repository;

namespace Zhongmubao.Push.Service
{
    public class SystemService
    {
        /// <summary>
        /// 消息队列
        /// </summary>
        private static SystemPushQueue queue = new SystemPushQueue();

        /// <summary>
        /// 系统推送消息服务接口
        /// </summary>
        public void Push()
        {
            // 1、获取未推送消息列表
            string status = "01";
            SystemPushRepository pushRepository = new SystemPushRepository();
            List<SystemPushMongo> pushList = pushRepository.GetSystemPushList(status);

            //if (pushList.Count == 0)
            //{
            //    SystemPush pu = new SystemPush();
            //    pu.Title = "test";
            //    pu.Content = "测试内容";
            //    pu.CustomerId = 4194;
            //    pu.Type = "04";
            //    pu.Status = "01";
            //    pu.CreateTime = DateTime.Now;
            //    pushRepository.AddSystemPush(pu);
            //    pushList = pushRepository.GetSystemPushList(status);
            //}

            for (int i = 0; i < pushList.Count; i++)
            {
                SystemPushMongo push = pushList[i];

                // 写入消息队列
                queue.Import(push);
            }

        }
    }
}

