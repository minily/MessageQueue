using System;

namespace Zhongmubao.Push.Model
{
    /// <summary>
	/// CustomerJPush:实体类
	/// </summary>
    public class CustomerJPush
    {
        #region Model

        /// <summary>
        /// auto_increment
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string RegId { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Platform { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Created { set; get; }

        #endregion Model
    }
}
