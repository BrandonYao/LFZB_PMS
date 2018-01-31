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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DAL.UserDAL userDal = new DAL.UserDAL(Config.Connection.Server);
        DAL.MessageDAL msgDal = new DAL.MessageDAL();
        public MainWindow()
        {
            InitializeComponent();
        }
        void ShowUC(UserControl uc, string title)
        {
            bool add = true;
            
            if (tcMenu.Items.Count > 0)
            {
                foreach (TabItem item in tcMenu.Items)
                {
                    if (item.Header.ToString().Trim() == title)
                    {
                        add = false;
                        tcMenu.SelectedItem = item;
                        break;
                    }
                }
            }
            if (add)
            {
                TabItem ti = new TabItem();
                ti.Header = "  " + title + "  ";
                ti.FontSize = 16;
                ti.FontWeight = FontWeights.Bold;
                uc.Height = tcMenu.ActualHeight < uc.Height ? tcMenu.ActualHeight : uc.Height;
                uc.Width = tcMenu.ActualWidth < uc.Width ? tcMenu.ActualWidth : uc.Width;
                ti.Content = uc;
                tcMenu.Items.Add(ti);
                tcMenu.SelectedItem = ti;
            }
        }
        void ItemClose()
        {
            CloseCurrent();
        }
        void CloseCurrent()
        {
            int i = tcMenu.SelectedIndex;
            if (i >= 0)
                tcMenu.Items.RemoveAt(i);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = Data.FXSName;
            cmdState = userDal.GetMenu(Data.FXSCode, Data.UserCode);
        }

        Dictionary<string, bool> cmdState = new Dictionary<string, bool>();

        #region 基础资料
        private void gyswh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCGYS uc = new UCGYS();
            uc.UCClose += new UCGYS.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void fxswh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCFXS uc = new UCFXS();
            uc.UCClose += new UCFXS.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void ssppwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCSSPP uc = new UCSSPP();
            uc.UCClose += new UCSSPP.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void csmcwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void bsmcwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCBSMC uc = new UCBSMC();
            uc.UCClose += new UCBSMC.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void bssxwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCBSSX uc = new UCBSSX();
            uc.UCClose += new UCBSSX.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void ssmcwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCSSMC uc = new UCSSMC();
            uc.UCClose += new UCSSMC.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void zkkwwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCZKKW uc = new UCZKKW();
            uc.UCClose += new UCZKKW.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void fxgzwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCFXGZ uc = new UCFXGZ();
            uc.UCClose += new UCFXGZ.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void xtrywh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void xstcsz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void xsmrzk_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void sybzwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCSYBZ uc = new UCSYBZ();
            uc.UCClose += new UCSYBZ.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void cxyhxm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCYHXM uc = new UCYHXM();
            uc.UCClose += new UCYHXM.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void syfswh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCSYFS uc = new UCSYFS();
            uc.UCClose += new UCSYFS.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void xsxtsx_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCXSXTSX uc = new UCXSXTSX();
            uc.UCClose += new UCXSXTSX.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }
        private void sslspz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void sstpwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void sstpxz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void xshsjj_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void bsdjsz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void shywh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        private void Menu_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            e.CanExecute = cmdState.Keys.Contains(cmd.Name) && cmdState[cmd.Name];
        }

        #region 总库管理
        private void ssrkd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void sstkd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zkjltk_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zksjxg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void ssdlxg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zygsbqdy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void ssczylb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void ssmxylb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void ssrkmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void ssrktjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zkxgmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zkxgtjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void jltkmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void jltktjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zkjlkcb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zkkcmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zkkctjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void zkjxchzb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        #endregion

        #region 分销管理
        private void fxjhd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxthd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxtbd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxtgd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxjlhc_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxsjxg_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxkcpd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxjhmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxjhtjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxtgmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxttmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxtttjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxxgmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxxgtjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void jlhcmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void jlhctjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxjlkcb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxjlstc_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxkcmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxkctjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void fxsjxchz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        #region 销售管理
        private void ssxsd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ssxtd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void xsjjd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void xsdjd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void fxsyhzd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ssxsmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ssxstjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ssxtmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ssxttjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void jlhsmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void jlhstjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void hygwtjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void hythtjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        #region 会员管理
        private void khhywh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void khdxpt_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void jfdhdj_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void khfwdj_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void khhfdj_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void khhydj_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void jfdhcx_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void jbzlwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void hydjsz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void dljfsz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ssjfsz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void hyyhsz_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zpzlwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zpjkd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zptkd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zptbd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zptktjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zptctjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zptrtjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zpdhmxb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zpdhtjb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void zpjskcb_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        #region 系统维护
        private void yhwh_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void yhqx_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void xgmm_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void xtcs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand cmd = (RoutedUICommand)e.Command;
            UCXTCS uc = new UCXTCS();
            //uc.UCClose += new UCGYS.HandleClose(ItemClose);
            ShowUC(uc, cmd.Text);
        }

        private void bdcs_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        #region 帮助
        private void gy_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        private void Menu_Close_Click(object sender, RoutedEventArgs e)
        {
            CloseCurrent();
        }

        private void Menu_CloseAll_Click(object sender, RoutedEventArgs e)
        {
            tcMenu.Items.Clear();
        }

        private void Menu_CloseOther_Click(object sender, RoutedEventArgs e)
        {
            int i = tcMenu.SelectedIndex;
            int num = tcMenu.Items.Count;
            for (int n = num - 1; n >= 0; n--)
            {
                if (n != i)
                    tcMenu.Items.RemoveAt(n);
            }
        }
    }
}
