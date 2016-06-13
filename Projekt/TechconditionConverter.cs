using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Projekt
{
    class TechconditionConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            switch (val)
            {
                case "good":
                    return "działający";
                    break;
                case "bad":
                    return "zepsuty";
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
                case "działający":
                    return "good";
                    break;
                case "zepsuty":
                    return "bad";
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
