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
        public static RoutedUICommand cmd_search { get; }
        public static RoutedUICommand cmd_refresh { get; }
        public static RoutedUICommand cmd_add { get; }
        public static RoutedUICommand cmd_edit { get; }
        public static RoutedUICommand cmd_del { get; }
        public static RoutedUICommand cmd_cancle { get; }
        public static RoutedUICommand cmd_save { get; }
        public static RoutedUICommand cmd_print { get; }
        public static RoutedUICommand cmd_export { get; }
        public static RoutedUICommand cmd_close { get; }

        static BaseCmd()
        {
            cmd_search = new RoutedUICommand("查找", "cmd_search", typeof(BaseCmd));
            cmd_refresh = new RoutedUICommand("刷新", "cmd_refresh", typeof(BaseCmd));
            cmd_add = new RoutedUICommand("新增", "cmd_add", typeof(BaseCmd));
            cmd_edit = new RoutedUICommand("修改", "cmd_edit", typeof(BaseCmd));
            cmd_del = new RoutedUICommand("删除", "cmd_del", typeof(BaseCmd));
            cmd_cancle = new RoutedUICommand("取消", "cmd_cancle", typeof(BaseCmd));
            cmd_save = new RoutedUICommand("保存", "cmd_save", typeof(BaseCmd));
            cmd_print = new RoutedUICommand("打印", "cmd_print", typeof(BaseCmd));
            cmd_export = new RoutedUICommand("导出Excel", "cmd_export", typeof(BaseCmd));
            cmd_close = new RoutedUICommand("关闭", "cmd_close", typeof(BaseCmd));
        }
    }
}
