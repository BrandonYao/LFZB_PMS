using System;
using System.Collections.Generic;
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
using static LFZB_PMS.DAL.FXSDAL;

namespace LFZB_PMS
{
    /// <summary>
    /// UCFD.xaml 的交互逻辑
    /// </summary>
    public partial class UCFXS : UserControl
    {
        DAL.FXSDAL fxsDal = new DAL.FXSDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();

        public delegate void HandleClose();
        public HandleClose UCClose;
        public UCFXS()
        {
            InitializeComponent();
            BindFXLX();
            BindZLFS();
        }

        #region 分销商类型
        public class FXSType
        {
            /// <summary>
            /// 分销商分组编号
            /// </summary>
            public string FXSZCode { get; set; }
            /// <summary>
            /// 分销商分组名称
            /// </summary>
            public string FXSZName { get; set; }
            /// <summary>
            /// 分销类型编号
            /// </summary>
            public string FXLXCode { get; set; }
            /// <summary>
            /// 分销类型名称
            /// </summary>
            public string FXLXName { get; set; }
            /// <summary>
            /// 数量
            /// </summary>
            public string FXSCount { get; set; }
        }
        #endregion

        #region 数据源
        public class FXLX
        {
            /// <summary>
            /// 分销类型编号
            /// </summary>
            public string FXLXCode { get; set; }
            /// <summary>
            /// 分销类型名称
            /// </summary>
            public string FXLXName { get; set; }
        }
        public class ZLFS
        {
            public string ZLFSCode { get; set; }
            public string ZLFSName { get; set; }
        }

        private IList<FXLX> fxlxList = new List<FXLX>();
        public IList<FXLX> FXLXList { get { return fxlxList; } set { fxlxList = value; } }

        void BindFXLX()
        {
            DataTable dt = fxsDal.GetFXLX();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    fxlxList.Add(new FXLX()
                    {
                        FXLXCode = row["fxlxcode"].ToString().Trim(),
                        FXLXName = row["fxlxname"].ToString().Trim()
                    });
                }
            }
            cmbfxlx.ItemsSource = fxlxList; cmbfxlx.SelectedValuePath = "FXLXCode"; cmbfxlx.DisplayMemberPath = "FXLXName";
        }
        void BindZLFS()
        {
            IList<ZLFS> list = new List<ZLFS>();
            DataTable dt = fxsDal.GetZLFS();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new ZLFS()
                    {
                        ZLFSCode = row["zlfscode"].ToString().Trim(),
                        ZLFSName = row["zlfsname"].ToString().Trim()
                    });
                }
            }
            cmbZLFS.ItemsSource = list; cmbZLFS.SelectedValuePath = "ZLFSCode"; cmbZLFS.DisplayMemberPath = "ZLFSName";
        }

        public class SearchItem
        {
            public string Column { get; set; }
            public string Text { get; set; }
        }
        void BindSearch()
        {
            IList<SearchItem> list = new List<SearchItem>();
            list.Add(new SearchItem() { Column = "fxsname", Text = "分销商名称" });
            list.Add(new SearchItem() { Column = "lxr", Text = "联系人" });
            cmbSearch.ItemsSource = list; cmbSearch.SelectedValuePath = "Column"; cmbSearch.DisplayMemberPath = "Text";
        }
        #endregion

        void ShowType()
        {
            IList<FXSType> list = new List<FXSType>();
            DataTable dt = fxsDal.GetFXSType();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new FXSType()
                    {
                        FXSZCode = row["fxszcode"].ToString().Trim(),
                        FXSZName = row["fxszname"].ToString().Trim(),
                        FXLXCode = row["fxlxcode"].ToString().Trim(),
                        FXLXName = row["fxlxname"].ToString().Trim(),
                        FXSCount = row["fxscount"].ToString().Trim()
                    });
                }
            }
            dgType.ItemsSource = null;
            dgType.ItemsSource = list;

            if (list.Count > 0)
                ShowData(list[0].FXSZCode, list[0].FXLXCode);
        }
        public IList<FXSClass> FXSList = new List<FXSClass>();
        void ShowData(string fxszCode, string fxlxCode)
        {
            FXSList.Clear();
            DataTable dt = fxsDal.GetList(fxszCode, fxlxCode);
            DataTableToList(dt);
            ShowList();
        }
        void DataTableToList(DataTable dt)
        {
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    FXSList.Add(new FXSClass()
                    {
                        FXSZCode = row["fxszcode"].ToString().Trim(),
                        FXSZName = row["fxszname"].ToString().Trim(),
                        FXLXCode = row["fxlxcode"].ToString().Trim(),
                        FXLXName = row["fxlxname"].ToString().Trim(),
                        FXSCode = row["fxscode"].ToString().Trim(),
                        FXSName = row["fxsname"].ToString().Trim(),
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
                        CanXGJJ = Convert.ToInt32(row["CanXGJJ"]),
                        CanXGGF = Convert.ToInt32(row["CanXGGF"]),
                        CanXGZSDJ = Convert.ToInt32(row["CanXGZSDJ"]),
                        CanHYDXYH = Convert.ToInt32(row["CanHYDXYH"]),
                        CanDRTC = Convert.ToInt32(row["CanDRTC"]),
                        XSJJGLPP = Convert.ToInt32(row["XSJJGLPP"]),
                        JLJJGLPP = Convert.ToInt32(row["JLJJGLPP"]),
                        JCHSBXGZ = Convert.ToInt32(row["JCHSBXGZ"]),
                        ZLFSCode = row["ZLFSCode"].ToString().Trim(),
                        ZLFSName = row["ZLFSName"].ToString().Trim(),
                        State = Convert.ToInt32(row["State"]),
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
            dgData.ItemsSource = FXSList;
            if (gdData.DataContext != null)
            {
                FXSClass gys = gdData.DataContext as FXSClass;
                if (!FXSList.Contains(gys)) gdData.DataContext = null;
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
            foreach (FXSClass fxs in FXSList)
            {
                if (fxs.IsDirty)
                {
                    if (string.IsNullOrEmpty(fxs.FXSCode))
                        fxsDal.InsertData(fxs, Data.UserCode);
                    else
                        fxsDal.UpdateData(fxs, Data.UserCode);
                    fxs.IsDirty = false;
                }
            }
            ShowList();
        }
        void SearchData(string column, string value)
        {
            FXSList.Clear();
            DataTable dt = fxsDal.Search(column, value);
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
                FXSType gt = dgType.SelectedItem as FXSType;
                ShowData(gt.FXSZCode, gt.FXLXCode);
            }
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem != null)
            {
                FXSClass gys = dgData.SelectedItem as FXSClass;
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
            if (cmbSearch.SelectedItem != null)
            {
                string column = cmbSearch.SelectedValue.ToString();
                SearchData(column, tbValue.Text.Trim());
            }
        }
        private void Search_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Add_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FXSClass gys = new FXSClass() { IsDirty = true };
            FXSList.Add(gys);
            ShowList();
            gdData.DataContext = gys;
            cmbfxlx.SelectedIndex = 0;
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
            FXSClass gys = dgData.SelectedItem as FXSClass;
            fxsDal.DeleteData(gys.FXSCode);
            FXSList.Remove(gys);
            ShowList();
        }
        private void Del_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolEdit;
        }

        private void Cancle_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        bool boolCancle = false;
        private void Cancle_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool can = false;
            foreach (FXSClass gys in FXSList)
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
            foreach (FXSClass gys in FXSList)
            {
                if (gys.IsDirty)
                {
                    can = false;
                    break;
                }
            }
            boolPrint = can && FXSList.Count > 0;

            e.CanExecute = boolPrint;
        }
        private void Export_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DAL.ExcelDAL.ExportToExcel<FXSClass, List<FXSClass>> exporttoexcel =
                new DAL.ExcelDAL.ExportToExcel<FXSClass, List<FXSClass>>();
            //实例化exporttoexcel对象
            exporttoexcel.DataToPrint = (List<FXSClass>)dgData.ItemsSource;
            exporttoexcel.GenerateReport();
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
            if (gdData.DataContext != null)
            {
                FXSClass gys = gdData.DataContext as FXSClass;
                gys.IsDirty = true;
                ShowList();
            }

            //e.Handled = true;
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (gdData.DataContext != null)
            {
                FXSClass gys = gdData.DataContext as FXSClass;
                gys.IsDirty = true;
                ShowList();
            }
        }
        private void cmb_DropDownClosed(object sender, EventArgs e)
        {
            if (gdData.DataContext != null)
            {
                FXSClass gys = gdData.DataContext as FXSClass;
                gys.IsDirty = true;
                ShowList();
            }
        }
    }
}
