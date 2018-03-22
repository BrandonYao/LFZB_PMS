using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class BSMCDAL
    {
        DB.MySqlDB mySql;
        public BSMCDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_bsmc");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(BSMCClass bsmc, string userCode)
        {
            string sql = string.Format(@"insert into base_bsmc (bsmcname,state,usercode,date) values 
                ('{0}',{1},'{2}','{3}')",
                bsmc.BSMCName, bsmc.State, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(BSMCClass bsmc, string userCode)
        {
            string sql = string.Format(@"update base_bsmc set bsmcname='{0}',state={1},usercode='{2}',date='{3}' where bsmccode='{4}'",
                   bsmc.BSMCName, bsmc.State, userCode, DateTime.Now.ToString(), bsmc.BSMCCode);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_bsmc set del=1 where bsmccode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_bsmc where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 宝石名称
        public class BSMCClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 编号
            /// </summary>
            public string BSMCCode { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string BSMCName { get { return bsmcName; } set { bsmcName = value; OnPropertyChanged(new PropertyChangedEventArgs("BSMCName")); } }
            private string bsmcName;
            public int State { get { return state; } set { state = value; OnPropertyChanged(new PropertyChangedEventArgs("State")); } }
            private int state;
            /// <summary>
            /// 最后修改人账号
            /// </summary>
            public string UserCode { get; set; }
            /// <summary>
            /// 最后修改人名称
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 最后修改日期
            /// </summary>
            public string Date { get; set; }
            /// <summary>
            /// 是否有修改
            /// </summary>
            public bool IsDirty { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, e);
            }
        }
        #endregion
    }
}
