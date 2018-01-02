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
            cbfd.ItemsSource = list;
            cbfd.SelectedValuePath = "FDCode";
            cbfd.DisplayMemberPath = "FDName";
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
            cbCode.ItemsSource = list;
            cbCode.SelectedValuePath = "UserCode";
            cbCode.DisplayMemberPath = "UserName";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetFD();
        }

        private void cbfd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string code = "";
            if (cbfd.SelectedItem != null)
                code = cbfd.SelectedValue.ToString();
            GetUser(code);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string fdCode = "";
            if (cbfd.SelectedItem!= null)
            fdCode = cbfd.SelectedValue.ToString();
            string userCode = cbCode.Text.Trim();
            if (cbCode.SelectedItem != null)
                userCode = cbCode.SelectedValue.ToString();
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
