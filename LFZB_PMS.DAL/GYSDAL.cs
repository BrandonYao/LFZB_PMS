using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class GYSDAL
    {
        DB.MySqlDB mySql;
        public GYSDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetType()
        {
            string sql = string.Format("select * from v_gysz_zycp");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetGYSList(string gyszCode, string zycpCode)
        {
            string sql = string.Format("select * from v_gys where gyszcode='{0}' and zycpcode='{1}'", gyszCode, zycpCode);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
    }
}
