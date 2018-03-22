using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static LFZB_PMS.CommModel;

namespace LFZB_PMS
{
    /// <summary>
    /// UCOrderList.xaml 的交互逻辑
    /// </summary>
    public partial class UCOrderList : UserControl
    {
        DAL.BSMCDAL bsmcDal = new DAL.BSMCDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();

        public delegate void HandleClose();
        public HandleClose UCClose;
        public UCOrderList()
        {
            InitializeComponent();
        }
        public ObservableCollection<OrderMaster> BSMCList = new ObservableCollection<OrderMaster>();
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
                    BSMCList.Add(new OrderMaster()
                    {
                        //BSMCCode = row["bsmccode"].ToString().Trim(),
                        //BSMCName = row["bsmcname"].ToString().Trim(),
                        State = Convert.ToInt32(row["State"]),
                        //UserCode = row["UserCode"].ToString().Trim(),
                        //UserName = row["UserName"].ToString().Trim(),
                        //Date = row["Date"].ToString().Trim(),
                    });
                }
            }
        }
        void ShowList()
        {
            dgMaster.ItemsSource = null;
            dgMaster.ItemsSource = BSMCList;

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
            foreach (OrderMaster bsmc in BSMCList)
            {
                //if (bsmc.IsDirty)
                //{
                //    if (string.IsNullOrEmpty(bsmc.BSMCCode))
                //        bsmcDal.InsertData(bsmc, Data.UserCode);
                //    else
                //        bsmcDal.UpdateData(bsmc, Data.UserCode);
                //    bsmc.IsDirty = false;
                //}
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
            //BindSearch();
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
            //if (cmbSearch.SelectedItem != null)
            //{
            //    string column = cmbSearch.SelectedValue.ToString();
            //    SearchData(column, tbValue.Text.Trim());
            //}
        }
        private void Search_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Add_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //OrderMaster obj = new OrderMaster() { IsDirty = true, State = 1 };
            //BSMCList.Add(obj);
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
            boolEdit = (dgMaster != null && dgMaster.SelectedItem != null);
            e.CanExecute = boolEdit;
        }
        private void Del_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!msgDal.ShowQuestion("确定要删除选中项吗？")) return;
            OrderMaster obj = dgMaster.SelectedItem as OrderMaster;
            //bsmcDal.DeleteData(obj.BSMCCode);
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
            foreach (OrderMaster bssx in BSMCList)
            {
                //if (bssx.IsDirty)
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

        private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveList();
        }
        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolCancle;
        }
        private void Confirm_Not_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveList();
        }
        private void Confirm_Not_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolCancle;
        }
        private void Check_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveList();
        }
        private void Check_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolCancle;
        }
        private void Check_Not_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveList();
        }
        private void Check_Not_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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
            foreach (OrderMaster bssx in BSMCList)
            {
                //if (bssx.IsDirty)
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
            DAL.ExcelDAL.ExportToExcel<OrderMaster, List<OrderMaster>> exporttoexcel =
                new DAL.ExcelDAL.ExportToExcel<OrderMaster, List<OrderMaster>>();
            //实例化exporttoexcel对象
            exporttoexcel.DataToPrint = (dgMaster.ItemsSource as ObservableCollection<OrderMaster>).ToList();
            string fileName = "单据明细";
            exporttoexcel.ListToExcel(fileName);
        }
        private void Export_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = boolPrint;
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //CheckSave();
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
            OrderMaster obj = dgMaster.SelectedItem as OrderMaster;
            //obj.IsDirty = true;
            ShowList();
        }

        private void dgData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            OrderMaster obj = dgMaster.SelectedItem as OrderMaster;
            //obj.IsDirty = true;
            ShowList();
        }
    }
}
