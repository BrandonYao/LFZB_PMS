using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class ConfigDAL
    {
        DB.MySqlDB mySql;
        public ConfigDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetConfig()
        {
            DataSet ds = mySql.DS_Procedure("p_config", null);
            return ds.Tables[0];
        }
    }
}
