using System;

namespace Zhongmubao.Push.Model
{
    /// <summary>
	/// SystemConfig:实体类
	/// </summary>
    public class SystemConfig
    {
        #region Model

        /// <summary>
        /// auto_increment
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Category { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Key { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public bool Deleted { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Created { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Modified { set; get; }

        #endregion Model

    }
}
