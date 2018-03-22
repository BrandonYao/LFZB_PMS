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

namespace LFZB_PMS
{
    /// <summary>
    /// UCXTCS.xaml 的交互逻辑
    /// </summary>
    public partial class UCXTCS : UserControl
    {
        DAL.ConfigDAL cfgDal = new DAL.ConfigDAL(Config.Connection.Server);

        public delegate void HandleClose();
        public HandleClose UCClose;
        public UCXTCS()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = cfgDal.GetConfig();
        }

        #region cmd
        private void Refresh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void Refresh_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
    }
}
