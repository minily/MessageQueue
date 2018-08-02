using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Zhongmubao.Push.Model;

namespace Zhongmubao.Push.DAL
{
    /// <summary>
    /// 数据访问类:Customer
    /// </summary>
    public class CustomerService
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Customer");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Customer(");
            strSql.Append("Account,Password,Sign,NickName,Name,Phone,Email,OpenId,CardType,CardNo,Photo,ReferenceId,IsGrantLibrary,Count,Platform,RegisterIP,RegisterAddredss,Deleted,Created,Modified,RedeemPassword,EnabledFingerprint,HadaCount,IsAutoRedeem,IsSetPassword)");
            strSql.Append(" values (");
            strSql.Append("@Account,@Password,@Sign,@NickName,@Name,@Phone,@Email,@OpenId,@CardType,@CardNo,@Photo,@ReferenceId,@IsGrantLibrary,@Count,@Platform,@RegisterIP,@RegisterAddredss,@Deleted,@Created,@Modified,@RedeemPassword,@EnabledFingerprint,@HadaCount,@IsAutoRedeem,@IsSetPassword)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Account", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Password", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Sign", MySqlDbType.VarChar,50),
                    new MySqlParameter("@NickName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Phone", MySqlDbType.VarChar,11),
                    new MySqlParameter("@Email", MySqlDbType.VarChar,100),
                    new MySqlParameter("@OpenId", MySqlDbType.VarChar,200),
                    new MySqlParameter("@CardType", MySqlDbType.VarChar,2),
                    new MySqlParameter("@CardNo", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Photo", MySqlDbType.VarChar,500),
                    new MySqlParameter("@ReferenceId", MySqlDbType.Int32,11),
                    new MySqlParameter("@IsGrantLibrary", MySqlDbType.Bit),
                    new MySqlParameter("@Count", MySqlDbType.Int32,11),
                    new MySqlParameter("@Platform", MySqlDbType.VarChar,50),
                    new MySqlParameter("@RegisterIP", MySqlDbType.VarChar,20),
                    new MySqlParameter("@RegisterAddredss", MySqlDbType.VarChar,20),
                    new MySqlParameter("@Deleted", MySqlDbType.Bit),
                    new MySqlParameter("@Created", MySqlDbType.DateTime),
                    new MySqlParameter("@Modified", MySqlDbType.DateTime),
                    new MySqlParameter("@RedeemPassword", MySqlDbType.VarChar,200),
                    new MySqlParameter("@EnabledFingerprint", MySqlDbType.Bit),
                    new MySqlParameter("@HadaCount", MySqlDbType.Int32,11),
                    new MySqlParameter("@IsAutoRedeem", MySqlDbType.Bit),
                    new MySqlParameter("@IsSetPassword", MySqlDbType.Bit)};
            parameters[0].Value = model.Account;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Sign;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.OpenId;
            parameters[8].Value = model.CardType;
            parameters[9].Value = model.CardNo;
            parameters[10].Value = model.Photo;
            parameters[11].Value = model.ReferenceId;
            parameters[12].Value = model.IsGrantLibrary;
            parameters[13].Value = model.Count;
            parameters[14].Value = model.Platform;
            parameters[15].Value = model.RegisterIP;
            parameters[16].Value = model.RegisterAddredss;
            parameters[17].Value = model.Deleted;
            parameters[18].Value = model.Created;
            parameters[19].Value = model.Modified;
            parameters[20].Value = model.RedeemPassword;
            parameters[21].Value = model.EnabledFingerprint;
            parameters[22].Value = model.HadaCount;
            parameters[23].Value = model.IsAutoRedeem;
            parameters[24].Value = model.IsSetPassword;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Customer set ");
            strSql.Append("Account=@Account,");
            strSql.Append("Password=@Password,");
            strSql.Append("Sign=@Sign,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Name=@Name,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("OpenId=@OpenId,");
            strSql.Append("CardType=@CardType,");
            strSql.Append("CardNo=@CardNo,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("ReferenceId=@ReferenceId,");
            strSql.Append("IsGrantLibrary=@IsGrantLibrary,");
            strSql.Append("Count=@Count,");
            strSql.Append("Platform=@Platform,");
            strSql.Append("RegisterIP=@RegisterIP,");
            strSql.Append("RegisterAddredss=@RegisterAddredss,");
            strSql.Append("Deleted=@Deleted,");
            strSql.Append("Created=@Created,");
            strSql.Append("Modified=@Modified,");
            strSql.Append("RedeemPassword=@RedeemPassword,");
            strSql.Append("EnabledFingerprint=@EnabledFingerprint,");
            strSql.Append("HadaCount=@HadaCount,");
            strSql.Append("IsAutoRedeem=@IsAutoRedeem,");
            strSql.Append("IsSetPassword=@IsSetPassword");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Account", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Password", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Sign", MySqlDbType.VarChar,50),
                    new MySqlParameter("@NickName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Phone", MySqlDbType.VarChar,11),
                    new MySqlParameter("@Email", MySqlDbType.VarChar,100),
                    new MySqlParameter("@OpenId", MySqlDbType.VarChar,200),
                    new MySqlParameter("@CardType", MySqlDbType.VarChar,2),
                    new MySqlParameter("@CardNo", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Photo", MySqlDbType.VarChar,500),
                    new MySqlParameter("@ReferenceId", MySqlDbType.Int32,11),
                    new MySqlParameter("@IsGrantLibrary", MySqlDbType.Bit),
                    new MySqlParameter("@Count", MySqlDbType.Int32,11),
                    new MySqlParameter("@Platform", MySqlDbType.VarChar,50),
                    new MySqlParameter("@RegisterIP", MySqlDbType.VarChar,20),
                    new MySqlParameter("@RegisterAddredss", MySqlDbType.VarChar,20),
                    new MySqlParameter("@Deleted", MySqlDbType.Bit),
                    new MySqlParameter("@Created", MySqlDbType.DateTime),
                    new MySqlParameter("@Modified", MySqlDbType.DateTime),
                    new MySqlParameter("@RedeemPassword", MySqlDbType.VarChar,200),
                    new MySqlParameter("@EnabledFingerprint", MySqlDbType.Bit),
                    new MySqlParameter("@HadaCount", MySqlDbType.Int32,11),
                    new MySqlParameter("@IsAutoRedeem", MySqlDbType.Bit),
                    new MySqlParameter("@IsSetPassword", MySqlDbType.Bit),
                    new MySqlParameter("@Id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Account;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Sign;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.OpenId;
            parameters[8].Value = model.CardType;
            parameters[9].Value = model.CardNo;
            parameters[10].Value = model.Photo;
            parameters[11].Value = model.ReferenceId;
            parameters[12].Value = model.IsGrantLibrary;
            parameters[13].Value = model.Count;
            parameters[14].Value = model.Platform;
            parameters[15].Value = model.RegisterIP;
            parameters[16].Value = model.RegisterAddredss;
            parameters[17].Value = model.Deleted;
            parameters[18].Value = model.Created;
            parameters[19].Value = model.Modified;
            parameters[20].Value = model.RedeemPassword;
            parameters[21].Value = model.EnabledFingerprint;
            parameters[22].Value = model.HadaCount;
            parameters[23].Value = model.IsAutoRedeem;
            parameters[24].Value = model.IsSetPassword;
            parameters[25].Value = model.Id;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Customer ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Customer ");
            strSql.Append(" where Id in (" + idlist + ")  ");
            int rows = DbHelperMySql.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Customer GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Account,Password,Sign,NickName,Name,Phone,Email,OpenId,CardType,CardNo,Photo,ReferenceId,IsGrantLibrary,Count,Platform,RegisterIP,RegisterAddredss,Deleted,Created,Modified,RedeemPassword,EnabledFingerprint,HadaCount,IsAutoRedeem,IsSetPassword from Customer ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;
            
            DataSet ds = DbHelperMySql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Customer DataRowToModel(DataRow row)
        {
            Customer model = new Customer();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Account"] != null)
                {
                    model.Account = row["Account"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Sign"] != null)
                {
                    model.Sign = row["Sign"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["OpenId"] != null)
                {
                    model.OpenId = row["OpenId"].ToString();
                }
                if (row["CardType"] != null)
                {
                    model.CardType = row["CardType"].ToString();
                }
                if (row["CardNo"] != null)
                {
                    model.CardNo = row["CardNo"].ToString();
                }
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
                }
                if (row["ReferenceId"] != null && row["ReferenceId"].ToString() != "")
                {
                    model.ReferenceId = int.Parse(row["ReferenceId"].ToString());
                }
                if (row["IsGrantLibrary"] != null && row["IsGrantLibrary"].ToString() != "")
                {
                    if ((row["IsGrantLibrary"].ToString() == "1") || (row["IsGrantLibrary"].ToString().ToLower() == "true"))
                    {
                        model.IsGrantLibrary = true;
                    }
                    else
                    {
                        model.IsGrantLibrary = false;
                    }
                }
                if (row["Count"] != null && row["Count"].ToString() != "")
                {
                    model.Count = int.Parse(row["Count"].ToString());
                }
                if (row["Platform"] != null)
                {
                    model.Platform = row["Platform"].ToString();
                }
                if (row["RegisterIP"] != null)
                {
                    model.RegisterIP = row["RegisterIP"].ToString();
                }
                if (row["RegisterAddredss"] != null)
                {
                    model.RegisterAddredss = row["RegisterAddredss"].ToString();
                }
                if (row["Deleted"] != null && row["Deleted"].ToString() != "")
                {
                    if ((row["Deleted"].ToString() == "1") || (row["Deleted"].ToString().ToLower() == "true"))
                    {
                        model.Deleted = true;
                    }
                    else
                    {
                        model.Deleted = false;
                    }
                }
                if (row["Created"] != null && row["Created"].ToString() != "")
                {
                    model.Created = DateTime.Parse(row["Created"].ToString());
                }
                if (row["Modified"] != null && row["Modified"].ToString() != "")
                {
                    model.Modified = DateTime.Parse(row["Modified"].ToString());
                }
                if (row["RedeemPassword"] != null)
                {
                    model.RedeemPassword = row["RedeemPassword"].ToString();
                }
                if (row["EnabledFingerprint"] != null && row["EnabledFingerprint"].ToString() != "")
                {
                    if ((row["EnabledFingerprint"].ToString() == "1") || (row["EnabledFingerprint"].ToString().ToLower() == "true"))
                    {
                        model.EnabledFingerprint = true;
                    }
                    else
                    {
                        model.EnabledFingerprint = false;
                    }
                }
                if (row["HadaCount"] != null && row["HadaCount"].ToString() != "")
                {
                    model.HadaCount = int.Parse(row["HadaCount"].ToString());
                }
                if (row["IsAutoRedeem"] != null && row["IsAutoRedeem"].ToString() != "")
                {
                    if ((row["IsAutoRedeem"].ToString() == "1") || (row["IsAutoRedeem"].ToString().ToLower() == "true"))
                    {
                        model.IsAutoRedeem = true;
                    }
                    else
                    {
                        model.IsAutoRedeem = false;
                    }
                }
                if (row["IsSetPassword"] != null && row["IsSetPassword"].ToString() != "")
                {
                    if ((row["IsSetPassword"].ToString() == "1") || (row["IsSetPassword"].ToString().ToLower() == "true"))
                    {
                        model.IsSetPassword = true;
                    }
                    else
                    {
                        model.IsSetPassword = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Account,Password,Sign,NickName,Name,Phone,Email,OpenId,CardType,CardNo,Photo,ReferenceId,IsGrantLibrary,Count,Platform,RegisterIP,RegisterAddredss,Deleted,Created,Modified,RedeemPassword,EnabledFingerprint,HadaCount,IsAutoRedeem,IsSetPassword ");
            strSql.Append(" FROM Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySql.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySql.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Customer T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySql.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Customer";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySql.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}



