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
        public static List<Bus> Buses = new List<Bus>();

        public static BusStop GetBusStop(int id)
        {
            return BusStops.First(stop => stop.Id==id);
        }
        public static Driver GetDriver(int id)
        {
            try
            {
                return Drivers.First(dr => dr.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public static Line GetLine(int id)
        {
            try
            {
                return Lines.First(lin => lin.Number == id);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public static Bus GetBus(int id)
        {
            try
            {
                return Buses.First(bus => bus.Busid == id);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
