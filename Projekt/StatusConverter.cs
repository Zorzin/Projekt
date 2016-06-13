using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Projekt
{
    class StatusConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            switch (val)
            {
                case "active":
                    return "aktywny";
                    break;
                case "inactive":
                    return "nieaktywny";
                    break;
                case "leave":
                    return "urlop";
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
                case "aktywny":
                    return "active";
                    break;
                case "nieaktywny":
                    return "inactive";
                    break;
                case "urlop":
                    return "leave";
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
