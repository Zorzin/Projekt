using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Projekt
{
    class LineConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Line line = (Line) value;
                return line.Number;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string) value;
            if(string.IsNullOrEmpty(val) || Int32.Parse(val)<=0)
            {
                return null;
            }
            int number = Int32.Parse(val);
            try
            {
                return Lists.Lines.First(x => x.Number == number);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
