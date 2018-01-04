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
using static LFZB_PMS.WinFD;
using static LFZB_PMS.WinUser;

namespace LFZB_PMS
{
    /// <summary>
    /// WinLogin.xaml 的交互逻辑
    /// </summary>
    public partial class WinLogin : Window
    {
        DAL.FDDAL fdDal = new DAL.FDDAL(Config.Connection.Server);
        DAL.UserDAL userDal = new DAL.UserDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();

        public WinLogin()
        {
            InitializeComponent();
        }
        void GetFD()
        {
            IList<FDClass> list = new List<FDClass>();
            DataTable dt = fdDal.GetFDInfo();
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new FDClass() { FDCode = row["fdcode"].ToString().Trim(), FDName = row["fdname"].ToString().Trim() });
                }
            }
            cmbfd.ItemsSource = list;
            cmbfd.SelectedValuePath = "FDCode";
            cmbfd.DisplayMemberPath = "FDName";
        }
        void GetUser(string fdCode)
        {
            IList<UserClass> list = new List<UserClass>();
            DataTable dt = userDal.GetUser(fdCode);
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new UserClass() { UserCode = row["usercode"].ToString().Trim(), UserName = row["username"].ToString().Trim() });
                }
            }
            cmbCode.ItemsSource = list;
            cmbCode.SelectedValuePath = "UserCode";
            cmbCode.DisplayMemberPath = "UserName";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetFD();
        }

        private void cbfd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string code = "";
            if (cmbfd.SelectedItem != null)
                code = cmbfd.SelectedValue.ToString();
            GetUser(code);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string fdCode = "";
            if (cmbfd.SelectedItem!= null)
            fdCode = cmbfd.SelectedValue.ToString();
            string userCode = cmbCode.Text.Trim();
            if (cmbCode.SelectedItem != null)
                userCode = cmbCode.SelectedValue.ToString();
            string pw = pwPassword.Password;
            if (userDal.Login(fdCode, userCode, pw))
            {
                new MainWindow().Show();
                Data.FDCode = fdCode;
                Data.UserCode = userCode;
            }
            else msgDal.ShowWarning("登陆失败");
        }
    }
}
