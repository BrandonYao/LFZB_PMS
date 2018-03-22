using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class XSXTSXDAL
    {
        DB.MySqlDB mySql;
        public XSXTSXDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_xsxtsx");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(XSXTSXClass xsxt, string userCode)
        {
            string sql = string.Format(@"insert into base_xsxtsx (xsxtsxname,typename,state,usercode,date,isdefault) values 
                ('{0}','{1}',{2},'{3}','{4}',{5})",
                xsxt.XSXTSXName, xsxt.TypeName, xsxt.State, userCode, DateTime.Now.ToString(), xsxt.IsDefault);
            mySql.Run(sql);
        }
        public void UpdateData(XSXTSXClass xsxt, string userCode)
        {
            string sql = string.Format(@"update base_xsxtsx set xsxtsxname='{0}',state={1},usercode='{2}',date='{3}',isdefault={5} where xsxtsxcode='{4}'",
                   xsxt.XSXTSXName, xsxt.State, userCode, DateTime.Now.ToString(), xsxt.XSXTSXCode, xsxt.IsDefault);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_xsxtsx set del=1 where xsxtsxcode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_xsxtsx where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 销售销退属性
        public class XSXTSXClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 属性编号
            /// </summary>
            public string XSXTSXCode { get; set; }
            /// <summary>
            /// 属性名称
            /// </summary>
            public string XSXTSXName { get { return xsxtsxName; } set { xsxtsxName = value; OnPropertyChanged(new PropertyChangedEventArgs("XSXTSXName")); } }

            public int IsDefault { get { return isdefault; } set { isdefault = value; OnPropertyChanged(new PropertyChangedEventArgs("IsDefault")); } }
            private int isdefault;
            private string xsxtsxName;
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
