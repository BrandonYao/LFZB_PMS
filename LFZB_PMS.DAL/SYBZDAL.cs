using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class SYBZDAL
    {
        DB.MySqlDB mySql;
        public SYBZDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_sybz");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(SYBZClass sybz, string userCode)
        {
            string sql = string.Format(@"insert into base_sybz (sybzname,state,usercode,date,remark) values 
                ('{0}',{1},'{2}','{3}','{4}')",
                sybz.SYBZName, sybz.State, userCode, DateTime.Now.ToString(), sybz.Remark);
            mySql.Run(sql);
        }
        public void UpdateData(SYBZClass sybz, string userCode)
        {
            string sql = string.Format(@"update base_sybz set sybzname='{0}',remark='{5}',state={1},usercode='{2}',date='{3}' where sybzcode='{4}'",
                   sybz.SYBZName, sybz.State, userCode, DateTime.Now.ToString(), sybz.SYBZCode, sybz.Remark);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_sybz set del=1 where sybzcode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_sybz where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 收银班组
        public class SYBZClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 编号
            /// </summary>
            public string SYBZCode { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string SYBZName { get { return sybzName; } set { sybzName = value; OnPropertyChanged(new PropertyChangedEventArgs("SYBZName")); } }
            private string sybzName;
            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get { return remark; } set { remark = value; OnPropertyChanged(new PropertyChangedEventArgs("Remark")); } }
            private string remark;
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
