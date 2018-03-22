using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class UserDAL
    {
        DB.MySqlDB mySql;
        public UserDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetUser(string fxsCode)
        {
            string sql = string.Format("select * from sys_user where fxscode={0} and userstate=1", fxsCode);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public bool Login(string fxsCode, string userCode, string pw)
        {
            string sql = string.Format("select * from sys_user where usercode='{0}' and password='{1}'", userCode, pw);
            if (userCode != "admin") sql += string.Format(" and fxscode={0}", fxsCode);
            DataSet ds = mySql.DS(sql);
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else return false;
        }

        public Dictionary<string, bool> GetMenu(string fxsCode, string userCode)
        {
            Dictionary<string, bool> cmdState = new Dictionary<string, bool>();
            string sql = string.Format("select * from v_user_menu where fxscode={0} and usercode='{1}'", fxsCode, userCode);
            if (userCode == "admin") sql = "select * from sys_menu";
            DataSet ds = mySql.DS(sql);
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string cmdName = row["cmdname"].ToString().Trim();
                    if (!string.IsNullOrEmpty(cmdName))
                        cmdState.Add(cmdName, true);
                }
            }
            return cmdState;
        }
    }
}
