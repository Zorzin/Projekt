using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    static class Lists
    {
        public static List<BusStop> BusStops = new List<BusStop>();
        public static List<Driver> Drivers = new List<Driver>();
        public static List<Line> Lines = new List<Line>();

        public static BusStop GetBusStop(int id)
        {
            return BusStops.First(stop => stop.Id==id);
        }

        public static Driver GetDriver(int id)
        {
            return Drivers.First(dr => dr.Id == id);
        }

        public static Line GetLine(int id)
        {
            return Lines.First(lin => lin.Number == id);
        }
    }
    
}
