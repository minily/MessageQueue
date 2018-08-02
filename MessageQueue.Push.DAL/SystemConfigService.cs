using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Zhongmubao.Push.Model;

namespace Zhongmubao.Push.DAL
{
    public class SystemConfigService
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SystemConfig");
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
        public bool Add(SystemConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SystemConfig(");
            strSql.Append("Category,Key,Value,Name,Deleted,Created,Modified)");
            strSql.Append(" values (");
            strSql.Append("@Category,@Key,@Value,@Name,@Deleted,@Created,@Modified)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Category", MySqlDbType.VarChar,2),
                    new MySqlParameter("@Key", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Value", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Deleted", MySqlDbType.Bit),
                    new MySqlParameter("@Created", MySqlDbType.DateTime),
                    new MySqlParameter("@Modified", MySqlDbType.DateTime)};
            parameters[0].Value = model.Category;
            parameters[1].Value = model.Key;
            parameters[2].Value = model.Value;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Deleted;
            parameters[5].Value = model.Created;
            parameters[6].Value = model.Modified;

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
        public bool Update(SystemConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SystemConfig set ");
            strSql.Append("Category=@Category,");
            strSql.Append("Key=@Key,");
            strSql.Append("Value=@Value,");
            strSql.Append("Name=@Name,");
            strSql.Append("Deleted=@Deleted,");
            strSql.Append("Created=@Created,");
            strSql.Append("Modified=@Modified");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Category", MySqlDbType.VarChar,2),
                    new MySqlParameter("@Key", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Value", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Deleted", MySqlDbType.Bit),
                    new MySqlParameter("@Created", MySqlDbType.DateTime),
                    new MySqlParameter("@Modified", MySqlDbType.DateTime),
                    new MySqlParameter("@Id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Category;
            parameters[1].Value = model.Key;
            parameters[2].Value = model.Value;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Deleted;
            parameters[5].Value = model.Created;
            parameters[6].Value = model.Modified;
            parameters[7].Value = model.Id;

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
            strSql.Append("delete from SystemConfig ");
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
            strSql.Append("delete from SystemConfig ");
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
        public SystemConfig GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Category,Key,Value,Name,Deleted,Created,Modified from SystemConfig ");
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
        public SystemConfig DataRowToModel(DataRow row)
        {
            SystemConfig model = new SystemConfig();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Category"] != null)
                {
                    model.Category = row["Category"].ToString();
                }
                if (row["Key"] != null)
                {
                    model.Key = row["Key"].ToString();
                }
                if (row["Value"] != null)
                {
                    model.Value = row["Value"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Category,Key,Value,Name,Deleted,Created,Modified ");
            strSql.Append(" FROM SystemConfig ");
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
            strSql.Append("select count(1) FROM SystemConfig ");
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
            strSql.Append(")AS Row, T.*  from SystemConfig T ");
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
			parameters[0].Value = "SystemConfig";
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SystemConfig GetModel(string key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Id,Category,`Key`,`Value`,`Name`,Deleted,Created,Modified FROM SystemConfig ");
            strSql.Append(" where `Key`=@Key");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Key", MySqlDbType.String)
            };
            parameters[0].Value = key;

            SystemConfig model = new SystemConfig();
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

        #endregion  ExtensionMethod
    }
}
