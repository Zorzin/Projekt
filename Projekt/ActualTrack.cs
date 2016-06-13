using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Projekt.Annotations;

namespace Projekt
{
    class ActualTrack:INotifyPropertyChanged
    {
        private Line        _line;
        private DateTime    _startHour;
        private DateTime    _endHour;
        public  DateTime     StartHour
        {
            get { return _startHour; }
            set { _startHour = value;
                OnPropertyChanged("ActualTrackShow");
                OnPropertyChanged("StartHour");}
            
        }
        public  DateTime     EndHour
        {
            get { return _endHour; }
            set { _endHour = value;
                OnPropertyChanged("ActualTrackShow");
                OnPropertyChanged("EndHour");}
            
        }
        public  Line         Line
        {
            get { return _line; }
            set { _line = value;
                OnPropertyChanged("ActualTrackShow"); }

        }
        public  BusStop      StartBusStop    { get; set; }
        public  BusStop      EndBusStop      { get; set; }
        public  Driver       Driver          { get; set; }
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
