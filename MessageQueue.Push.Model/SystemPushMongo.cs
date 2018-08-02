using System;
using MongoRepository;

namespace Zhongmubao.Push.Model
{
    /// <summary>
    /// SystemPush表，CustomerId Title Content Type Status CreateTime 
    /// Type  00全部平台 01短信 02ios 03安卓 04微信
    /// Status 01未推送 02已推送
    /// </summary>
    public class SystemPushMongo : Entity
    {
        /// <summary>
        /// 客户主键ID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 平台类型  00全部平台 01短信 02ios 03安卓 04微信
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 消息状态 01未推送 02已推送
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
