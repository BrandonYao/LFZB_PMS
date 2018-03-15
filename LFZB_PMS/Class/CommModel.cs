using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFZB_PMS
{
    public class CommModel
    {
        public class SearchItem
        {
            public string Column { get; set; }
            public string Text { get; set; }
        }
        public class OrderTitle
        {
            /// <summary>
            /// 1：入库 -1：出库
            /// </summary>
            public int IOType { get; set; }
            /// <summary>
            /// 单据号
            /// </summary>
            public string OrderCode { get; set; }
            /// <summary>
            /// 单据时间
            /// </summary>
            public DateTime OrderDate { get; set; }
        }
        public class OrderMaster
        {
            public OrderTitle orderTitle { get; set; }
            public int OrderType { get; set; }
            public string OrderTypeText { get; set; }
            public int SSMCCode { get; set; }
            public string SSMCName { get; set; }
            public int GYSCode { get; set; }
            public string GYSName { get; set; }
            public int Count { get; set; }
            public int FXSCode { get; set; }
            public string FXSName { get; set; }
            public int ZKKWCode { get; set; }
            public string ZKKWName { get; set; }
            public int State { get; set; }
            public string StateText { get; set; }
            public string BZ { get; set; }
            public string CreateUserCode { get; set; }
            public string CreateUserName { get; set; }
            public DateTime CreateDate { get; set; }
            public string ConfirmUserCode { get; set; }
            public string ConfirmUserName { get; set; }
            public DateTime ConfirmDate { get; set; }
            public string CheckUserCode { get; set; }
            public string CheckUserName { get; set; }
            public DateTime CheckDate { get; set; }
        }

        public class OrderDetails
        {
            public string OrderCode { get; set; }
            public string Barcode { get; set; }
            public int SSMCCode { get; set; }
            public string SSMCName { get; set; }
            public int State { get; set; }
            public string StateText { get; set; }
            public string CJKH { get; set; }
            public string ZSH { get; set; }
            public float JJZ { get; set; }
            public string PJ { get; set; }
            public float ZJZ { get; set; }
            public int SC { get; set; }
            public float ZS { get; set; }
            public int XZ { get; set; }
            public int YS { get; set; }
            public int JD { get; set; }
            public int QG { get; set; }
            public float FS { get; set; }
            public float SJ { get; set; }
            public int FXSCode { get; set; }
            public string FXSName { get; set; }
        }
    }
}
