using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Projekt
{
    class DriverConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null)
            {
                Driver d = (Driver) value;
                return d.Id;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value.ToString()) || Int32.Parse(value.ToString()) <= 0)
            {
                return null;
            }
            int number = Int32.Parse(value.ToString());
            return Lists.Drivers.First(x => x.Id == number);
        }
    }
}
