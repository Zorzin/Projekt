using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class ActualTrack
    {
        private DateTime    _startHour;
        private DateTime    _endHour;
        private BusStop     _startBusStop;
        private BusStop     _endBusStop;
        private Driver      _driver;
        private bool        _smallbus;
        private Line        _line;

        public ActualTrack(DateTime startHour, DateTime endHour, BusStop startBusStop, BusStop endBusStop, Driver driver, bool smallbus, Line line)
        {
            _startBusStop = startBusStop;
            _startHour = startHour;
            _endHour = endHour;
            _endBusStop = endBusStop;
            _driver = driver;
            _smallbus = smallbus;
            _line = line;
        }

    }
}
