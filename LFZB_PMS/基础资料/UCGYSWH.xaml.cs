using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LFZB_PMS
{
    /// <summary>
    /// UCGYSWH.xaml 的交互逻辑
    /// </summary>
    public partial class UCGYSWH : UserControl
    {
        DAL.GYSDAL gysDal = new DAL.GYSDAL(Config.Connection.Server);
        public UCGYSWH()
        {
            InitializeComponent();
        }

        #region 供应商类型
        public class GYSType
        {
            /// <summary>
            /// 供应商类型编号
            /// </summary>
            public string GYSZCode { get; set; }
            /// <summary>
            /// 供应商类型名称
            /// </summary>
            public string GYSZName { get; set; } 
            /// <summary>
            /// 主营产品编号
            /// </summary>
            public string ZYCPCode { get; set; }
            /// <summary>
            /// 主营产品名称
            /// </summary>
            public string ZYCPName { get; set; }
            /// <summary>
            /// 数量
            /// </summary>
            public string GYSCount { get; set; }
        }
            #endregion

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
            public string GYSName { get; set; }
            /// <summary>
            /// 供应商类型编号
            /// </summary>
            public string GYSZCode { get; set; }
            /// <summary>
            /// 供应商类型名称
            /// </summary>
            public string GYSZName { get; set; }
            /// <summary>
            /// 主营产品编号
            /// </summary>
            public string ZYCPCode { get; set; }
            /// <summary>
            /// 主营产品名称
            /// </summary>
            public string ZYCPName { get; set; }
            /// <summary>
            /// 联系地址
            /// </summary>
            public string LXDZ { get; set; }
            /// <summary>
            /// 联系人
            /// </summary>
            public string LXR { get; set; }
            /// <summary>
            /// 邮政编码
            /// </summary>
            public string YZBM { get; set; }
            /// <summary>
            /// 联系电话
            /// </summary>
            public string LXDH { get; set; }
            /// <summary>
            /// 传真号码
            /// </summary>
            public string CZHM { get; set; }
            /// <summary>
            /// 电子邮箱
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// 手机号码
            /// </summary>
            public string SJHM { get; set; }
            /// <summary>
            /// 开户银行
            /// </summary>
            public string KHYH { get; set; }
            /// <summary>
            /// 银行账户
            /// </summary>
            public string YHZH { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string BZ { get; set; }
            /// <summary>
            /// 是否有效
            /// </summary>
            public string GYSState { get { return gysState; } set { gysState = value; OnPropertyChanged(new PropertyChangedEventArgs("OutPos")); } }
            private string gysState;
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

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, e);
            }
        }
        #endregion

        void ShowType()
        {
            IList<GYSType> list = new List<GYSType>();
            DataTable dt = gysDal.GetType();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new GYSType() { GYSZCode = row["gyszcode"].ToString().Trim(),
                        GYSZName = row["gyszname"].ToString().Trim(),
                        ZYCPCode = row["zycpcode"].ToString().Trim(),
                        ZYCPName = row["zycpname"].ToString().Trim(),
                        GYSCount = row["gyscount"].ToString().Trim()
                    });
                }
            }
            dgType.ItemsSource = list;

            if (list.Count > 0)
                ShowData(list[0].GYSZCode, list[0].ZYCPCode);
        }
        IList<GYSClass> gysList = new List<GYSClass>();
        void ShowData(string gyszCode, string zycpCode)
        {
            DataTable dt = gysDal.GetGYSList(gyszCode, zycpCode);
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    gysList.Add(new GYSClass()
                    {
                        GYSZCode = row["gyszcode"].ToString().Trim(),
                        GYSZName = row["gyszname"].ToString().Trim(),
                        ZYCPCode = row["zycpname"].ToString().Trim(),
                        ZYCPName = row["zycpname"].ToString().Trim(),
                        GYSCode  = row["gyscode"].ToString().Trim(),
                        GYSName = row["gysname"].ToString().Trim(),
                        LXDZ = row["LXDZ"].ToString().Trim(),
                        LXR = row["LXR"].ToString().Trim(),
                        YZBM = row["YZBM"].ToString().Trim(),
                        LXDH = row["LXDH"].ToString().Trim(),
                        CZHM = row["CZHM"].ToString().Trim(),
                        Email = row["Email"].ToString().Trim(),
                        SJHM = row["SJHM"].ToString().Trim(),
                        KHYH = row["KHYH"].ToString().Trim(),
                        YHZH = row["YHZH"].ToString().Trim(),
                        BZ = row["BZ"].ToString().Trim(),
                        GYSState = row["GYSState"].ToString().Trim(),
                        UserCode = row["UserCode"].ToString().Trim(),
                        UserName = row["UserName"].ToString().Trim(),
                        Date = row["Date"].ToString().Trim(),
                    });
                }
            }
            dgData.ItemsSource = gysList;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowType();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IList<GYSClass> list = dgData.ItemsSource as IList<GYSClass>;
        }
    }
}
