using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LFZB_PMS
{
    public sealed class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color c = Colors.Transparent;
            string t = value.GetType().ToString();
            switch (t)
            {
                case "LFZB_PMS.DAL.GYSDAL+GYSClass":
                    DAL.GYSDAL.GYSClass gys = value as DAL.GYSDAL.GYSClass;
                    if (gys.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.FXSDAL+FXSClass":
                    DAL.FXSDAL.FXSClass fxs = value as DAL.FXSDAL.FXSClass;
                    if (fxs.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.SSPPDAL+SSPPClass":
                    DAL.SSPPDAL.SSPPClass sspp = value as DAL.SSPPDAL.SSPPClass;
                    if (sspp.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.BSMCDAL+BSMCClass":
                    DAL.BSMCDAL.BSMCClass bsmc = value as DAL.BSMCDAL.BSMCClass;
                    if (bsmc.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.BSSXDAL+BSSXClass":
                    DAL.BSSXDAL.BSSXClass bssx = value as DAL.BSSXDAL.BSSXClass;
                    if (bssx.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.SSMCDAL+SSMCClass":
                    DAL.SSMCDAL.SSMCClass ssmc = value as DAL.SSMCDAL.SSMCClass;
                    if (ssmc.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.ZKKWDAL+ZKKWClass":
                    DAL.ZKKWDAL.ZKKWClass zkkw = value as DAL.ZKKWDAL.ZKKWClass;
                    if (zkkw.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.FXGZDAL+FXGZClass":
                    DAL.FXGZDAL.FXGZClass fxgz = value as DAL.FXGZDAL.FXGZClass;
                    if (fxgz.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.SYBZDAL+SYBZClass":
                    DAL.SYBZDAL.SYBZClass sybz = value as DAL.SYBZDAL.SYBZClass;
                    if (sybz.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.YHXMDAL+YHXMClass":
                    DAL.YHXMDAL.YHXMClass yhxm = value as DAL.YHXMDAL.YHXMClass;
                    if (yhxm.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.SYFSDAL+SYFSClass":
                    DAL.SYFSDAL.SYFSClass syfs = value as DAL.SYFSDAL.SYFSClass;
                    if (syfs.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.XSXTSXDAL+XSXTSXClass":
                    DAL.XSXTSXDAL.XSXTSXClass xsxt = value as DAL.XSXTSXDAL.XSXTSXClass;
                    if (xsxt.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
            }
            return new SolidColorBrush(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
