using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Projekt
{
    class TypeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            switch (val)
            {
                case "big":
                    return "duży";
                    break;
                case "small":
                    return "mały";
                    break;
                default:
                    return null;
                    break;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            switch (val)
            {
                case "duży":
                    return "big";
                    break;
                case "mały":
                    return "small";
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
