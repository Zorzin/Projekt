using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Projekt.Annotations;

namespace Projekt
{
    class ActualTrack:INotifyPropertyChanged
    {
        private Line        _line;
        private DateTime    _startHour;
        private DateTime    _endHour;
        private Driver      _driver;
        private BusStop _startBusStop;
        private BusStop _endBusStop;

        public  DateTime     StartHour
        {
            get { return _startHour; }
            set
            {
                if (value != null)
                {
                    JObject obj = Lists.GetActualTrackJObject(this);
                    if (obj != null)
                    {
                        obj["startHour"] = value.ToString().Replace(".", "/").Substring(0, value.ToString().Length - 3);
                    }
                }
                _startHour = value;
                OnPropertyChanged("ActualTrackShow");
                OnPropertyChanged("StartHour");
            }
            
        }
        public  DateTime     EndHour
        {
            get { return _endHour; }
            set
            {
                if (value != null)
                {
                    JObject obj = Lists.GetActualTrackJObject(this);
                    if (obj != null)
                    {
                        obj["endHour"] = value.ToString().Replace(".", "/").Substring(0, value.ToString().Length - 3);
                    }
                }
                _endHour = value;
                OnPropertyChanged("ActualTrackShow");
                OnPropertyChanged("EndHour");
            }
            
        }
        public  Line         Line
        {
            get { return _line; }
            set
            {
                if (value != null)
                {
                    JObject obj = Lists.GetActualTrackJObject(this);
                    if (obj != null)
                    {
                        obj["line"] = value.Number.ToString();
                    }
                }
                _line = value;
                OnPropertyChanged("ActualTrackShow");
            }

        }

        public BusStop StartBusStop
        {
            get { return _startBusStop; }
            set
            {
                if (value != null)
                {
                    JObject obj = Lists.GetActualTrackJObject(this);
                    if (obj != null)
                    {
                        obj["startBusStop"] = value.Id.ToString();
                    }
                }
                _startBusStop = value;
            }
        }

        public BusStop EndBusStop
        {
            get { return _endBusStop; }
            set
            {
                if (value != null)
                {
                    JObject obj = Lists.GetActualTrackJObject(this);
                    if (obj != null)
                    {
                        obj["endBusStop"] = value.Id.ToString();
                    }
                }
                _endBusStop = value;
            }
        }

        public Driver Driver
        {
            get { return _driver; }
            set
            {
                if (value != null)
                {
                    JObject obj = Lists.GetActualTrackJObject(this);
                    if (obj != null)
                    {
                        obj["driver"] = value.Id.ToString();
                    }
                }
                if (_driver != null)
                {
                    var bus = _driver.Actualbus;
                    _driver.Actualbus = null;
                    _driver = value;
                    if (_driver != null)
                    {
                        _driver.Actualbus = bus;
                        _driver.Actualbus.Actualdriver = _driver;
                    }
                }
                else
                {
                    _driver = value;
                }
            }
        }
        public bool         Smallbus        { get; set; }
        public string       ActualTrackShow
        {
            get
            {
                try
                {
                    return "Linia: " + Line.Number + ", od " + StartHour.TimeOfDay + " do " + EndHour.TimeOfDay;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public override string ToString()
        {
            return ActualTrackShow;
        }

        public ActualTrack(DateTime startHour, DateTime endHour, BusStop startBusStop, BusStop endBusStop, Driver driver, bool smallbus, Line line)
        {
            StartBusStop = startBusStop;
            _startHour = startHour;
            _endHour = endHour;
            EndBusStop = endBusStop;
            Driver = driver;
            Smallbus = smallbus;
            _line = line;
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }
    }
}
