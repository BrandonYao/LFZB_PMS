using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LFZB_PMS.Command
{
    public class MenuCmd
    {
        #region 基础资料
        private static RoutedUICommand cmd_menu_fdsz;
        public static RoutedUICommand Cmd_Menu_fdsz { get { return cmd_menu_fdsz; } }
        #endregion

        #region 主库管理
        private static RoutedUICommand cmd_menu_ssrkd;
        public static RoutedUICommand Cmd_Menu_ssrkd { get { return cmd_menu_ssrkd; } }
        #endregion
        static MenuCmd()
        {
            //InputGestureCollection inputs = new InputGestureCollection();
            //inputs.Add(new KeyGesture(Key.A, ModifierKeys.Control, "Ctrl+A"));

            cmd_menu_fdsz = new RoutedUICommand("分店设置", "cmd_menu_fdsz", typeof(MenuCmd));

            cmd_menu_ssrkd = new RoutedUICommand("首饰入库单", "cmd_menu_ssrkd", typeof(MenuCmd));
        }
    }
}
