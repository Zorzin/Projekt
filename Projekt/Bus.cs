using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Bus
    {
        public int     Busid            { get; set; }
        public string  Type             { get; set; }
        public Driver  Actualdriver     { get; set; }
        public Line    Actualline       { get; set; }
        public double  Mileage          { get; set; }
        public string  Busbrand         { get; set; }
        public string  Techcondition    { get; set; }

        public Bus(int busid, string type, Driver actualdriver, Line actualline, double mileage, string busbrand, string techcondition)
        {
            Busid = busid;
            Type = type;
            Actualdriver = actualdriver;
            Actualline = actualline;
            Mileage = mileage;
            Busbrand = busbrand;
            Techcondition = techcondition;
        }

        public Bus()
        {
            Busid = -1;
            Type = null;
            Actualdriver = null;
            Actualline = null;
            Mileage = 0;
            Busbrand = null;
            Techcondition = null;
        }
    }
}
