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
    class DriverBorderConverter:IValueConverter
    {
        public Brush ActiveBrush { get; set; }
        public Brush InactiveBrush { get; set; }
        public Brush LeaveBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "active":
                    return ActiveBrush;
                    break;
                case "inactive":
                    return InactiveBrush;
                    break;
                case "leave":
                    return LeaveBrush;
                    break;
                default:
                    return Brushes.Black;
                    break;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
