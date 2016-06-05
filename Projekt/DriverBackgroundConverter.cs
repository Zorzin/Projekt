using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Projekt
{
    class DriverBackgroundConverter:IValueConverter
    {
        public Brush FreeBrush { get; set; }
        public Brush BusyBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Bus bus = (Bus) value;
            if (bus == null)
            {
                return FreeBrush;
            }
            return BusyBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
