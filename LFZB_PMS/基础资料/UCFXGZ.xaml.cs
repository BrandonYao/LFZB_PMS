using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static LFZB_PMS.CommModel;
using static LFZB_PMS.DAL.FXGZDAL;
using static LFZB_PMS.DAL.FXSDAL;

namespace LFZB_PMS
{
    /// <summary>
    /// UCBSSX.xaml 的交互逻辑
    /// </summary>
    public partial class UCFXGZ : UserControl
    {
        DAL.FXGZDAL dal = new DAL.FXGZDAL(Config.Connection.Server);
        DAL.FXSDAL fxsDal = new DAL.FXSDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();

        public delegate void HandleClose();
        public HandleClose UCClose;

        public UCFXGZ()
        {
            BindFXS();

            InitializeComponent();
        }

        #region 数据源
        
        private static ObservableCollection<FXSClass> fxsList = new ObservableCollection<FXSClass>();
        public static ObservableCollection<FXSClass> FXSList { get { return fxsList; } set { fxsList = value; } }

        void BindFXS()
        {
            DataTable dt = fxsDal.GetFXSInfo();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    fxsList.Add(new FXSClass() { FXSCode = row["fxscode"].ToString().Trim(), FXSName = row["fxsname"].ToString().Trim() });
                }
            }
        }
        void BindSearch()
        {
            IList<SearchItem> list = new List<SearchItem>();
            list.Add(new SearchItem() { Column = "fxgzname", Text = "分销柜组" });
            cmbSearch.ItemsSource = list; cmbSearch.SelectedValuePath = "Column"; cmbSearch.DisplayMemberPath = "Text";
        }
        #endregion

        public ObservableCollection<FXGZClass> DataList = new ObservableCollection<FXGZClass>();
        void ShowData()
        {
            DataList.Clear();
            DataTable dt = dal.GetList();
            DataTableToList(dt);
            ShowList();
        }
        void DataTableToList(DataTable dt)
        {
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DataList.Add(new FXGZClass()
                    {
                        FXGZCode = row["FXGZCode"].ToString().Trim(),
                        FXGZName = row["FXGZName"].ToString().Trim(),
                        FXSCode = Convert.ToInt32(row["FXSCode"]),
                        FXSName = row["FXSName"].ToString().Trim(),
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
            dgData.ItemsSource = DataList;
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
            foreach (FXGZClass cls in DataList)
            {
                if (cls.IsDirty)
                {
                    if (string.IsNullOrEmpty(cls.FXGZCode))
                        dal.InsertData(cls, Data.UserCode);
                    else
                        dal.UpdateData(cls, Data.UserCode);
                    cls.IsDirty = false;
                }
            }
            ShowData();
        }
        void SearchData(string column, string value)
        {
            DataList.Clear();
            DataTable dt = dal.Search(column, value);
            DataTableToList(dt);
            ShowList();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindSearch();
            ShowData();
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        #region cmd
        private void Refresh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CheckSave();
            ShowData();
        }
        private void Refresh_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Search_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (cmbSearch.SelectedItem != null)
            {
                CheckSave();
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
            FXGZClass cls = new FXGZClass() { FXSCode=0, IsDirty = true, State = 1 };
            DataList.Add(cls);
            ShowList();
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
            if (!msgDal.ShowQuestion("确定要删除选中项吗？")) return;
            FXGZClass cls = dgData.SelectedItem as FXGZClass;
            dal.DeleteData(cls.FXGZCode);
            DataList.Remove(cls);
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
            foreach (FXGZClass cls in DataList)
            {
                if (cls.IsDirty)
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
        private void Print_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool can = true;
            foreach (FXGZClass cls in DataList)
            {
                if (cls.IsDirty)
                {
                    can = false;
                    break;
                }
            }
            boolPrint = can && DataList.Count > 0;

            e.CanExecute = boolPrint;
        }
        private void Export_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DAL.ExcelDAL.ExportToExcel<FXGZClass, List<FXGZClass>> exporttoexcel =
                new DAL.ExcelDAL.ExportToExcel<FXGZClass, List<FXGZClass>>();
            //实例化exporttoexcel对象
            exporttoexcel.DataToPrint = (dgData.ItemsSource as ObservableCollection<FXGZClass>).ToList();
            string fileName = "分销柜组";
            exporttoexcel.ListToExcel(fileName);
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
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            FXGZClass obj = dgData.SelectedItem as FXGZClass;
            obj.IsDirty = true;
            ShowList();
        }

        private void dgData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            FXGZClass obj = dgData.SelectedItem as FXGZClass;
            obj.IsDirty = true;
            ShowList();
        }
        private void cmb_DropDownClosed(object sender, EventArgs e)
        {
            FXGZClass obj = dgData.SelectedItem as FXGZClass;
            if (obj != null)
            {
                obj.IsDirty = true;
                ShowList();
            }
        }
    }
}
