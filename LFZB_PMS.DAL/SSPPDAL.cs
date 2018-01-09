using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class SSPPDAL
    {
        DB.MySqlDB mySql;
        public SSPPDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_sspp");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(SSPPClass sspp, string userCode)
        {
            string sql = string.Format(@"insert into base_sspp (ssppname,state,usercode,date) values 
                ('{0}',{1},'{2}','{3}')",
                sspp.SSPPName, sspp.State, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(SSPPClass sspp, string userCode)
        {
            string sql = string.Format(@"update base_sspp set ssppname='{0}',state={1},usercode='{2}',date='{3}' where ssppcode='{4}'",
                   sspp.SSPPName, sspp.State, userCode, DateTime.Now.ToString(), sspp.SSPPCode);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_sspp set del=1 where ssppcode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_sspp where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 首饰品牌
        public class SSPPClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 首饰品牌编号
            /// </summary>
            public string SSPPCode { get; set; }
            /// <summary>
            /// 首饰品牌名称
            /// </summary>
            public string SSPPName { get { return ssppName; } set { ssppName = value; OnPropertyChanged(new PropertyChangedEventArgs("SSPPName")); } }
            private string ssppName;
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
