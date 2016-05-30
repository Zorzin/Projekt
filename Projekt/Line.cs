using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Line
    {
        public int      Number          { get; set; }
        public double   Length          { get; set; }
        public BusStop  Firststop       { get; set; }
        public BusStop  Laststop        { get; set; }
        public Driver   Actualdriver    { get; set; }
        public Bus      Actualbus       { get; set; }

        public Line(int number, double lenght, BusStop firststop, BusStop laststop, Driver actualdriver, Bus actualbus)
        {
            Number = number;
            Length = lenght;
            Firststop = firststop;
            Laststop = laststop;
            Actualdriver = actualdriver;
            Actualbus = actualbus;
        }

        public Line()
        {
            Number = -1;
            Length = -1;
            Firststop = null;
            Laststop = null;
            Actualdriver = null;
            Actualbus = null;
        }
    }
}
