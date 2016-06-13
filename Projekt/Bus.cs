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
    class Bus : INotifyPropertyChanged, IDataErrorInfo
    {
        private int     _busId;
        private string  _busbrand;
        private string  _techcondition;
        private Line    _actualline;
        public int Busid
        {
            get { return _busId; }
            set
            {
                _busId = value;
                OnPropertyChanged("BusShow");
            }
        }
        public string Busbrand
        {
            get { return _busbrand; }
            set
            {
                _busbrand = value;
                OnPropertyChanged("BusShow");
            }
        }
        public Line Actualline
        {
            get { return _actualline; }
            set { _actualline = value; OnPropertyChanged("Actualline"); }

        }
        public string Techcondition
        {
            get { return _techcondition; }
            set { _techcondition = value; OnPropertyChanged("Techcondition"); }

        }
        public string   Type             { get; set; }
        public Driver   Actualdriver     { get; set; }
        public double   Mileage          { get; set; }
        public string   BusShow
        {
            get { return Busbrand + ", numer boczny: " + Busid; }
            
        }

        public override string ToString()
        {
            return BusShow + ", stan: " + Techcondition;
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

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {

                    case "Busid":
                        if (Busid.ToString().Length < 1)
                        {
                            return "id can't be empty";
                        }
                        if (Busid < 1)
                        {
                            return "id can't be smaller than 1";
                        }
                        break;
                    case "Type":
                        if (string.IsNullOrEmpty(Type))
                        {
                            Type = "undefined";
                            return "type can't be empty";
                        }
                        break;
                    case "Mileage":
                        if (Mileage.ToString().Length < 1)
                        {
                            return "mileage can't be empty";
                        }
                        if (Mileage < 0)
                        {
                            return "mileage can't be smaller than 1";
                        }
                        break;
                    case "Busbrand":
                        if (string.IsNullOrEmpty(Busbrand))
                        {
                            Busbrand = "undefined";
                            return "busbrand can't be empty";
                        }
                        break;
                    case "Techcondition":
                        if (string.IsNullOrEmpty(Techcondition))
                        {
                            Techcondition = "undefined";
                            return "techcondition can't be empty";
                        }
                        break;
                    default:
                        break;
                }
                return null;
            }
        }

        public string Error { get; }
    }
}
