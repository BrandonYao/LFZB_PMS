using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static LFZB_PMS.CommModel;
using static LFZB_PMS.DAL.CSMCDAL;

namespace LFZB_PMS
{
    /// <summary>
    /// UCBSSX.xaml 的交互逻辑
    /// </summary>
    public partial class UCCSMC : UserControl
    {
        DAL.CSMCDAL objDal = new DAL.CSMCDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();

        public delegate void HandleClose();
        public HandleClose UCClose;
        public UCCSMC()
        {
            InitializeComponent();

            ICollectionView vw = CollectionViewSource.GetDefaultView(ObjList);
            vw.GroupDescriptions.Add(new PropertyGroupDescription("TypeName"));
        }
        void BindSearch()
        {
            IList<SearchItem> list = new List<SearchItem>();
            list.Add(new SearchItem() { Column = "csmcname", Text = "成色" });
            cmbSearch.ItemsSource = list; cmbSearch.SelectedValuePath = "Column"; cmbSearch.DisplayMemberPath = "Text";
        }

        public ObservableCollection<CSMCClass> ObjList = new ObservableCollection<CSMCClass>();
        void ShowData()
        {
            ObjList.Clear();
            DataTable dt = objDal.GetList();
            DataTableToList(dt);
            ShowList();
        }
        void DataTableToList(DataTable dt)
        {
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ObjList.Add(new CSMCClass()
                    {
                        CSMCCode = row["csmccode"].ToString().Trim(),
                        CSMCName = row["csmcname"].ToString().Trim(),
                        TypeName = row["typename"].ToString().Trim(),
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
            dgData.ItemsSource = ObjList;
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
            foreach (CSMCClass obj in ObjList)
            {
                if (obj.IsDirty)
                {
                    if (string.IsNullOrEmpty(obj.CSMCCode))
                        objDal.InsertData(obj, Data.UserCode);
                    else
                        objDal.UpdateData(obj, Data.UserCode);
                    obj.IsDirty = false;
                }
            }
            ShowData();
        }
        void SearchData(string column, string value)
        {
            ObjList.Clear();
            DataTable dt = objDal.Search(column, value);
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
            if (dgData.SelectedItem != null)
            {
                CSMCClass obj_sel = dgData.SelectedItem as CSMCClass;
                CSMCClass obj = new CSMCClass() { IsDirty = true, State = 1, TypeName= obj_sel.TypeName };
                ObjList.Add(obj);
                ShowList();
            }
        }
        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            boolEdit = (dgData != null && dgData.SelectedItem != null);
            e.CanExecute = boolEdit;
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
            CSMCClass obj = dgData.SelectedItem as CSMCClass;
            objDal.DeleteData(obj.CSMCCode);
            ObjList.Remove(obj);
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
            foreach (CSMCClass obj in ObjList)
            {
                if (obj.IsDirty)
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
            foreach (CSMCClass obj in ObjList)
            {
                if (obj.IsDirty)
                {
                    can = false;
                    break;
                }
            }
            boolPrint = can && ObjList.Count > 0;

            e.CanExecute = boolPrint;
        }
        private void Export_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DAL.ExcelDAL.ExportToExcel<CSMCClass, List<CSMCClass>> exporttoexcel =
                new DAL.ExcelDAL.ExportToExcel<CSMCClass, List<CSMCClass>>();
            //实例化exporttoexcel对象
            exporttoexcel.DataToPrint = (dgData.ItemsSource as ObservableCollection<CSMCClass>).ToList();
            string fileName ="成色名称";
            exporttoexcel.ListToExcel(fileName);//.GenerateReport();
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
            CSMCClass obj = dgData.SelectedItem as CSMCClass;
            obj.IsDirty = true;
            ShowList();
        }

        private void dgData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CSMCClass obj = dgData.SelectedItem as CSMCClass;
            obj.IsDirty = true;
            ShowList();
        }
    }
}
