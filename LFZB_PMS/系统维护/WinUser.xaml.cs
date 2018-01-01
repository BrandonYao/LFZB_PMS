using System;
using System.Collections.Generic;
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
    /// WinUser.xaml 的交互逻辑
    /// </summary>
    public partial class WinUser : Window
    {
        public WinUser()
        {
            InitializeComponent();
        }
        public class UserClass
        {
            /// <summary>
            /// 用户账号
            /// </summary>
            public string UserCode { get; set; }
            /// <summary>
            /// 用户名称
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 用户状态
            /// </summary>
            public string UserState { get; set; }
            /// <summary>
            /// 是否修改
            /// </summary>
            public bool IsDirty { get; set; }
        }
    }
}
