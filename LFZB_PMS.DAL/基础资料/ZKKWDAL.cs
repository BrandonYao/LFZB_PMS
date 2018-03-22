using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class ZKKWDAL
    {
        DB.MySqlDB mySql;
        public ZKKWDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_zkkw");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(ZKKWClass zkkw, string userCode)
        {
            string sql = string.Format(@"insert into base_zkkw (zkkwname,state,usercode,date) values 
                ('{0}',{1},'{2}','{3}')",
                zkkw.ZKKWName, zkkw.State, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(ZKKWClass zkkw, string userCode)
        {
            string sql = string.Format(@"update base_zkkw set zkkwname='{0}',state={1},usercode='{2}',date='{3}' where zkkwcode='{4}'",
                   zkkw.ZKKWName, zkkw.State, userCode, DateTime.Now.ToString(), zkkw.ZKKWCode);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_zkkw set del=1 where zkkwcode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_zkkw where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 总库库位
        public class ZKKWClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 编号
            /// </summary>
            public string ZKKWCode { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string ZKKWName { get { return zkkwName; } set { zkkwName = value; OnPropertyChanged(new PropertyChangedEventArgs("ZKKWName")); } }
            private string zkkwName;
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
