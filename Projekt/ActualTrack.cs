using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class ActualTrack
    {
        public DateTime     StartHour       { get; set; }
        public DateTime     EndHour         { get; set; }
        public BusStop      StartBusStop    { get; set; }
        public BusStop      EndBusStop      { get; set; }
        public Driver       Driver          { get; set; }
        public bool         Smallbus        { get; set; }
        public Line         Line            { get; set; }

        public ActualTrack(DateTime startHour, DateTime endHour, BusStop startBusStop, BusStop endBusStop, Driver driver, bool smallbus, Line line)
        {
            StartBusStop = startBusStop;
            StartHour = startHour;
            EndHour = endHour;
            EndBusStop = endBusStop;
            Driver = driver;
            Smallbus = smallbus;
            Line = line;
        }

        public ActualTrack()
        {
            StartBusStop = null;
            StartHour = DateTime.MinValue;
            EndHour = DateTime.MinValue;
            EndBusStop = null;
            Driver = null;
            Smallbus = false;
            Line = null;
        }

    }
}
