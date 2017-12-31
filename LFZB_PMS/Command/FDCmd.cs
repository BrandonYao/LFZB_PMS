using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LFZB_PMS.Command
{
    public class FDCmd
    {
        private static RoutedUICommand cmd_fd_add;
        public static RoutedUICommand Cmd_FD_Add { get { return cmd_fd_add; } }

        private static RoutedUICommand cmd_fd_del;
        public static RoutedUICommand Cmd_FD_Del { get { return cmd_fd_del; } }

        static FDCmd()
        {
            cmd_fd_add = new RoutedUICommand("新增", "cmd_fd_add", typeof(FDCmd));
            cmd_fd_del = new RoutedUICommand("删除", "cmd_fd_del", typeof(FDCmd));
        }
    }
}
