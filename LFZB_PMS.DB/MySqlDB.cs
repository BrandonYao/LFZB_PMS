using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DB
{
    public class MySqlDB
    {
        //连接字符串
        static string ConnectionString;

        public MySqlDB(string connStr)
        {
            ConnectionString = connStr;
        }

        /// <summary>
        /// jon
        /// 连接服务器，更新数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public bool Run(string sql)
        {
            //打开连接
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                //命令
                MySqlCommand com = new MySqlCommand(sql, con);
                int i = com.ExecuteNonQuery();
                if (i > 0)
                {
                    con.Close();//关闭连接 
                    return true;
                }
                else
                {
                    con.Close();//关闭连接 
                    return false;
                }
            }
        }

        /// <summary>
        /// jon
        /// 连接服务器，返回数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataSet DS(string sql)
        {
            //打开连接
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                //命令
                MySqlCommand com = new MySqlCommand(sql, con);
                //处理
                MySqlDataAdapter sd = new MySqlDataAdapter(com);
                //数据集
                DataSet ds = new DataSet();
                //填充
                sd.Fill(ds);
                con.Close();//关闭连接  
                return ds;
            }
        }

        public DataSet DS_Procedure(string procedureName, IDictionary<string, string> Parameters)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand mysqlcom = new MySqlCommand(procedureName, sqlConnection);
                mysqlcom.CommandType = CommandType.StoredProcedure;//设置调用的类型为存储过程   
                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                if (Parameters != null)
                {
                    foreach (string k in Parameters.Keys)
                    {
                        mysqlcom.Parameters.Add(k, MySqlDbType.VarChar, 20).Value = Parameters[k];
                    }
                }
                sqlConnection.Open();//打开数据库连接 
                adapter.SelectCommand = mysqlcom;
                mysqlcom.ExecuteNonQuery();
                adapter.Fill(ds, procedureName);
                return ds;
            }
        }
    }
}
