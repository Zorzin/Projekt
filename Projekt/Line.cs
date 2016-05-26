using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Line
    {
        public int     Number;
        public double     Length;
        public string  Firststop;
        public string  Laststop;
        public int     Actualdriver;
        public int     Actualbus;

        public Line(int number, double lenght, string firststop, string laststop, int actualdriver, int actualbus)
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
            Actualdriver = -1;
            Actualbus = -1;
        }
    }
}
