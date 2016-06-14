using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projekt.Annotations;

namespace Projekt
{
    class Driver:INotifyPropertyChanged, IDataErrorInfo
    {
        private static DbConnect dbConnect = new DbConnect();
        private string  _name;
        private string  _secondname;
        private int     _id;
        private Bus     _actualbus;
        private string  _photopath;
        private double  _salary;
        private string  _status;
        private int     _driverlicenseid;
        private string  _city;
        private int     _hoursworked;
        private string  _address;
        private int     _zipcode;

        public string   Name
        {
            get { return _name; }
            set
            {
                if (value != null)
                {
                    dbConnect.UpdateFromString("update projekt.driver set name='"+value+"' where iddriver="+Id+";");
                }
                _name = value;
                OnPropertyChanged("DriverShow");
            }
        }

        public string   Secondname
        {
            get { return _secondname; }
            set
            {
                if (value != null)
                {
                    dbConnect.UpdateFromString("update projekt.driver set secondname='" + value + "' where iddriver=" + Id + ";");
                }
                _secondname = value;
                OnPropertyChanged("DriverShow");
            }
        }

        public int      Id
        {
            get { return _id; }
            set
            {
                if (value > 0 && _id > 0)
                {
                    var oldid= _id;
                    try
                    {
                        _id = value;
                        dbConnect.UpdateFromString("update projekt.driver set iddriver=" + _id + " where iddriver=" + oldid + ";");
                    }
                    catch (Exception e)
                    {
                        var mbb = MessageBoxButton.OK;
                        var dr = MessageBox.Show("Błąd podczas edytowania rekordu", "Błąd", mbb);
                        _id = oldid;
                    }
                }
                else
                {
                    _id = value;
                }
                OnPropertyChanged("DriverShow");
            }
            
        }

        public Bus Actualbus
        {
            get { return _actualbus; }
            set
            {
                if (value != null)
                {
                    if (_actualbus != null)
                    {
                        var line = _actualbus.Actualline;
                        _actualbus.Actualdriver = null;
                        _actualbus.Actualline = null;
                        _actualbus = value;
                        _actualbus.Actualline = line;
                        _actualbus.Actualdriver = this;
                    }
                    
                }
                _actualbus = value;
                OnPropertyChanged("Actualbus");
            }
            
        }

        public string Photopath
        {
            get { return _photopath; }
            set
            {
                if (value != null)
                {
                    dbConnect.UpdateFromString("update projekt.driver set photopath='" + value + "' where iddriver=" + Id + ";");
                }
                _photopath = value;
                OnPropertyChanged("Photopath");
            }
            
        }

        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value >0)
                {
                    NumberFormatInfo dot = new NumberFormatInfo();
                    dot.NumberDecimalSeparator = ".";
                    dbConnect.UpdateFromString("update projekt.driver set salary='" + value.ToString(dot) + "' where iddriver=" + Id + ";");
                }
                _salary = value;
                OnPropertyChanged("Salary");
            }
            
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (value != null)
                {
                    dbConnect.UpdateFromString("update projekt.driver set status='" + value + "' where iddriver=" + Id + ";");
                }
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public int Driverlicenseid
        {
            get { return _driverlicenseid; }
            set
            {
                if (value>0)
                {
                    dbConnect.UpdateFromString("update projekt.driver set driverlicenceid='" + value + "' where iddriver=" + Id + ";");
                }
                _driverlicenseid=value;
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (value != null)
                {
                    dbConnect.UpdateFromString("update projekt.driver set city='" + value + "' where iddriver=" + Id + ";");
                }
                _city = value;
            }
        }

        public int Zipcode
        {
            get { return _zipcode; }
            set
            {
                if (value>0)
                {
                    dbConnect.UpdateFromString("update projekt.driver set zipcode='" + value + "' where iddriver=" + Id + ";");
                }
                _zipcode = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value != null)
                {
                    dbConnect.UpdateFromString("update projekt.driver set address='" + value + "' where iddriver=" + Id + ";");
                }
                _address = value;
            }
        }

        public int Hoursworked
        {
            get { return _hoursworked; }
            set
            {
                if (value>0)
                {
                    NumberFormatInfo dot = new NumberFormatInfo();
                    dot.NumberDecimalSeparator = ".";
                    dbConnect.UpdateFromString("update projekt.driver set hoursworked='" + value.ToString(dot) + "' where iddriver=" + Id + ";");
                }
                _hoursworked = value;
                OnPropertyChanged("Hoursworked");
            }
        }
        public string DriverShow
        {
            get
            {
                if (Name.Length > 0)
                {
                    return Name.Substring(0, 1) + "." + Secondname + ", nr: " + Id;
                }
                else
                {
                    return Name+ " " + Secondname+ ", nr: " + Id;
                }
                
            }
        }

        public override string ToString()
        {
            return Name + " " + Secondname + ", id: " + Id;
        }

        public Driver(string name, string secondname, int id, string status, int driverlicenseid, string city, int zipcode, string address, Bus actualbus, double salary, int hoursworked, string photopath)
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

        public string this[string columnName]
        {
            get {
                switch (columnName)
                {

                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                        {
                            Name = "imie";
                            return "name can't be empty";
                        }
                        break;
                    case "Secondname":
                        if (string.IsNullOrEmpty(Secondname))
                        {
                            Secondname = "nazwisko";
                            return "second name can't be empty";
                        }
                        break;
                    case "Status":
                        if (string.IsNullOrEmpty(Status))
                        {
                            Status = "nieaktywny";
                            return "status can't be empty";
                        }
                        break;
                    case "Driverlicenseid":
                        if (Driverlicenseid.ToString().Length < 1)
                        {
                            Driverlicenseid = 0;
                            return "id can't be empty";
                        }
                        if (Driverlicenseid< 1)
                        {

                            Driverlicenseid = 0;
                            return "id can't be smaller than 1";
                        }
                        break;
                    case "City":
                        if (string.IsNullOrEmpty(City))
                        {
                            City = "miasto";
                            return "city can't be empty";
                        }
                        break;
                    case "Zipcode":
                        int oldzipcode = _zipcode;
                        if (Zipcode.ToString().Length < 5)
                        {
                            Zipcode = 0;
                            return "zipcode too short";
                        }
                        if (Zipcode.ToString().Length > 5)
                        {
                            Zipcode = 0;
                            return "zipcose too long";
                        }
                        if (Zipcode < 0)
                        {
                            Zipcode = 0;
                            return "zipcode can't be smaller than 1";
                        }
                        break;
                    case "Address":
                        if (string.IsNullOrEmpty(Address))
                        {
                            Address = "adres";
                            return "address can't be empty";
                        }
                        break;
                    case "Salary":
                        if (Salary.ToString().Length < 1)
                        {
                            return "salary can't be empty";
                        }
                        if (Salary < 0)
                        {
                            return "salary can't be smaller than 1";
                        }
                        break;
                    case "Hoursworked":
                        if (Hoursworked < 0)
                        {
                            return "hoursworked can't be smaller than 0";
                        }
                        break;
                    case "Photopath":
                        if (string.IsNullOrEmpty(Photopath))
                        {
                            Photopath = "default.jpg";
                            return "Photopath can't be empty";
                        }
                        break;
                    default:
                        break;
                }
                return null;
            }
        }

        public string Error
        {
            get;
        }
    }
}
