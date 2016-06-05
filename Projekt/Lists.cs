﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    static class Lists
    {
        public static ObservableCollection<ActualTrack> ActualTracks = new ObservableCollection<ActualTrack>();
        public static ObservableCollection<BusStop> BusStops = new ObservableCollection<BusStop>();
        public static ObservableCollection<Driver> Drivers = new ObservableCollection<Driver>();
        public static ObservableCollection<Line> Lines = new ObservableCollection<Line>();
        public static ObservableCollection<Bus> Buses = new ObservableCollection<Bus>();

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
