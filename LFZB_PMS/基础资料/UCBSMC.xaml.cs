using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static LFZB_PMS.CommModel;
using static LFZB_PMS.DAL.BSMCDAL;

namespace LFZB_PMS.BSMC
{
    /// <summary>
    /// UCBSSX.xaml 的交互逻辑
    /// </summary>
    public partial class UCBSMC : UserControl
    {
        DAL.BSMCDAL bsmcDal = new DAL.BSMCDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();

        public delegate void HandleClose();
        public HandleClose UCClose;
        public UCBSMC()
        {
            InitializeComponent();

            ICollectionView vw = CollectionViewSource.GetDefaultView(BSMCList);
            vw.GroupDescriptions.Add(new PropertyGroupDescription("TypeName"));
        }
        void BindSearch()
        {
            IList<SearchItem> list = new List<SearchItem>();
            list.Add(new SearchItem() { Column = "bsmcname", Text = "宝石名称" });
            cmbSearch.ItemsSource = list; cmbSearch.SelectedValuePath = "Column"; cmbSearch.DisplayMemberPath = "Text";
        }

        public ObservableCollection<BSMCClass> BSMCList = new ObservableCollection<BSMCClass>();
        void ShowData()
        {
            BSMCList.Clear();
            DataTable dt = bsmcDal.GetList();
            DataTableToList(dt);
            ShowList();
        }
        void DataTableToList(DataTable dt)
        {
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BSMCList.Add(new BSMCClass()
                    {
                        BSMCCode = row["bsmccode"].ToString().Trim(),
                        BSMCName = row["bsmcname"].ToString().Trim(),
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
            dgData2.ItemsSource = null;
            dgData2.ItemsSource = BSMCList;
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
            foreach (BSMCClass bsmc in BSMCList)
            {
                if (bsmc.IsDirty)
                {
                    if (string.IsNullOrEmpty(bsmc.BSMCCode))
                        bsmcDal.InsertData(bsmc, Data.UserCode);
                    else
                        bsmcDal.UpdateData(bsmc, Data.UserCode);
                    bsmc.IsDirty = false;
                }
            }
            ShowData();
        }
        void SearchData(string column, string value)
        {
            BSMCList.Clear();
            DataTable dt = bsmcDal.Search(column, value);
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
            BSMCClass obj = new BSMCClass() { IsDirty = true, State = 1 };
            BSMCList.Add(obj);
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
            boolEdit = (dgData2 != null && dgData2.SelectedItem != null);
            e.CanExecute = boolEdit;
        }
        private void Del_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!msgDal.ShowQuestion("确定要删除选中项吗？")) return;
            BSMCClass obj = dgData2.SelectedItem as BSMCClass;
            bsmcDal.DeleteData(obj.BSMCCode);
            BSMCList.Remove(obj);
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
            foreach (BSMCClass bssx in BSMCList)
            {
                if (bssx.IsDirty)
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
            foreach (BSMCClass bssx in BSMCList)
            {
                if (bssx.IsDirty)
                {
                    can = false;
                    break;
                }
            }
            boolPrint = can && BSMCList.Count > 0;

            e.CanExecute = boolPrint;
        }
        private void Export_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DAL.ExcelDAL.ExportToExcel<BSMCClass, List<BSMCClass>> exporttoexcel =
                new DAL.ExcelDAL.ExportToExcel<BSMCClass, List<BSMCClass>>();
            //实例化exporttoexcel对象
            exporttoexcel.DataToPrint = (dgData2.ItemsSource as ObservableCollection<BSMCClass>).ToList();
            string fileName = "宝石名称";
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
            BSMCClass obj = dgData2.SelectedItem as BSMCClass;
            obj.IsDirty = true;
            ShowList();
        }

        private void dgData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            BSMCClass obj = dgData2.SelectedItem as BSMCClass;
            obj.IsDirty = true;
            ShowList();
        }

    }
    public class BaseCmd
    {
        public static RoutedUICommand cmd_refresh { get { return cmd_refresh2; } }
        private static RoutedUICommand cmd_refresh2;
        public static RoutedUICommand cmd_search { get { return cmd_search2; } }
        private static RoutedUICommand cmd_search2;

        public static RoutedUICommand cmd_add { get { return cmd_add2; } }
        private static RoutedUICommand cmd_add2;
        public static RoutedUICommand cmd_edit { get { return cmd_edit2; } }
        private static RoutedUICommand cmd_edit2;
        public static RoutedUICommand cmd_del { get { return cmd_del2; } }
        private static RoutedUICommand cmd_del2;
        public static RoutedUICommand cmd_cancle { get { return cmd_cancle2; } }
        private static RoutedUICommand cmd_cancle2;
        public static RoutedUICommand cmd_save { get { return cmd_save2; } }
        private static RoutedUICommand cmd_save2;

        public static RoutedUICommand cmd_confirm { get { return cmd_confirm2; } }
        private static RoutedUICommand cmd_confirm2;
        public static RoutedUICommand cmd_confirm_not { get { return cmd_confirm_not2; } }
        private static RoutedUICommand cmd_confirm_not2;
        public static RoutedUICommand cmd_check { get { return cmd_check2; } }
        private static RoutedUICommand cmd_check2;
        public static RoutedUICommand cmd_check_not { get { return cmd_check_not2; } }
        private static RoutedUICommand cmd_check_not2;

        public static RoutedUICommand cmd_print { get { return cmd_print2; } }
        private static RoutedUICommand cmd_print2;
        public static RoutedUICommand cmd_export { get { return cmd_export2; } }
        private static RoutedUICommand cmd_export2;
        public static RoutedUICommand cmd_close { get { return cmd_close2; } }
        private static RoutedUICommand cmd_close2;

        static BaseCmd()
        {
            cmd_refresh2 = new RoutedUICommand("刷新", "cmd_refresh", typeof(BaseCmd));
            cmd_search2 = new RoutedUICommand("查找", "cmd_search", typeof(BaseCmd));

            cmd_add2 = new RoutedUICommand("新增", "cmd_add", typeof(BaseCmd));
            cmd_edit2 = new RoutedUICommand("修改", "cmd_edit", typeof(BaseCmd));
            cmd_del2 = new RoutedUICommand("删除", "cmd_del", typeof(BaseCmd));
            cmd_cancle2 = new RoutedUICommand("取消", "cmd_cancle", typeof(BaseCmd));
            cmd_save2 = new RoutedUICommand("保存", "cmd_save", typeof(BaseCmd));

            cmd_confirm2 = new RoutedUICommand("确认", "cmd_confirm", typeof(BaseCmd));
            cmd_confirm_not2 = new RoutedUICommand("反确认", "cmd_confirm_not", typeof(BaseCmd));
            cmd_check2 = new RoutedUICommand("审核", "cmd_check", typeof(BaseCmd));
            cmd_check_not2 = new RoutedUICommand("反审核", "cmd_check_not", typeof(BaseCmd));

            cmd_print2 = new RoutedUICommand("打印", "cmd_print", typeof(BaseCmd));
            cmd_export2 = new RoutedUICommand("导出Excel", "cmd_export", typeof(BaseCmd));
            cmd_close2 = new RoutedUICommand("关闭", "cmd_close", typeof(BaseCmd));
        }
    }
}
