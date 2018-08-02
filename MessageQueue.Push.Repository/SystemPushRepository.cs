using System.Collections.Generic;
using System.Linq;
using MongoRepository;
using Zhongmubao.Push.Model;

namespace Zhongmubao.Push.Repository
{
    public class SystemPushRepository
    {
        private readonly IRepository<SystemPushMongo> _customerPushRepository = new MongoRepository<SystemPushMongo>();

        public void AddSystemPush(SystemPushMongo systemPush)
        {
            _customerPushRepository.Add(systemPush);
        }

        public List<SystemPushMongo> GetSystemPushList(int customerId)
        {
            return _customerPushRepository.Collection.FindAll().Where(en => en.CustomerId == customerId).ToList();
        }

        public void UpdateSystemPush(SystemPushMongo systemPush)
        {
            _customerPushRepository.Update(systemPush);
        }

        /// <summary>
        /// 获取指定类型和状态的推送消息列表
        /// </summary>
        /// <param name="type"> 00全部平台 01短信 02ios 03安卓</param>
        /// <param name="status">Status 01未推送 02已推送</param>
        /// <returns></returns>
        public List<SystemPushMongo> GetSystemPushList(string type, string status)
        {
            return _customerPushRepository.Collection.FindAll().Where(en => en.Type == type && en.Status == status).ToList();
        }

        /// <summary>
        /// 获取指定类型和状态的推送消息列表
        /// </summary>
        /// <param name="status">Status 01未推送 02已推送</param>
        /// <returns></returns>
        public List<SystemPushMongo> GetSystemPushList(string status)
        {
            return _customerPushRepository.Collection.FindAll().Where(en => en.Status == status).ToList();
        }
    }
}
