using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Line
    {
        private int     _number;
        private int     _length;
        private string  _destination1;
        private string  _destination2;
        private string  _firststop;
        private string  _laststop;
        private int     _actualdriver;
        private int     _actualbus;

        public Line(int number, int lenght, string destination1, string destination2, string firststop, string laststop, int actualdriver, int actualbus)
        {
            _number = number;
            _length = lenght;
            _destination1 = destination1;
            _destination2 = destination2;
            _firststop = firststop;
            _laststop = laststop;
            _actualdriver = actualdriver;
            _actualbus = actualbus;
        }

        public Line()
        {
            _number = -1;
            _length = -1;
            _destination1 = null;
            _destination2 = null;
            _firststop = null;
            _laststop = null;
            _actualdriver = -1;
            _actualbus = -1;
        }
    }
}
