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
            MySqlConnection con = new MySqlConnection(ConnectionString);
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

        /// <summary>
        /// jon
        /// 连接服务器，返回数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataSet DS(string sql)
        {
            //打开连接
            MySqlConnection con = new MySqlConnection(ConnectionString);
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

        /// <summary>
        /// 执行增、删、改
        /// </summary>
        /// <param name="strSql"></param>
        public int ExecDataBySql(string strSql, params MySqlParameter[] param)
        {
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                //打开连接
                con.Open();
                //命令
                MySqlCommand com = new MySqlCommand(strSql, con);
                com.Parameters.AddRange(param);
                return com.ExecuteNonQuery();
            }
        }
    }
}
