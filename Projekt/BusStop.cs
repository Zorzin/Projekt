using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class BusStop
    {
        private int     _id;
        private string  _name;
        private int     _area;

        public BusStop(int id, string name, int area)
        {
            _id = id;
            _name = name;
            _area = area;
        }
    }
}
