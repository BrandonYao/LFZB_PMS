﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using static LFZB_PMS.DAL.GYSDAL;

namespace LFZB_PMS
{
    public sealed class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            int val = System.Convert.ToInt32(value);
            return val > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            return ((bool)value) ? 1 : 0;
        }
    }

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
            }
            return new SolidColorBrush(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
