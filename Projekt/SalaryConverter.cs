using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Projekt
{
    class SalaryConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double salary = (double)value*100/123;
            return salary.ToString("C");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string salary = value.ToString();
            double result;
            if (Double.TryParse(salary, NumberStyles.Any, culture, out result))
            {
                return result + 0.23 * result;
            }
            return value;
        }
    }
}
