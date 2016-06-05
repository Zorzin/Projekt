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
    class ActualTrackConverter:IMultiValueConverter
    {
        public Brush Actual { get; set; }
        public Brush NotActual { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime start = (DateTime)values[0];
            DateTime end = (DateTime) values[1];
            if (start < DateTime.Now && end > DateTime.Now)
            {
                return Actual;
            }
            return NotActual;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
