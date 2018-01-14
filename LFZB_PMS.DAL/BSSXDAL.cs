using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class BSSXDAL
    {
        DB.MySqlDB mySql;
        public BSSXDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_bssx");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(BSSXClass bssx, string userCode)
        {
            string sql = string.Format(@"insert into base_bssx (bssxname,typename,state,usercode,date) values 
                ('{0}','{1}',{2},'{3}','{4}')",
                bssx.BSSXName, bssx.TypeName, bssx.State, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(BSSXClass bssx, string userCode)
        {
            string sql = string.Format(@"update base_bssx set bssxname='{0}',state={1},usercode='{2}',date='{3}' where bssxcode='{4}'",
                   bssx.BSSXName, bssx.State, userCode, DateTime.Now.ToString(), bssx.BSSXCode);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_bssx set del=1 where bssxcode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_bssx where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 宝石属性
        public class BSSXClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 属性编号
            /// </summary>
            public string BSSXCode { get; set; }
            /// <summary>
            /// 属性名称
            /// </summary>
            public string BSSXName { get { return bssxName; } set { bssxName = value; OnPropertyChanged(new PropertyChangedEventArgs("BSSXName")); } }
            private string bssxName;
            public int State { get { return state; } set { state = value; OnPropertyChanged(new PropertyChangedEventArgs("State")); } }
            private int state;
            /// <summary>
            /// 分组名称
            /// </summary>
            public string TypeName { get; set; }
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
