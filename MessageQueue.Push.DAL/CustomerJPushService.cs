using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Zhongmubao.Push.Model;

namespace Zhongmubao.Push.DAL
{
    public class CustomerJPushService
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CustomerJPush");
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
        public bool Add(CustomerJPush model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CustomerJPush(");
            strSql.Append("CustomerId,RegId,Platform,Created)");
            strSql.Append(" values (");
            strSql.Append("@CustomerId,@RegId,@Platform,@Created)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@CustomerId", MySqlDbType.Int32,11),
                    new MySqlParameter("@RegId", MySqlDbType.VarChar,200),
                    new MySqlParameter("@Platform", MySqlDbType.VarChar,2),
                    new MySqlParameter("@Created", MySqlDbType.DateTime)};
            parameters[0].Value = model.CustomerId;
            parameters[1].Value = model.RegId;
            parameters[2].Value = model.Platform;
            parameters[3].Value = model.Created;

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
        public bool Update(CustomerJPush model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CustomerJPush set ");
            strSql.Append("CustomerId=@CustomerId,");
            strSql.Append("RegId=@RegId,");
            strSql.Append("Platform=@Platform,");
            strSql.Append("Created=@Created");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@CustomerId", MySqlDbType.Int32,11),
                    new MySqlParameter("@RegId", MySqlDbType.VarChar,200),
                    new MySqlParameter("@Platform", MySqlDbType.VarChar,2),
                    new MySqlParameter("@Created", MySqlDbType.DateTime),
                    new MySqlParameter("@Id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.CustomerId;
            parameters[1].Value = model.RegId;
            parameters[2].Value = model.Platform;
            parameters[3].Value = model.Created;
            parameters[4].Value = model.Id;

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
            strSql.Append("delete from CustomerJPush ");
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
            strSql.Append("delete from CustomerJPush ");
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
        public CustomerJPush GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,CustomerId,RegId,Platform,Created from CustomerJPush ");
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
        public CustomerJPush DataRowToModel(DataRow row)
        {
            CustomerJPush model = new CustomerJPush();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["CustomerId"] != null && row["CustomerId"].ToString() != "")
                {
                    model.CustomerId = int.Parse(row["CustomerId"].ToString());
                }
                if (row["RegId"] != null)
                {
                    model.RegId = row["RegId"].ToString();
                }
                if (row["Platform"] != null)
                {
                    model.Platform = row["Platform"].ToString();
                }
                if (row["Created"] != null && row["Created"].ToString() != "")
                {
                    model.Created = DateTime.Parse(row["Created"].ToString());
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
            strSql.Append("select Id,CustomerId,RegId,Platform,Created ");
            strSql.Append(" FROM CustomerJPush ");
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
            strSql.Append("select count(1) FROM CustomerJPush ");
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
            strSql.Append(")AS Row, T.*  from CustomerJPush T ");
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
			parameters[0].Value = "CustomerJPush";
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
        public List<CustomerJPush> GetListByCusId(int customerId)
        {
            List<CustomerJPush> cjpList = null;
            string sql = string.Format("SELECT * FROM `CustomerJPush` where CustomerId={0};", customerId);
            MySqlDataReader reader = null;
            try
            {
                reader = DbHelperMySql.ExecuteReader(sql);
                if (reader.HasRows)
                {
                    cjpList = new List<CustomerJPush>();
                    while (reader.Read())
                    {
                        CustomerJPush model = new CustomerJPush();
                        if (reader["Id"] != null && reader["Id"].ToString() != "")
                        {
                            model.Id = int.Parse(reader["Id"].ToString());
                        }
                        if (reader["CustomerId"] != null && reader["CustomerId"].ToString() != "")
                        {
                            model.CustomerId = int.Parse(reader["CustomerId"].ToString());
                        }
                        if (reader["RegId"] != null)
                        {
                            model.RegId = reader["RegId"].ToString();
                        }
                        if (reader["Platform"] != null)
                        {
                            model.Platform = reader["Platform"].ToString();
                        }
                        if (reader["Created"] != null && reader["Created"].ToString() != "")
                        {
                            model.Created = DateTime.Parse(reader["Created"].ToString());
                        }
                        cjpList.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (null != reader)
                {
                    // 关闭reader对象，将自动关闭connection
                    reader.Close();
                }
            }
            return cjpList;
        }
        #endregion  ExtensionMethod
    }
}
