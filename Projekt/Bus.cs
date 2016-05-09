using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Bus
    {
        private int     _busid;
        private string  _type;
        private int     _actualdriver;
        private int     _actualline;
        private int     _mileage;
        private string  _brand;
        private string  _model;
        private string  _techcondition;

        public Bus(int busid, string type, int actualdriver, int actualline, int mileage, string brand, string model,
            string techcondition)
        {
            _busid = busid;
            _type = type;
            _actualdriver = actualdriver;
            _actualline = actualline;
            _mileage = mileage;
            _brand = brand;
            _model = model;
            _techcondition = techcondition;
        }

        public Bus()
        {
            _busid = -1;
            _type = null;
            _actualdriver = -1;
            _actualline = -1;
            _mileage = 0;
            _brand = null;
            _model = null;
            _techcondition = null;
        }
    }
}
