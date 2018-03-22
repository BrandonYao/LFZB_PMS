using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class FXGZDAL
    {
        DB.MySqlDB mySql;
        public FXGZDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetSYType()
        {
            string sql = string.Format("select * from base_sytype");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        public DataTable GetList()
        {
            string sql = string.Format("select * from v_fxgz");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(FXGZClass fxgz, string userCode)
        {
            string sql = string.Format(@"insert into base_fxgz (fxgzname,state,usercode,date,fxscode) values 
                ('{0}',{1},'{2}','{3}',{4})",
                fxgz.FXGZName, fxgz.State, userCode, DateTime.Now.ToString(), fxgz.FXSCode);
            mySql.Run(sql);
        }
        public void UpdateData(FXGZClass fxgz, string userCode)
        {
            string sql = string.Format(@"update base_fxgz set fxgzname='{0}',fxscode={5},state={1},usercode='{2}',date='{3}' where fxgzcode='{4}'",
                   fxgz.FXGZName, fxgz.State, userCode, DateTime.Now.ToString(), fxgz.FXGZCode, fxgz.FXSCode);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_fxgz set del=1 where fxgzcode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_fxgz where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 分销柜组
        public class FXGZClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 编号
            /// </summary>
            public string FXGZCode { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string FXGZName { get { return fxgzName; } set { fxgzName = value; OnPropertyChanged(new PropertyChangedEventArgs("FXGZName")); } }
            private string fxgzName;
            /// <summary>
            /// 所属分销商
            /// </summary>
            public int FXSCode { get { return fxsCode; } set { fxsCode = value; OnPropertyChanged(new PropertyChangedEventArgs("FXSCode")); } }
            private int fxsCode;
            public string FXSName { get { return fxsName; } set { fxsName = value; OnPropertyChanged(new PropertyChangedEventArgs("FXSName")); } }
            private string fxsName;
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
