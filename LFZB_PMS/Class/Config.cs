using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS
{
    public class Config
    {
        public class Connection
        {
            public static string Server = "Server=106.14.176.19;Database=lfzb_data;User=lfzb;Password=1234;";
        }

        public class XTSZ
        {
            /// <summary>
            /// 默认显示单据天数
            /// </summary>
            public static int DaysOfOrder;
        }
    }
}
