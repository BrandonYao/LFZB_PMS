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
        }
        public class OrderMaster
        {
            /// <summary>
            /// 单据号
            /// </summary>
            public string OrderCode { get; set; }
            /// <summary>
            /// 单据日期
            /// </summary>
            public DateTime OrderDate { get; set; }
            /// <summary>
            /// 单据类型编号
            /// </summary>
            public int OrderTypeCode { get; set; }
            /// <summary>
            /// 单据类型名称
            /// </summary>
            public string OrderTypeText { get; set; }
            /// <summary>
            /// 首饰大类编号
            /// </summary>
            public int SSDLode { get; set; }
            /// <summary>
            /// 首饰大类名称
            /// </summary>
            public string SSDLName { get; set; }
            /// <summary>
            /// 供应商编号
            /// </summary>
            public int GYSCode { get; set; }
            /// <summary>
            /// 供应商名称
            /// </summary>
            public string GYSName { get; set; }
            /// <summary>
            /// 件数
            /// </summary>
            public int Count { get; set; }
            /// <summary>
            /// 计划分销商编号
            /// </summary>
            public int PlanFXSCode { get; set; }
            /// <summary>
            /// 计划分销商名称
            /// </summary>
            public string PlanFXSName { get; set; }
            /// <summary>
            /// 总库库位编号
            /// </summary>
            public int ZKKWCode { get; set; }
            /// <summary>
            /// 总库库位名称
            /// </summary>
            public string ZKKWName { get; set; }
            /// <summary>
            /// 状态编号
            /// </summary>
            public int State { get; set; }
            /// <summary>
            /// 状态名称
            /// </summary>
            public string StateText { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string BZ { get; set; }
            /// <summary>
            /// 制单人编号
            /// </summary>
            public string CreateUserCode { get; set; }
            /// <summary>
            /// 制单人名称
            /// </summary>
            public string CreateUserName { get; set; }
            /// <summary>
            /// 制单时间
            /// </summary>
            public DateTime CreateTime { get; set; }
            /// <summary>
            /// 确认人编号
            /// </summary>
            public string ConfirmUserCode { get; set; }
            /// <summary>
            /// 确认人名称
            /// </summary>
            public string ConfirmUserName { get; set; }
            /// <summary>
            /// 确认时间
            /// </summary>
            public DateTime ConfirmTime { get; set; }
            /// <summary>
            /// 审核人编号
            /// </summary>
            public string CheckUserCode { get; set; }
            /// <summary>
            /// 审核人名称
            /// </summary>
            public string CheckUserName { get; set; }
            /// <summary>
            /// 审核时间
            /// </summary>
            public DateTime CheckTime { get; set; }
            /// <summary>
            /// 采购人编号
            /// </summary>
            public string BuyPersonCode { get; set; }
            /// <summary>
            /// 采购人名称
            /// </summary>
            public string BuyPersonName { get; set; }
            /// <summary>
            /// 采购订单
            /// </summary>
            public string BuyOrderCode { get; set; }
        }

        public class OrderDetails
        {
            /// <summary>
            /// 单据号
            /// </summary>
            public string OrderCode { get; set; }
            /// <summary>
            /// 商品条码
            /// </summary>
            public string Barcode { get; set; }
            /// <summary>
            /// 首饰名称编号
            /// </summary>
            public int SSMCCode { get; set; }
            /// <summary>
            /// 首饰名称
            /// </summary>
            public string SSMCName { get; set; }
            /// <summary>
            /// 状态编号
            /// </summary>
            public int State { get; set; }
            //状态名称
            public string StateText { get; set; }
            /// <summary>
            /// 厂家款号
            /// </summary>
            public string CJKH { get; set; }
            /// <summary>
            /// 证书号
            /// </summary>
            public string ZSH { get; set; }
            /// <summary>
            /// 证书费
            /// </summary>
            public float ZSF { get; set; }
            /// <summary>
            /// 净金重
            /// </summary>
            public float JJZ { get; set; }
            /// <summary>
            /// 金价
            /// </summary>
            public float JJ { get; set; }
            /// <summary>
            /// 金耗
            /// </summary>
            public float JH { get; set; }
            /// <summary>
            /// 配件
            /// </summary>
            public string PJ { get; set; }
            /// <summary>
            /// 总金重
            /// </summary>
            public float ZJZ { get; set; }
            /// <summary>
            /// 手寸
            /// </summary>
            public int SC { get; set; }
            /// <summary>
            /// 主石石号
            /// </summary>
            public float ZSCode { get; set; }
            /// <summary>
            /// 主石计价
            /// </summary>
            public float ZSJJ { get; set; }
            /// <summary>
            /// 主石重
            /// </summary>
            public float ZSZ { get; set; }
            /// <summary>
            /// 主石粒数
            /// </summary>
            public float ZSLS { get; set; }
            /// <summary>
            /// 主石单价
            /// </summary>
            public float ZSDJ { get; set; }
            /// <summary>
            /// 形状
            /// </summary>
            public int XZ { get; set; }
            /// <summary>
            /// 颜色
            /// </summary>
            public int YS { get; set; }
            /// <summary>
            /// 净度
            /// </summary>
            public int JD { get; set; }
            /// <summary>
            /// 切工
            /// </summary>
            public int QG { get; set; }
            /// <summary>
            /// 副石1石号
            /// </summary>
            public float FS1Code { get; set; }
            /// <summary>
            /// 副石1计价
            /// </summary>
            public float FS1JJ { get; set; }
            /// <summary>
            /// 副石1重
            /// </summary>
            public float FS1Z { get; set; }
            /// <summary>
            /// 副石1粒数
            /// </summary>
            public float FS1LS { get; set; }
            /// <summary>
            /// 副石1单价
            /// </summary>
            public float FS1DJ { get; set; }
            /// <summary>
            /// 副石2石号
            /// </summary>
            public float FS2Code { get; set; }
            /// <summary>
            /// 副石2计价
            /// </summary>
            public float FS2JJ { get; set; }
            /// <summary>
            /// 副石2重
            /// </summary>
            public float FS2Z { get; set; }
            /// <summary>
            /// 副石2粒数
            /// </summary>
            public float FS2LS { get; set; }
            /// <summary>
            /// 副石2单价
            /// </summary>
            public float FS2DJ { get; set; }
            /// <summary>
            /// 加工费
            /// </summary>
            public float JGF { get; set; }
            /// <summary>
            /// 进货成本
            /// </summary>
            public float JHCB { get; set; }
            /// <summary>
            /// 售价成本
            /// </summary>
            public float SJCB { get; set; }
            /// <summary>
            /// 销售倍率
            /// </summary>
            public float XSBL { get; set; }
            /// <summary>
            /// 售价
            /// </summary>
            public float SJ { get; set; }
            /// <summary>
            /// 当前分销商编号
            /// </summary>
            public int NowFXSCode { get; set; }
            /// <summary>
            /// 当前分销商名称
            /// </summary>
            public string NowFXSName { get; set; }
        }
    }
}
