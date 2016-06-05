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
    class Driver:INotifyPropertyChanged
    {
        private string  _name;
        private string  _secondname;
        private int     _id;
        private Bus    _actualline;
        private string  _photopath;
        private double  _salary;
        public string   Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("DriverShow"); }
        }

        public string   Secondname
        {
            get { return _secondname; }
            set { _secondname = value; OnPropertyChanged("DriverShow"); }
        }

        public int      Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("DriverShow"); }
            
        }

        public Bus Actualbus
        {
            get { return _actualline; }
            set { _actualline = value; OnPropertyChanged("Actualbus"); }
            
        }

        public string Photopath
        {
            get { return _photopath; }
            set { _photopath = value; OnPropertyChanged("Photopath"); }
            
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; OnPropertyChanged("Salary"); }
            
        }
        public string  Status           { get; set; }
        public int     Driverlicenseid  { get; set; }
        public string  City             { get; set; }
        public int     Zipcode          { get; set; }
        public string  Address          { get; set; }
        public double  Hoursworked      { get; set; }
        public string DriverShow
        {
            get { return Name.Substring(0, 1) + "." + Secondname + ": " + Id; }
        }

        public Driver(string name, string secondname, int id, string status, int driverlicenseid, string city, int zipcode, string address, Bus actualbus, double salary, double hoursworked, string photopath)
        {
            _name = name;
            _secondname = secondname;
            _id = id;
            Status = status;
            Driverlicenseid = driverlicenseid;
            City = city;
            Zipcode = zipcode;
            Address = address;
            Actualbus = actualbus;
            Salary = salary;
            Hoursworked = hoursworked;
            Photopath = photopath;
        }

        public Driver()
        {
            Name = null;
            Secondname = null;
            Id = -1;
            Status = null;
            Driverlicenseid = -1;
            City = null;
            Zipcode = -1;
            Address = null;
            Actualbus = null;
            Salary = 0;
            Hoursworked = 0;
            Photopath = "photos/default.jpg";
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
