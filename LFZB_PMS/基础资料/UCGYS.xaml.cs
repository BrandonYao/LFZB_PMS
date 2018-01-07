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
using static LFZB_PMS.DAL.GYSDAL;

namespace LFZB_PMS
{
    /// <summary>
    /// UCGYSWH.xaml 的交互逻辑
    /// </summary>
    public partial class UCGYS : UserControl
    {
        DAL.GYSDAL gysDal = new DAL.GYSDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();

        public delegate void HandleClose();
        public HandleClose UCClose;
        public UCGYS()
        {
            InitializeComponent();
            BindGYSZ();
            BindZYCP();
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

        #region 数据源
        public class GYSZ
        {
            /// <summary>
            /// 供应商类型编号
            /// </summary>
            public string GYSZCode { get; set; }
            /// <summary>
            /// 供应商类型名称
            /// </summary>
            public string GYSZName { get; set; }
        }
        public class ZYCP
        {
            /// <summary>
            /// 主营产品编号
            /// </summary>
            public string ZYCPCode { get; set; }
            /// <summary>
            /// 主营产品名称
            /// </summary>
            public string ZYCPName { get; set; }
        }
        private IList<GYSZ> gyszList = new List<GYSZ>();
        public IList<GYSZ> GYSZList { get { return gyszList; } set { gyszList = value; } }

        private IList<ZYCP> zycpList = new List<ZYCP>();
        public IList<ZYCP> ZYCPList { get { return zycpList; } set { zycpList = value; } }

        void BindGYSZ()
        {
            DataTable dt = gysDal.GetGYSZ();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    gyszList.Add(new GYSZ()
                    {
                        GYSZCode = row["gyszcode"].ToString().Trim(),
                        GYSZName = row["gyszname"].ToString().Trim()
                    });
                }
            }
            cmbgysz.ItemsSource = gyszList; cmbgysz.SelectedValuePath = "GYSZCode"; cmbgysz.DisplayMemberPath = "GYSZName";
        }
        void BindZYCP()
        {
            DataTable dt = gysDal.GetZYCP();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    zycpList.Add(new ZYCP()
                    {
                        ZYCPCode = row["zycpcode"].ToString().Trim(),
                        ZYCPName = row["zycpname"].ToString().Trim()
                    });
                }
            }
            cmbzycp.ItemsSource = zycpList; cmbzycp.SelectedValuePath = "ZYCPCode"; cmbzycp.DisplayMemberPath = "ZYCPName";
        }

        public class SearchItem
        {
            public string Column { get; set; }
            public string Text { get; set; }
        }
        void BindSearch()
        {
            IList<SearchItem> list = new List<SearchItem>();
            list.Add(new SearchItem() { Column = "gysname", Text = "供应商名称" });
            list.Add(new SearchItem() { Column = "lxr", Text = "联系人" });
            cmbSearch.ItemsSource = list; cmbSearch.SelectedValuePath = "Column"; cmbSearch.DisplayMemberPath = "Text";
        }
        #endregion

        void ShowType()
        {
            IList<GYSType> list = new List<GYSType>();
            DataTable dt = gysDal.GetGYSType();
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
            dgType.ItemsSource = null;
            dgType.ItemsSource = list;

            if (list.Count > 0)
                ShowData(list[0].GYSZCode, list[0].ZYCPCode);
        }
        public IList<GYSClass> GYSList = new List<GYSClass>();
        void ShowData(string gyszCode, string zycpCode)
        {
            GYSList.Clear();
            DataTable dt = gysDal.GetGYSList(gyszCode, zycpCode);
            DataTableToList(dt);
            ShowList();
        }
        void DataTableToList(DataTable dt)
        {
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    GYSList.Add(new GYSClass()
                    {
                        GYSZCode = row["gyszcode"].ToString().Trim(),
                        GYSZName = row["gyszname"].ToString().Trim(),
                        ZYCPCode = row["zycpcode"].ToString().Trim(),
                        ZYCPName = row["zycpname"].ToString().Trim(),
                        GYSCode = row["gyscode"].ToString().Trim(),
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
                        GYSState = int.Parse(row["GYSState"].ToString()),
                        UserCode = row["UserCode"].ToString().Trim(),
                        UserName = row["UserName"].ToString().Trim(),
                        Date = row["Date"].ToString().Trim(),
                    });
                }
            }
        }
        void ShowList()
        {
            dgData.ItemsSource = null;
            dgData.ItemsSource = GYSList;
            if (gdData.DataContext != null)
            {
                GYSClass gys = gdData.DataContext as GYSClass;
                if (!GYSList.Contains(gys)) gdData.DataContext = null;
            }
        }
        void CheckSave()
        {
            if (boolCancle && msgDal.ShowQuestion("数据已经改动，是否保存？"))
            {
                SaveList();
            }
        }
        void SaveList()
        {
            foreach (GYSClass gys in GYSList)
            {
                if (gys.IsDirty)
                {
                    if (string.IsNullOrEmpty(gys.GYSCode))
                        gysDal.InsertData(gys, Data.UserCode);
                    else
                        gysDal.UpdateData(gys, Data.UserCode);
                    gys.IsDirty = false;
                }
            }
            ShowList();
        }
        void SearchData(string column, string value)
        {
            GYSList.Clear();
            DataTable dt = gysDal.Search(column, value);
            DataTableToList(dt);
            ShowList();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowType();
            BindSearch();
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgType.SelectedItem != null)
            {
                CheckSave();
                GYSType gt = dgType.SelectedItem as GYSType;
                ShowData(gt.GYSZCode, gt.ZYCPCode);
            }
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem != null)
            {
                GYSClass gys = dgData.SelectedItem as GYSClass;
                gdData.DataContext = gys;
            }
        }

        #region cmd
        private void Refresh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CheckSave();
            ShowType();
        }
        private void Refresh_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Search_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string column = cmbSearch.SelectedValue.ToString();
            SearchData(column, tbValue.Text.Trim());
        }
        private void Search_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Add_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GYSClass gys = new GYSClass() { IsDirty = true };
            GYSList.Add(gys);
            ShowList();
            gdData.DataContext = gys;
            cmbgysz.SelectedIndex = 0;
            cmbzycp.SelectedIndex = 0;
        }
        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        bool boolEdit = false;
        private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void Edit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            boolEdit = (dgData != null && dgData.SelectedItem != null);
            e.CanExecute = boolEdit;
        }
        private void Del_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GYSClass gys = dgData.SelectedItem as GYSClass;
            gysDal.DeleteData(gys.GYSCode);
            GYSList.Remove(gys);
            ShowList();
        }
        private void Del_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolEdit;
        }

        private void Cancle_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IList<GYSClass> list = dgData.ItemsSource as IList<GYSClass>;
        }
        bool boolCancle = false;
        private void Cancle_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool can = false;
            foreach (GYSClass gys in GYSList)
            {
                if (gys.IsDirty)
                {
                    can = true;
                    break;
                }
            }
            boolCancle = can;
            e.CanExecute = boolCancle;
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveList();
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolCancle;
        }

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        bool boolPrint = false;
        private void Print_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool can = true;
            foreach (GYSClass gys in GYSList)
            {
                if (gys.IsDirty)
                {
                    can = false;
                    break;
                }
            }
            boolPrint = can && GYSList.Count > 0;

            e.CanExecute = boolPrint;
        }
        private void Export_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void Export_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolPrint;
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CheckSave();
            UCClose?.Invoke();
        }
        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion

        //自动添加行序号
        private void dgData_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void gys_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //int i = KeyInterop.VirtualKeyFromKey((System.Windows.Input.Key)e.ImeProcessedKey);
            //if ((i >= 48 && i <= 57) || (i >= 96 && i <= 105) || (i >= 65 && i <= 90) || i == 8 || i == 46)

            if (gdData.DataContext != null)
            {
                GYSClass gys = gdData.DataContext as GYSClass;
                gys.IsDirty = true;
                ShowList();
            }
            
            e.Handled = true;
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (gdData.DataContext != null)
            {
                GYSClass gys = gdData.DataContext as GYSClass;
                gys.IsDirty = true;
                ShowList();
            }
        }
        private void cmb_DropDownClosed(object sender, EventArgs e)
        {
            if (gdData.DataContext != null)
            {
                GYSClass gys = gdData.DataContext as GYSClass;
                gys.IsDirty = true;
                ShowList();
            }
        }
    }
}
