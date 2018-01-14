using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class SSMCDAL
    {
        DB.MySqlDB mySql;
        public SSMCDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_ssmc");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(SSMCClass cls, string userCode)
        {
            string sql = string.Format(@"insert into base_ssmc (ssmcname,state,usercode,date) values 
                ('{0}',{1},'{2}','{3}')",
                cls.SSMCName, cls.State, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(SSMCClass cls, string userCode)
        {
            string sql = string.Format(@"update base_ssmc set ssmcname='{0}',state={1},usercode='{2}',date='{3}' where ssmccode='{4}'",
                   cls.SSMCName, cls.State, userCode, DateTime.Now.ToString(), cls.SSMCCode);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_ssmc set del=1 where bsmccode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_ssmc where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 首饰名称
        public class SSMCClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 编号
            /// </summary>
            public string SSMCCode { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string SSMCName { get { return ssmcName; } set { ssmcName = value; OnPropertyChanged(new PropertyChangedEventArgs("SSMCName")); } }
            private string ssmcName;
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
