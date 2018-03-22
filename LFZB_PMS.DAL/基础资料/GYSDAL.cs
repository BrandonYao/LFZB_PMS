using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS.DAL
{
    public class GYSDAL
    {
        DB.MySqlDB mySql;
        public GYSDAL(string connStr)
        {
            mySql = new DB.MySqlDB(connStr);
        }
        public DataTable GetGYSType()
        {
            string sql = string.Format("select * from v_gysz_zycp");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetList(string gyszCode, string zycpCode)
        {
            string sql = string.Format("select * from v_gys where gyszcode='{0}' and zycpcode='{1}'", gyszCode, zycpCode);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetGYSZ()
        {
            string sql = string.Format("select * from base_gysz");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public DataTable GetZYCP()
        {
            string sql = string.Format("select * from base_zycp");
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }
        public void InsertData(GYSClass gys, string userCode)
        {
            string sql = string.Format(@"insert into base_gys (gysname,gyszcode,zycpcode,lxdz,lxr,yzbm,lxdh,czhm,email,sjhm,khyh,yhzh,bz,state,usercode,date) values 
                ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},'{14}','{15}')",
                gys.GYSName, gys.GYSZCode, gys.ZYCPCode, gys.LXDZ, gys.LXR, gys.YZBM, gys.LXDH, gys.CZHM, gys.Email, gys.SJHM, gys.KHYH, gys.YHZH, gys.BZ, gys.State, userCode, DateTime.Now.ToString());
            mySql.Run(sql);
        }
        public void UpdateData(GYSClass gys, string userCode)
        {
            string sql = string.Format(@"update base_gys set gysname='{0}',gyszcode='{1}',zycpcode='{2}',lxdz='{3}',lxr='{4}',yzbm='{5}',lxdh='{6}',czhm='{7}',
email='{8}',sjhm='{9}',khyh='{10}',yhzh='{11}',bz='{12}',state={13},usercode='{14}',date='{15}' where gyscode='{16}'",
                   gys.GYSName, gys.GYSZCode, gys.ZYCPCode, gys.LXDZ, gys.LXR, gys.YZBM, gys.LXDH, gys.CZHM, gys.Email, gys.SJHM, gys.KHYH, gys.YHZH, gys.BZ, gys.State, userCode, DateTime.Now.ToString(), gys.GYSCode);
            mySql.Run(sql);
        }
        public void DeleteData(string gysCode)
        {
            string sql = string.Format(@"update base_gys set del=1 where gyscode='{0}'", gysCode);
            mySql.Run(sql);
        }
        public DataTable Search(string column, string value)
        {
            string sql = string.Format("select * from v_gys where {0} like '%{1}%'", column, value);
            DataSet ds = mySql.DS(sql);
            return ds.Tables[0];
        }

        #region 供应商
        public class GYSClass : INotifyPropertyChanged
        {
            /// <summary>
            /// 供应商编号
            /// </summary>
            public string GYSCode { get; set; }
            /// <summary>
            /// 供应商名称
            /// </summary>
            public string GYSName { get { return gysName; } set { gysName = value; OnPropertyChanged(new PropertyChangedEventArgs("GYSName")); } }
            private string gysName;
            /// <summary>
            /// 供应商类型编号
            /// </summary>
            public string GYSZCode { get { return gyszCode; } set { gyszCode = value; OnPropertyChanged(new PropertyChangedEventArgs("GYSZCode")); } }
            private string gyszCode;
            /// <summary>
            /// 供应商类型名称
            /// </summary>
            public string GYSZName { get { return gyszName; } set { gyszName = value; OnPropertyChanged(new PropertyChangedEventArgs("GYSZName")); } }
            private string gyszName;
            /// <summary>
            /// 主营产品编号
            /// </summary>
            public string ZYCPCode { get { return zycpCode; } set { zycpCode = value; OnPropertyChanged(new PropertyChangedEventArgs("ZYCPCode")); } }
            private string zycpCode;
            /// <summary>
            /// 主营产品名称
            /// </summary>
            public string ZYCPName { get { return zycpName; } set { zycpName = value; OnPropertyChanged(new PropertyChangedEventArgs("ZYCPName")); } }
            private string zycpName;
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
