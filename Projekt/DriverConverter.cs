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
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }
            else if (Int32.Parse(value.ToString()) <= 0)
            {
                return null;
            }
            int number = Int32.Parse(value.ToString());
            try
            {
                return Lists.Drivers.First(x => x.Id == number);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
