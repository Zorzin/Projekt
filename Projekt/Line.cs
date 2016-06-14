using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Projekt.Annotations;

namespace Projekt
{
    class Line:INotifyPropertyChanged, IDataErrorInfo
    {
        private static DbConnect dbConnect = new DbConnect();
        private int _number;
        private double _length;
        private BusStop _firststop;
        private BusStop _laststop;

        public int Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged("Number"); }
        }

        public double Length
        {
            get { return _length; }
            set
            {
                if (value > 0)
                {
                    NumberFormatInfo dot = new NumberFormatInfo();
                    dot.NumberDecimalSeparator = ".";
                    dbConnect.UpdateFromString("update projekt.line set lenght='" + value.ToString(dot) + "' where idline=" + Number + ";");
                }
                _length = value;
                OnPropertyChanged("Length");
            }
        }

        public BusStop Firststop
        {
            get { return _firststop; }
            set
            {
                if (value !=null)
                {
                    dbConnect.UpdateFromString("update projekt.line set firststop='" + value.Id + "' where idline=" + Number + ";");
                }
                _firststop = value;
            }
        }

        public BusStop Laststop
        {
            get { return _laststop; }
            set
            {
                if (value !=null)
                {
                    dbConnect.UpdateFromString("update projekt.line set laststop='" + value.Id + "' where idline=" + Number + ";");
                }
                _laststop = value;
            }
        }

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

        public override string ToString()
        {
            return "Linia nr: " + Number;
        }

        public string LineShow
        {
            get { return ToString(); }
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

                    case "Number":
                        if (Number.ToString().Length < 1)
                        {
                            return "id can't be empty";
                        }
                        if (Number < 1)
                        {
                            return "id can't be smaller than 1";
                        }
                        break;
                    case "Length":
                        if (Length.ToString().Length < 1)
                        {
                            return "length can't be empty";
                        }
                        if (Length < 0)
                        {
                            return "Length can't be negative";
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
