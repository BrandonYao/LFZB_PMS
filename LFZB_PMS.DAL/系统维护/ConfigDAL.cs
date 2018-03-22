using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public class XTSZ : INotifyPropertyChanged
        {
            /// <summary>
            /// 默认显示单据天数
            /// </summary>
            public string DaysOfOrder { get { return daysOfOrder; } set { daysOfOrder = value; OnPropertyChanged(new PropertyChangedEventArgs("DaysOfOrder")); } }
            private string daysOfOrder;
            /// <summary>
            /// 单据明细最多行数
            /// </summary>
            public string MaxRowsOfOrder { get { return maxRowsOfOrder; } set { maxRowsOfOrder = value; OnPropertyChanged(new PropertyChangedEventArgs("MaxRowsOfOrder")); } }
            private string maxRowsOfOrder;

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, e);
            }
        }
    }
}
