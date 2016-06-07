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
            var dt = DateTime.Now;
            dt = dt.AddMilliseconds(-dt.Millisecond);
            dt = dt.AddSeconds(-dt.Second);
            dt = dt.AddTicks(-dt.Ticks % 10000000);
            if (start <= dt && end >= dt)
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
