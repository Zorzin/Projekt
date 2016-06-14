using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Projekt
{
    static class Lists
    {
        public static ObservableCollection<ActualTrack> ActualTracks = new ObservableCollection<ActualTrack>();
        public static ObservableCollection<BusStop> BusStops = new ObservableCollection<BusStop>();
        public static ObservableCollection<Driver> Drivers = new ObservableCollection<Driver>();
        public static ObservableCollection<Line> Lines = new ObservableCollection<Line>();
        public static ObservableCollection<Bus> Buses = new ObservableCollection<Bus>();
        public static List<string> TechConditions = new List<string>();
        public static List<string> Brands = new List<string>();
        public static List<string> Types = new List<string>();
        public static List<string> Statuses = new List<string>();
        public static JArray JArray = new JArray();

        public static BusStop GetBusStop(int id)
        {
            try
            {
                return BusStops.First(stop => stop.Id == id);
            }
            catch (Exception)
            {

                return null;
            }
            
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

        public static JObject GetActualTrackJObject(ActualTrack at)
        {

            foreach (JObject obj in JArray.Children())
            {
                var itemProperties = obj.Children<JProperty>();
                if (at.StartBusStop != null && at.EndBusStop != null && at.Driver != null && at.StartHour != null &&
                    at.EndHour != null && at.Line != null)
                {
                    if (itemProperties.First(x => x.Name == "startBusStop").Value.ToString() ==
                        at.StartBusStop.Id.ToString())
                    {
                        if (itemProperties.First(x => x.Name == "endBusStop").Value.ToString() ==
                            at.EndBusStop.Id.ToString())
                        {
                            if (itemProperties.First(x => x.Name == "driver").Value.ToString() ==
                                at.Driver.Id.ToString())
                            {
                                if (itemProperties.First(x => x.Name == "startHour").Value.ToString() ==
                                    at.StartHour.ToString()
                                        .Replace(".", "/")
                                        .Substring(0, at.StartHour.ToString().Length - 3))
                                {
                                    if (itemProperties.First(x => x.Name == "endHour").Value.ToString() ==
                                        at.EndHour.ToString()
                                            .Replace(".", "/")
                                            .Substring(0, at.StartHour.ToString().Length - 3))
                                    {
                                        if (itemProperties.First(x => x.Name == "line").Value.ToString() ==
                                            at.Line.Number.ToString())
                                        {
                                            return obj;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
