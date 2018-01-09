using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using static LFZB_PMS.DAL.FXSDAL;
using static LFZB_PMS.DAL.GYSDAL;
using static LFZB_PMS.DAL.SSPPDAL;

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
                    GYSClass gys = value as GYSClass;
                    if (gys.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.FXSDAL+FXSClass":
                    FXSClass fxs = value as FXSClass;
                    if (fxs.IsDirty) c = Colors.LightCoral;
                    else c = Colors.LightGreen;
                    break;
                case "LFZB_PMS.DAL.SSPPDAL+SSPPClass":
                    SSPPClass sspp = value as SSPPClass;
                    if (sspp.IsDirty) c = Colors.LightCoral;
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
