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
using System.Windows.Shapes;

namespace LFZB_PMS
{
    /// <summary>
    /// WinFD.xaml 的交互逻辑
    /// </summary>
    public partial class WinFD : Window
    {
        DAL.FDDAL fdDal = new DAL.FDDAL(Config.Connection.Server);
        public WinFD()
        {
            InitializeComponent();
        }

        List<FDClass> FDList = new List<FDClass>();
        //bool isDirty = false;
        public class FDClass
        {
            /// <summary>
            /// 分店编号
            /// </summary>
            public string FDCode { get; set; }
            /// <summary>
            /// 分店名称
            /// </summary>
            public string FDName { get; set; }
            /// <summary>
            /// 分店状态
            /// </summary>
            public string FDState { get; set; }
            /// <summary>
            /// 是否修改
            /// </summary>
            public bool IsDirty { get; set; }
        }

        void GetData()
        {
            DataTable dt = fdDal.GetFDInfo();
            if (dt != null && dt.Rows.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    FDClass fd = new FDClass();
                    fd.FDCode = row["fdcode"].ToString().Trim();
                    fd.FDName = row["fdname"].ToString().Trim();
                    FDList.Add(fd);
                }
            }
            dgList.ItemsSource = FDList;
        }
        bool CheckDirty()
        {
            foreach (FDClass fd in FDList)
            {
                if (fd.IsDirty)
                    return true;
            }
            return false;
        }
        void SaveData()
        {
            foreach (FDClass fd in FDList)
            {
                if (fd.IsDirty)
                {
                    if (fdDal.FDIsExists(fd.FDCode))
                        fdDal.UpdateFD(fd.FDCode, fd.FDName);
                    else fdDal.InsertFD(fd.FDCode, fd.FDName);
                }
            }
        }

        private void Add_Cmd(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
