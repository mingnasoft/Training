using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace System.Data.Entity
{

    public static class DatabaseExtensions
    {
        /// <summary>
        /// 扩展方法调用存储过程
        /// </summary>
        /// <param name="db">Database</param>
        /// <param name="StoredProcedureName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static DataSet SqlQueryForStoredProcedure(this Database db, string StoredProcedureName, params SqlParameter[] parameters)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = db.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = StoredProcedureName;

            if (parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            conn.Dispose();
            return ds;
        }
    }
}
