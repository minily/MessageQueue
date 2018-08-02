using System;

namespace Zhongmubao.Push.Model
{
    /// <summary>
    /// Customer:实体类
    /// </summary>
    public class Customer
    {
        #region Model

        /// <summary>
        /// auto_increment
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Account { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Sign { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string NickName { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string OpenId { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string CardType { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string CardNo { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Photo { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int? ReferenceId { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGrantLibrary { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int Count { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Platform { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string RegisterIP { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string RegisterAddredss { set; get; }

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

        /// <summary>
        /// 
        /// </summary>
        public string RedeemPassword { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public bool EnabledFingerprint { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int HadaCount { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAutoRedeem { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSetPassword { set; get; }

        #endregion Model

    }
}
