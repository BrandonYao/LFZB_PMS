using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class FDDAL
    {
        DB.MySqlDB mySql;
        public FDDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        /// <summary>
        /// 查询可用分店列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetFDInfo()
        {
            string sql = "select * from base_fd where fdstate=1";
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public bool FDIsExists(string fdcode)
        {
            bool result = false;
            string sql = string.Format("select * from sys_fd where fdcode='{0}'", fdcode);
            DataTable dt = mySql.DS(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
                result = true;
            return result;
        }
        public bool InsertFD(string fdcode,  string fdName)
        {
            string sql = string.Format("insert into sys_fd (fdcode,fdname) values ('{0}','{1}')", fdcode, fdName);
            return mySql.Run(sql); ;
        }
        public bool UpdateFD(string fdcode, string fdName)
        {
            string sql = string.Format("update sys_fd set fdname='{1}' where fdcode='{0}'", fdcode, fdName);
            return mySql.Run(sql); ;
        }
    }
}
