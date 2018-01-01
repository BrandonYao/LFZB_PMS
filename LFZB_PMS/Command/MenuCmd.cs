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
        //供应商维护
        public static RoutedUICommand cmd_menu_gyswh { get; }
        //分销商维护
        public static RoutedUICommand cmd_menu_fxswh { get; }
        //首饰品牌维护
        public static RoutedUICommand cmd_menu_ssppwh { get; }
        //成色名称维护
        public static RoutedUICommand cmd_menu_csmcwh { get; }
        //宝石名称维护
        public static RoutedUICommand cmd_menu_bsmcwh { get; }
        //宝石属性维护
        public static RoutedUICommand cmd_menu_bssxwh { get; }
        //首饰名称维护
        public static RoutedUICommand cmd_menu_ssmcwh { get; }
        //总库库位维护
        public static RoutedUICommand cmd_menu_zkkwwh { get; }
        //分销柜组维护
        public static RoutedUICommand cmd_menu_fxgzwh { get; }
        //系统人员维护
        public static RoutedUICommand cmd_menu_xtrywh { get; }

        //销售提成设置
        public static RoutedUICommand cmd_menu_xstcsz { get; }
        //销售默认折扣
        public static RoutedUICommand cmd_menu_xsmrzk { get; }
        //收银班组维护
        public static RoutedUICommand cmd_menu_sybzwh { get; }
        //促销优惠项目
        public static RoutedUICommand cmd_menu_cxyhxm { get; }
        //收银方式维护
        public static RoutedUICommand cmd_menu_syfswh { get; }
        //销售销退属性
        public static RoutedUICommand cmd_menu_xsxtsx { get; }
        //首饰临时拍照
        public static RoutedUICommand cmd_menu_sslspz { get; }
        //首饰图片维护
        public static RoutedUICommand cmd_menu_sstpwh { get; }
        //首饰图片下载
        public static RoutedUICommand cmd_menu_sstpxz { get; }
        //销售回收金价
        public static RoutedUICommand cmd_menu_xshsjj { get; }

        //宝石单价设置
        public static RoutedUICommand cmd_menu_bsdjsz { get; }
        //售货员维护
        public static RoutedUICommand cmd_menu_shywh { get; }
        #endregion

        #region 主库管理
        //首饰入库单
        public static RoutedUICommand cmd_menu_ssrkd { get; }
        //首饰退库单
        public static RoutedUICommand cmd_menu_sstkd { get; }
        //总库旧料退库
        public static RoutedUICommand cmd_menu_zkjltk { get; }
        //总库数据修改
        public static RoutedUICommand cmd_menu_zksjxg { get; }
        //首饰大类修改
        public static RoutedUICommand cmd_menu_ssdlxg { get; }
        //自由格式标签打印
        public static RoutedUICommand cmd_menu_zygsbqdy { get; }
        //首饰操作一览表
        public static RoutedUICommand cmd_menu_ssczylb { get; }
        //首饰明细一览表
        public static RoutedUICommand cmd_menu_ssmxylb { get; }
        //首饰入库明细表
        public static RoutedUICommand cmd_menu_ssrkmxb { get; }
        //首饰入库统计表
        public static RoutedUICommand cmd_menu_ssrktjb { get; }

        //总库修改明细表
        public static RoutedUICommand cmd_menu_zkxgmxb { get; }
        //总库修改统计表
        public static RoutedUICommand cmd_menu_zkxgtjb { get; }
        //旧料退库明细表
        public static RoutedUICommand cmd_menu_jltkmxb { get; }
        //旧料退库统计表
        public static RoutedUICommand cmd_menu_jltktjb { get; }
        //总库旧料库存表
        public static RoutedUICommand cmd_menu_zkjlkcb { get; }
        //总库库存明细表
        public static RoutedUICommand cmd_menu_zkkcmxb { get; }
        //总库库存统计表
        public static RoutedUICommand cmd_menu_zkkctjb { get; }
        //总库进销存汇总表
        public static RoutedUICommand cmd_menu_zkjxchzb { get; }
        #endregion

        #region 分销管理
        //分销进货单
        public static RoutedUICommand cmd_menu_fxjhd { get; }
        //分销退货单
        public static RoutedUICommand cmd_menu_fxthd { get; }
        //分销调拨单
        public static RoutedUICommand cmd_menu_fxtbd { get; }
        //分销调柜单
        public static RoutedUICommand cmd_menu_fxtgd { get; }
        //分销旧料回仓
        public static RoutedUICommand cmd_menu_fxjlhc { get; }
        //分销数据修改
        public static RoutedUICommand cmd_menu_fxsjxg { get; }
        //分销库存盘点
        public static RoutedUICommand cmd_menu_fxkcpd { get; }
        //分销进货明细表
        public static RoutedUICommand cmd_menu_fxjhmxb { get; }
        //分销进货统计表
        public static RoutedUICommand cmd_menu_fxjhtjb { get; }
        //分销调柜明细表
        public static RoutedUICommand cmd_menu_fxtgmxb { get; }

        //分销调退明细表
        public static RoutedUICommand cmd_menu_fxttmxb { get; }
        //分销调退统计表
        public static RoutedUICommand cmd_menu_fxtttjb { get; }
        //分销修改明细表
        public static RoutedUICommand cmd_menu_fxxgmxb { get; }
        //分销修改统计表
        public static RoutedUICommand cmd_menu_fxxgtjb { get; }
        //旧料回仓明细表
        public static RoutedUICommand cmd_menu_jlhcmxb { get; }
        //旧料回仓统计表
        public static RoutedUICommand cmd_menu_jlhctjb { get; }
        //分销旧料库存表
        public static RoutedUICommand cmd_menu_fxjlkcb { get; }
        //分销旧料收退存
        public static RoutedUICommand cmd_menu_fxjlstc { get; }
        //分销库存明细表
        public static RoutedUICommand cmd_menu_fxkcmxb { get; }
        //分销库存统计表
        public static RoutedUICommand cmd_menu_fxkctjb { get; }
        //分销商进销存汇总
        public static RoutedUICommand cmd_menu_fxsjxchz { get; }
        #endregion

        #region 销售管理
        //首饰销售单
        public static RoutedUICommand cmd_menu_ssxsd { get; }
        //首饰销退单
        public static RoutedUICommand cmd_menu_ssxtd { get; }
        //销售截金单
        public static RoutedUICommand cmd_menu_xsjjd { get; }
        //销售定金单
        public static RoutedUICommand cmd_menu_xsdjd { get; }
        //分销收银汇总表
        public static RoutedUICommand cmd_menu_fxsyhzb { get; }
        //首饰销售明细表
        public static RoutedUICommand cmd_menu_ssxsmxb { get; }
        //首饰销售统计表
        public static RoutedUICommand cmd_menu_ssxstjb { get; }
        //首饰销退明细表
        public static RoutedUICommand cmd_menu_ssxtmxb { get; }
        //首饰销退统计表
        public static RoutedUICommand cmd_menu_ssxttjb { get; }
        //旧料回收明细表
        public static RoutedUICommand cmd_menu_jlhsmxb { get; }

        //旧料回收统计表
        public static RoutedUICommand cmd_menu_jlhstjb { get; }
        //会员购物统计表
        public static RoutedUICommand cmd_menu_hygwtjb { get; }
        //会员退货统计表
        public static RoutedUICommand cmd_menu_hythtjb { get; }
        #endregion

        #region 会员管理
        //客户会员维护
        public static RoutedUICommand cmd_menu_khhywh { get; }
        //客户短信平台
        public static RoutedUICommand cmd_menu_khdxpt { get; }
        //积分兑换登记
        public static RoutedUICommand cmd_menu_jfdhdj { get; }
        //客户服务登记
        public static RoutedUICommand cmd_menu_khfwdj { get; }
        //客户回访登记
        public static RoutedUICommand cmd_menu_khhfdj { get; }
        //客户会员登记
        public static RoutedUICommand cmd_menu_khhydj { get; }
        //积分兑换查询
        public static RoutedUICommand cmd_menu_jfdhcx { get; }
        //基本资料维护
        public static RoutedUICommand cmd_menu_jbzlwh { get; }
        //会员登记设置
        public static RoutedUICommand cmd_menu_hydjsz { get; }
        //大类积分设置
        public static RoutedUICommand cmd_menu_dljfsz { get; }

        //首饰积分设置
        public static RoutedUICommand cmd_menu_ssjfsz { get; }
        //会员优惠设置
        public static RoutedUICommand cmd_menu_hyyhsz { get; }
        //赠品资料维护
        public static RoutedUICommand cmd_menu_zpzlwh { get; }
        //赠品进库单
        public static RoutedUICommand cmd_menu_zpjkd { get; }
        //赠品退库单
        public static RoutedUICommand cmd_menu_zptkd { get; }
        //赠品调拨单
        public static RoutedUICommand cmd_menu_zptbd { get; }
        //赠品退库统计表
        public static RoutedUICommand cmd_menu_zptktjb { get; }
        //赠品调出统计表
        public static RoutedUICommand cmd_menu_zptctjb { get; }
        //赠品调入统计表
        public static RoutedUICommand cmd_menu_zptrtjb { get; }
        //赠品兑换明细表
        public static RoutedUICommand cmd_menu_zpdhmxb { get; }

        //赠品兑换统计表
        public static RoutedUICommand cmd_menu_zpdhtjb { get; }
        //赠品即时库存表
        public static RoutedUICommand cmd_menu_zpjskcb { get; }
        #endregion

        #region 系统维护
        //用户维护
        public static RoutedUICommand cmd_menu_yhwh { get; }
        //用户权限
        public static RoutedUICommand cmd_menu_yhqx { get; }
        //修改密码
        public static RoutedUICommand cmd_menu_xgmm { get; }
        //系统参数
        public static RoutedUICommand cmd_menu_xtcs { get; }
        //本地参数
        public static RoutedUICommand cmd_menu_bdcs { get; }
        #endregion 
        
        #region 帮助
        //关于
        public static RoutedUICommand cmd_menu_gy { get; }
        #endregion

        static MenuCmd()
        {
            //InputGestureCollection inputs = new InputGestureCollection();
            //inputs.Add(new KeyGesture(Key.A, ModifierKeys.Control, "Ctrl+A"));

            #region 基础资料
            cmd_menu_gyswh = new RoutedUICommand("供应商维护", "cmd_menu_gyswh", typeof(MenuCmd));
            cmd_menu_fxswh = new RoutedUICommand("分销商维护", "cmd_menu_fxswh", typeof(MenuCmd));
            cmd_menu_ssppwh = new RoutedUICommand("首饰品牌维护", "cmd_menu_ssppwh", typeof(MenuCmd));
            cmd_menu_csmcwh = new RoutedUICommand("成色名称维护", "cmd_menu_csmcwh", typeof(MenuCmd));
            cmd_menu_bsmcwh = new RoutedUICommand("宝石名称维护", "cmd_menu_bsmcwh", typeof(MenuCmd));
            cmd_menu_bssxwh = new RoutedUICommand("宝石属性维护", "cmd_menu_bssxwh", typeof(MenuCmd));
            cmd_menu_ssmcwh = new RoutedUICommand("首饰名称维护", "cmd_menu_bssxwh", typeof(MenuCmd));
            cmd_menu_zkkwwh = new RoutedUICommand("总库库位维护", "cmd_menu_zkkwwh", typeof(MenuCmd));
            cmd_menu_fxgzwh = new RoutedUICommand("分销柜组维护", "cmd_menu_fxgzwh", typeof(MenuCmd));
            cmd_menu_xtrywh = new RoutedUICommand("系统人员维护", "cmd_menu_xtrywh", typeof(MenuCmd));
            //
            cmd_menu_xstcsz = new RoutedUICommand("销售提成设置", "cmd_menu_xstcsz", typeof(MenuCmd));
            cmd_menu_xsmrzk = new RoutedUICommand("销售默认折扣", "cmd_menu_xsmrzk", typeof(MenuCmd));
            cmd_menu_sybzwh = new RoutedUICommand("收银班组维护", "cmd_menu_sybzwh", typeof(MenuCmd));
            cmd_menu_cxyhxm = new RoutedUICommand("促销优惠项目", "cmd_menu_cxyhxm", typeof(MenuCmd));
            cmd_menu_syfswh = new RoutedUICommand("收银方式维护", "cmd_menu_syfswh", typeof(MenuCmd));
            cmd_menu_xsxtsx = new RoutedUICommand("销售销退属性", "cmd_menu_xsxtsx", typeof(MenuCmd));
            cmd_menu_sslspz = new RoutedUICommand("首饰临时拍照", "cmd_menu_sslspz", typeof(MenuCmd));
            cmd_menu_sstpwh = new RoutedUICommand("首饰图片维护", "cmd_menu_sstpwh", typeof(MenuCmd));
            cmd_menu_sstpxz = new RoutedUICommand("首饰图片下载", "cmd_menu_sstpxz", typeof(MenuCmd));
            cmd_menu_xshsjj = new RoutedUICommand("销售回收金价", "cmd_menu_xshsjj", typeof(MenuCmd));
            //
            cmd_menu_bsdjsz = new RoutedUICommand("宝石单价设置", "cmd_menu_bsdjsz", typeof(MenuCmd));
            cmd_menu_shywh = new RoutedUICommand("售货员维护", "cmd_menu_shywh", typeof(MenuCmd));
            #endregion

            #region 总库管理
            cmd_menu_ssrkd = new RoutedUICommand("首饰入库单", "cmd_menu_ssrkd", typeof(MenuCmd));
            cmd_menu_sstkd = new RoutedUICommand("首饰退库单", "cmd_menu_sstkd", typeof(MenuCmd));
            cmd_menu_zkjltk = new RoutedUICommand("总库旧料退库", "cmd_menu_zkjltk", typeof(MenuCmd));
            cmd_menu_zksjxg = new RoutedUICommand("总库数据修改", "cmd_menu_zksjxg", typeof(MenuCmd));
            cmd_menu_ssdlxg = new RoutedUICommand("首饰大类修改", "cmd_menu_ssdlxg", typeof(MenuCmd));
            cmd_menu_zygsbqdy = new RoutedUICommand("自由格式标签打印", "cmd_menu_zygsbqdy", typeof(MenuCmd));
            cmd_menu_ssczylb = new RoutedUICommand("首饰操作一览表", "cmd_menu_ssczylb", typeof(MenuCmd));
            cmd_menu_ssmxylb = new RoutedUICommand("首饰明细一览表", "cmd_menu_ssmxylb", typeof(MenuCmd));
            cmd_menu_ssrkmxb = new RoutedUICommand("首饰入库明细表", "cmd_menu_ssrkmxb", typeof(MenuCmd));
            cmd_menu_ssrktjb = new RoutedUICommand("首饰入库统计表", "cmd_menu_ssrktjb", typeof(MenuCmd));
            //
            cmd_menu_zkxgmxb = new RoutedUICommand("总库修改明细表", "cmd_menu_zkxgmxb", typeof(MenuCmd));
            cmd_menu_zkxgtjb = new RoutedUICommand("总库修改统计表", "cmd_menu_zkxgtjb", typeof(MenuCmd));
            cmd_menu_jltkmxb = new RoutedUICommand("旧料退库明细表", "cmd_menu_jltkmxb", typeof(MenuCmd));
            cmd_menu_jltktjb = new RoutedUICommand("旧料退库统计表", "cmd_menu_jltktjb", typeof(MenuCmd));
            cmd_menu_zkjlkcb = new RoutedUICommand("总库旧料库存表", "cmd_menu_zkjlkcb", typeof(MenuCmd));
            cmd_menu_zkkcmxb = new RoutedUICommand("总库库存明细表", "cmd_menu_zkkcmxb", typeof(MenuCmd));
            cmd_menu_zkkctjb = new RoutedUICommand("总库库存统计表", "cmd_menu_zkkctjb", typeof(MenuCmd));
            cmd_menu_zkjxchzb = new RoutedUICommand("总库进销存汇总表", "cmd_menu_zkjxchzb", typeof(MenuCmd));
            #endregion

            #region 分销管理
            cmd_menu_fxjhd = new RoutedUICommand("分销进货单", "cmd_menu_fxjhd", typeof(MenuCmd));
            cmd_menu_fxthd = new RoutedUICommand("分销退货单", "cmd_menu_fxthd", typeof(MenuCmd));
            cmd_menu_fxtbd = new RoutedUICommand("分销调拨单", "cmd_menu_fxtbd", typeof(MenuCmd));
            cmd_menu_fxtgd = new RoutedUICommand("分销调柜单", "cmd_menu_fxtgd", typeof(MenuCmd));
            cmd_menu_fxjlhc = new RoutedUICommand("分销旧料回仓", "cmd_menu_fxjlhc", typeof(MenuCmd));
            cmd_menu_fxsjxg = new RoutedUICommand("分销数据修改", "cmd_menu_fxsjxg", typeof(MenuCmd));
            cmd_menu_fxkcpd = new RoutedUICommand("分销库存盘点", "cmd_menu_fxkcpd", typeof(MenuCmd));
            cmd_menu_fxjhmxb = new RoutedUICommand("分销进货明细表", "cmd_menu_fxjhmxb", typeof(MenuCmd));
            cmd_menu_fxjhtjb = new RoutedUICommand("分销进货统计表", "cmd_menu_fxjhtjb", typeof(MenuCmd));
            cmd_menu_fxtgmxb = new RoutedUICommand("分销调柜明细表", "cmd_menu_fxtgmxb", typeof(MenuCmd));

            cmd_menu_fxttmxb = new RoutedUICommand("分销调退明细表", "cmd_menu_fxttmxb", typeof(MenuCmd));
            cmd_menu_fxtttjb = new RoutedUICommand("分销调退统计表", "cmd_menu_fxtttjb", typeof(MenuCmd));
            cmd_menu_fxxgmxb = new RoutedUICommand("分销修改明细表", "cmd_menu_fxxgmxb", typeof(MenuCmd));
            cmd_menu_fxxgtjb = new RoutedUICommand("分销修改统计表", "cmd_menu_fxxgtjb", typeof(MenuCmd));
            cmd_menu_jlhcmxb = new RoutedUICommand("旧料回仓明细表", "cmd_menu_jlhcmxb", typeof(MenuCmd));
            cmd_menu_jlhctjb = new RoutedUICommand("旧料回仓统计表", "cmd_menu_jlhctjb", typeof(MenuCmd));
            cmd_menu_fxjlkcb = new RoutedUICommand("分销旧料库存表", "cmd_menu_fxjlkcb", typeof(MenuCmd));
            cmd_menu_fxjlstc = new RoutedUICommand("分销旧料收退存", "cmd_menu_fxjlstc", typeof(MenuCmd));
            cmd_menu_fxkcmxb = new RoutedUICommand("分销库存明细表", "cmd_menu_fxkcmxb", typeof(MenuCmd));
            cmd_menu_fxkctjb = new RoutedUICommand("分销库存统计表", "cmd_menu_fxkctjb", typeof(MenuCmd));

            cmd_menu_fxsjxchz = new RoutedUICommand("分销商进销存汇总", "cmd_menu_fxsjxchz", typeof(MenuCmd));
            #endregion
            
            #region 销售管理
            cmd_menu_ssxsd = new RoutedUICommand("首饰销售单", "cmd_menu_ssxsd", typeof(MenuCmd));
            cmd_menu_ssxtd = new RoutedUICommand("首饰销退单", "cmd_menu_ssxtd", typeof(MenuCmd));
            cmd_menu_xsjjd = new RoutedUICommand("销售截金单", "cmd_menu_xsjjd", typeof(MenuCmd));
            cmd_menu_xsdjd = new RoutedUICommand("销售定金单", "cmd_menu_xsdjd", typeof(MenuCmd));
            cmd_menu_fxsyhzb = new RoutedUICommand("分销收银汇总表", "cmd_menu_fxsyhzb", typeof(MenuCmd));
            cmd_menu_ssxsmxb = new RoutedUICommand("首饰销售明细表", "cmd_menu_ssxsmxb", typeof(MenuCmd));
            cmd_menu_ssxstjb = new RoutedUICommand("首饰销售统计表", "cmd_menu_ssxstjb", typeof(MenuCmd));
            cmd_menu_ssxtmxb = new RoutedUICommand("首饰销退明细表", "cmd_menu_ssxtmxb", typeof(MenuCmd));
            cmd_menu_ssxttjb = new RoutedUICommand("首饰销退统计表", "cmd_menu_ssxttjb", typeof(MenuCmd));
            cmd_menu_jlhsmxb = new RoutedUICommand("旧料回收明细表", "cmd_menu_jlhsmxb", typeof(MenuCmd));
            //
            cmd_menu_jlhstjb = new RoutedUICommand("旧料回收统计表", "cmd_menu_jlhstjb", typeof(MenuCmd));
            cmd_menu_hygwtjb = new RoutedUICommand("会员购物统计表", "cmd_menu_hygwtjb", typeof(MenuCmd));
            cmd_menu_hythtjb = new RoutedUICommand("会员退货统计表", "cmd_menu_hythtjb", typeof(MenuCmd));
            #endregion

            #region 会员管理
            cmd_menu_khhywh = new RoutedUICommand("客户会员维护", "cmd_menu_gyswh", typeof(MenuCmd));
            cmd_menu_khdxpt = new RoutedUICommand("客户短信平台", "cmd_menu_khdxpt", typeof(MenuCmd));
            cmd_menu_jfdhdj = new RoutedUICommand("积分兑换登记", "cmd_menu_jfdhdj", typeof(MenuCmd));
            cmd_menu_khfwdj = new RoutedUICommand("客户服务登记", "cmd_menu_khfwdj", typeof(MenuCmd));
            cmd_menu_khhfdj = new RoutedUICommand("客户回访登记", "cmd_menu_khhfdj", typeof(MenuCmd));
            cmd_menu_khhydj = new RoutedUICommand("客户会员登记", "cmd_menu_khhydj", typeof(MenuCmd));
            cmd_menu_jfdhcx = new RoutedUICommand("积分兑换查询", "cmd_menu_jfdhcx", typeof(MenuCmd));
            cmd_menu_jbzlwh = new RoutedUICommand("基本资料维护", "cmd_menu_jbzlwh", typeof(MenuCmd));
            cmd_menu_hydjsz = new RoutedUICommand("会员等级设置", "cmd_menu_hydjsz", typeof(MenuCmd));
            cmd_menu_dljfsz = new RoutedUICommand("大类积分设置", "cmd_menu_dljfsz", typeof(MenuCmd));
            //
            cmd_menu_ssjfsz = new RoutedUICommand("首饰积分设置", "cmd_menu_ssjfsz", typeof(MenuCmd));
            cmd_menu_hyyhsz = new RoutedUICommand("会员优惠设置", "cmd_menu_hyyhsz", typeof(MenuCmd));
            cmd_menu_zpzlwh = new RoutedUICommand("赠品资料维护", "cmd_menu_zpzlwh", typeof(MenuCmd));
            cmd_menu_zpjkd = new RoutedUICommand("赠品进库单", "cmd_menu_zpjkd", typeof(MenuCmd));
            cmd_menu_zptkd = new RoutedUICommand("赠品退库单", "cmd_menu_zptkd", typeof(MenuCmd));
            cmd_menu_zptbd = new RoutedUICommand("赠品调拨单", "cmd_menu_zptbd", typeof(MenuCmd));
            cmd_menu_zptktjb = new RoutedUICommand("赠品退库统计表", "cmd_menu_zptktjb", typeof(MenuCmd));
            cmd_menu_zptctjb = new RoutedUICommand("赠品调出统计表", "cmd_menu_zptctjb", typeof(MenuCmd));
            cmd_menu_zptrtjb = new RoutedUICommand("赠品调入统计表", "cmd_menu_zptrtjb", typeof(MenuCmd));
            cmd_menu_zpdhmxb = new RoutedUICommand("赠品兑换明细表", "cmd_menu_zpdhmxb", typeof(MenuCmd));
            //
            cmd_menu_zpdhtjb = new RoutedUICommand("赠品兑换统计表", "cmd_menu_zpdhtjb", typeof(MenuCmd));
            cmd_menu_zpjskcb = new RoutedUICommand("赠品即时库存表", "cmd_menu_zpjskcb", typeof(MenuCmd));
            #endregion

            #region 系统维护
            cmd_menu_yhwh = new RoutedUICommand("用户维护", "cmd_menu_yhwh", typeof(MenuCmd));
            cmd_menu_yhqx = new RoutedUICommand("用户权限", "cmd_menu_yhqx", typeof(MenuCmd));
            cmd_menu_xgmm = new RoutedUICommand("修改密码", "cmd_menu_xgmm", typeof(MenuCmd));
            cmd_menu_xtcs = new RoutedUICommand("系统参数", "cmd_menu_xtcs", typeof(MenuCmd));
            cmd_menu_bdcs = new RoutedUICommand("本地参数", "cmd_menu_bdcs", typeof(MenuCmd));
            #endregion

            #region 帮助
            cmd_menu_gy = new RoutedUICommand("关于", "cmd_menu_gy", typeof(MenuCmd));
            #endregion
        }
    }
}
