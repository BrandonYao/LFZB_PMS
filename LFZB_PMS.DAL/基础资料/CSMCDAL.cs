using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class CSMCDAL
    {
        DB.MySqlDB mySql;
        public CSMCDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_csmc");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(CSMCClass obj, string userCode)
        {
            string sql = string.Format(@"insert into base_csmc (csmcname,typename,state,usercode,date) values 
                ('{0}','{1}',{2},'{3}','{4}')",
                obj.CSMCName, obj.TypeName, obj.State, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(CSMCClass obj, string userCode)
        {
            string sql = string.Format(@"update base_csmc set csmcname='{0}',state={1},usercode='{2}',date='{3}' where csmccode='{4}'",
                   obj.CSMCName, obj.State, userCode, DateTime.Now.ToString(), obj.CSMCCode);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_csmc set del=1 where csmccode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_csmc where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 成色名称
        public class CSMCClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 成色编号
            /// </summary>
            public string CSMCCode { get; set; }
            /// <summary>
            /// 成色名称
            /// </summary>
            public string CSMCName { get { return csmcName; } set { csmcName = value; OnPropertyChanged(new PropertyChangedEventArgs("CSMCName")); } }
            private string csmcName;
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
