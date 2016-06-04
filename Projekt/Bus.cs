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
    class Bus : INotifyPropertyChanged
    {
        private int _busId;
        private string _busbrand;

        public int Busid
        {
            get { return _busId; }
            set
            {
                _busId = value;
                OnPropertyChanged("BusShow");
            }
        }

        public string  Type             { get; set; }
        public Driver  Actualdriver     { get; set; }
        public Line    Actualline       { get; set; }
        public double  Mileage          { get; set; }

        public string Busbrand
        {
            get { return _busbrand; }
            set
            {
                _busbrand = value;
                OnPropertyChanged("BusShow");
            } 
        }
        
        public string  Techcondition    { get; set; }
        public string BusShow
        {
            get { return Busbrand + ", numer boczny: " + Busid; }
            
        }

        public Bus(int busId, string type, Driver actualdriver, Line actualline, double mileage, string busbrand, string techcondition)
        {
            Type = type;
            Actualdriver = actualdriver;
            Actualline = actualline;
            Mileage = mileage;
            Techcondition = techcondition;
            _busbrand = busbrand;
            _busId = busId;
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
