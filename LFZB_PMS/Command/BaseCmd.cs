using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LFZB_PMS.Command
{
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
        public static RoutedUICommand cmd_export { get{ return cmd_export2; } }
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
