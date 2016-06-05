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
    class Line:INotifyPropertyChanged
    {
        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged("Number"); }
            
        }
        public double   Length          { get; set; }
        public BusStop  Firststop       { get; set; }
        public BusStop  Laststop        { get; set; }

        public Line(int number, double lenght, BusStop firststop, BusStop laststop)
        {
            _number = number;
            Length = lenght;
            Firststop = firststop;
            Laststop = laststop;
        }

        public Line()
        {
            Number = -1;
            Length = -1;
            Firststop = null;
            Laststop = null;
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
