using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class FXSDAL
    {
        DB.MySqlDB mySql;
        public FXSDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetFXSType()
        {
            string sql = string.Format("select * from v_fxsz_fxlx");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetFXSInfo()
        {
            string sql = "select * from sys_fxs";
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetFXSList(string fxszCode, string fxlxCode)
        {
            string sql = string.Format("select * from v_fxs where fxszcode='{0}' and fxlxcode='{1}'", fxszCode, fxlxCode);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetFXSZ()
        {
            string sql = string.Format("select * from base_fxsz");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetFXLX()
        {
            string sql = string.Format("select * from base_fxlx");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(FXSClass fxs, string userCode)
        {
            string sql = string.Format(@"insert into sys_gys (fxsname,fxszcode,fxlxcode,lxdz,lxr,yzbm,lxdh,czhm,email,sjhm,khyh,yhzh,bz,gysstate,usercode,date) values 
                ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},'{14}','{15}')",
                fxs.FXSName, fxs.FXSZCode, fxs.FXLXCode, fxs.LXDZ, fxs.LXR, fxs.YZBM, fxs.LXDH, fxs.CZHM, fxs.Email, fxs.SJHM, fxs.KHYH, fxs.YHZH, fxs.BZ, fxs.GYSState, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(FXSClass fxs, string userCode)
        {
            string sql = string.Format(@"update sys_fxs set fxsname='{0}',fxszcode='{1}',fxlxcode='{2}',lxdz='{3}',lxr='{4}',yzbm='{5}',lxdh='{6}',czhm='{7}',
email='{8}',sjhm='{9}',khyh='{10}',yhzh='{11}',bz='{12}',gysstate={13},usercode='{14}',date='{15}' where fxscode='{16}'",
                   fxs.FXSName, fxs.FXSZCode, fxs.FXLXCode, fxs.LXDZ, fxs.LXR, fxs.YZBM, fxs.LXDH, fxs.CZHM, fxs.Email, fxs.SJHM, fxs.KHYH, fxs.YHZH, fxs.BZ, fxs.GYSState, userCode, DateTime.Now.ToString(), fxs.FXSCode);
            mySql.Run(sql);
        }
        public void DeleteData(string fxsCode)
        {
            string sql = string.Format(@"delete from sys_fxs where fxscode='{0}'", fxsCode);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_fxs where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 分销商
        public class FXSClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 分销商编号
            /// </summary>
            public string FXSCode { get; set; }
            /// <summary>
            /// 分销商名称
            /// </summary>
            public string FXSName { get { return fxsName; } set { fxsName = value; OnPropertyChanged(new PropertyChangedEventArgs("FXSName")); } }
            private string fxsName;
            /// <summary>
            /// 分销商分组编号
            /// </summary>
            public string FXSZCode { get { return fxszCode; } set { fxszCode = value; OnPropertyChanged(new PropertyChangedEventArgs("FXSZCode")); } }
            private string fxszCode;
            /// <summary>
            /// 分销商分组名称
            /// </summary>
            public string FXSZName { get { return fxszName; } set { fxszName = value; OnPropertyChanged(new PropertyChangedEventArgs("FXSZName")); } }
            private string fxszName;
            /// <summary>
            /// 分销类型编号
            /// </summary>
            public string FXLXCode { get { return fxlxCode; } set { fxlxCode = value; OnPropertyChanged(new PropertyChangedEventArgs("FXLXCode")); } }
            private string fxlxCode;
            /// <summary>
            /// 分销类型名称
            /// </summary>
            public string FXLXName { get { return fxlxName; } set { fxlxName = value; OnPropertyChanged(new PropertyChangedEventArgs("FXLXName")); } }
            private string fxlxName;
            /// <summary>
            /// 联系地址
            /// </summary>
            public string LXDZ { get { return lxdz; } set { lxdz = value; OnPropertyChanged(new PropertyChangedEventArgs("LXDZ")); } }
            private string lxdz;
            /// <summary>
            /// 联系人
            /// </summary>
            public string LXR { get { return lxr; } set { lxr = value; OnPropertyChanged(new PropertyChangedEventArgs("LXR")); } }
            private string lxr;
            /// <summary>
            /// 邮政编码
            /// </summary>
            public string YZBM { get { return yzbm; } set { yzbm = value; OnPropertyChanged(new PropertyChangedEventArgs("YZBM")); } }
            private string yzbm;
            /// <summary>
            /// 联系电话
            /// </summary>
            public string LXDH { get { return lxdh; } set { lxdh = value; OnPropertyChanged(new PropertyChangedEventArgs("LXDH")); } }
            private string lxdh;
            /// <summary>
            /// 传真号码
            /// </summary>
            public string CZHM { get { return czhm; } set { czhm = value; OnPropertyChanged(new PropertyChangedEventArgs("CZHM")); } }
            private string czhm;
            /// <summary>
            /// 电子邮箱
            /// </summary>
            public string Email { get { return email; } set { email = value; OnPropertyChanged(new PropertyChangedEventArgs("Email")); } }
            private string email;
            /// <summary>
            /// 手机号码
            /// </summary>
            public string SJHM { get { return sjhm; } set { sjhm = value; OnPropertyChanged(new PropertyChangedEventArgs("SJHM")); } }
            private string sjhm;
            /// <summary>
            /// 开户银行
            /// </summary>
            public string KHYH { get { return khyh; } set { khyh = value; OnPropertyChanged(new PropertyChangedEventArgs("KHYH")); } }
            private string khyh;
            /// <summary>
            /// 银行账户
            /// </summary>
            public string YHZH { get { return yhzh; } set { yhzh = value; OnPropertyChanged(new PropertyChangedEventArgs("YHZH")); } }
            private string yhzh;
            /// <summary>
            /// 备注
            /// </summary>
            public string BZ { get { return bz; } set { bz = value; OnPropertyChanged(new PropertyChangedEventArgs("BZ")); } }
            private string bz;
            /// <summary>
            /// 是否有效
            /// </summary>
            public int GYSState { get { return gysState; } set { gysState = value; OnPropertyChanged(new PropertyChangedEventArgs("GYSState")); } }
            private int gysState;
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
