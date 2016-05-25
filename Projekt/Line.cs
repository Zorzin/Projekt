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
        public int     Length;
        public string  Destination1;
        public string  Destination2;
        public string  Firststop;
        public string  Laststop;
        public int     Actualdriver;
        public int     Actualbus;

        public Line(int number, int lenght, string destination1, string destination2, string firststop, string laststop, int actualdriver, int actualbus)
        {
            Number = number;
            Length = lenght;
            Destination1 = destination1;
            Destination2 = destination2;
            Firststop = firststop;
            Laststop = laststop;
            Actualdriver = actualdriver;
            Actualbus = actualbus;
        }

        public Line()
        {
            Number = -1;
            Length = -1;
            Destination1 = null;
            Destination2 = null;
            Firststop = null;
            Laststop = null;
            Actualdriver = -1;
            Actualbus = -1;
        }
    }
}
