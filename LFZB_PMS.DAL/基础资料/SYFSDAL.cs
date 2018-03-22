using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class SYFSDAL
    {
        DB.MySqlDB mySql;
        public SYFSDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetSYType()
        {
            string sql = string.Format("select * from base_sytype");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetMRWZ()
        {
            string sql = string.Format("select * from base_mrwz");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetList()
        {
            string sql = string.Format("select * from v_syfs");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(SYFSClass syfs, string userCode)
        {
            string sql = string.Format(@"insert into base_syfs (syfsname,state,usercode,date,sytypecode,mrwzcode,jjf,jtc,remark) values 
                ('{0}',{1},'{2}','{3}',{4},{5},{6},{7},'{8}')",
                syfs.SYFSName, syfs.State, userCode, DateTime.Now.ToString(), syfs.SYTypeCode, syfs.MRWZCode, syfs.JJF, syfs.JTC, syfs.Remark);
            mySql.Run(sql);
        }
        public void UpdateData(SYFSClass syfs, string userCode)
        {
            string sql = string.Format(@"update base_syfs set syfsname='{0}',sytypecode={5},mrwzcode={6},jjf={7},jtc={8},remark='{9}',state={1},usercode='{2}',date='{3}' where syfscode='{4}'",
                   syfs.SYFSName, syfs.State, userCode, DateTime.Now.ToString(), syfs.SYFSCode, syfs.SYTypeCode, syfs.MRWZCode, syfs.JJF, syfs.JTC, syfs.Remark);
            mySql.Run(sql);
        }
        public void DeleteData(string code)
        {
            string sql = string.Format(@"update base_syfs set del=1 where syfscode='{0}'", code);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_syfs where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 收银方式
        public class SYFSClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 编号
            /// </summary>
            public string SYFSCode { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string SYFSName { get { return syfsName; } set { syfsName = value; OnPropertyChanged(new PropertyChangedEventArgs("SYFSName")); } }
            private string syfsName;
            /// <summary>
            /// 收银类型
            /// </summary>
            public int SYTypeCode { get { return syTypeCode; } set { syTypeCode = value; OnPropertyChanged(new PropertyChangedEventArgs("SYTypeCode")); } }
            private int syTypeCode;
            public string SYTypeName { get { return syTypeName; } set { syTypeName = value; OnPropertyChanged(new PropertyChangedEventArgs("SYTypeName")); } }
            private string syTypeName;
            /// <summary>
            /// 默认位置
            /// </summary>
            public int MRWZCode { get { return mrwzCode; } set { mrwzCode = value; OnPropertyChanged(new PropertyChangedEventArgs("MRWZCode")); } }
            private int mrwzCode;
            public string MRWZName { get { return mrwzName; } set { mrwzName = value; OnPropertyChanged(new PropertyChangedEventArgs("MRWZName")); } }
            private string mrwzName;
            /// <summary>
            /// 是否减积分
            /// </summary>
            public int JJF { get { return jjf; } set { jjf = value; OnPropertyChanged(new PropertyChangedEventArgs("JJF")); } }
            private int jjf;
            /// <summary>
            /// 是否减提成
            /// </summary>
            public int JTC { get { return jtc; } set { jtc = value; OnPropertyChanged(new PropertyChangedEventArgs("JTC")); } }
            private int jtc;
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
