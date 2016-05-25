using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Driver
    {
        public string  Name;
        public string  Secondname;
        public int     Id;
        public string  Status;
        public int     Driverlicenseid;
        public string  City;
        public int     Zipcode;
        public string  Address;
        public int     Actualline;
        public double  Salary;
        public double  Hoursworked;
        public string  Photopath;

        public Driver(string name, string secondname, int id, string status, int driverlicenseid, string city, int zipcode, string address, int actualline, double salary, double hoursworked, string photopath)
        {
            Name = name;
            Secondname = secondname;
            Id = id;
            Status = status;
            Driverlicenseid = driverlicenseid;
            City = city;
            Zipcode = zipcode;
            Address = address;
            Actualline = actualline;
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
            Actualline = -1;
            Salary = 0;
            Hoursworked = 0;
            Photopath = null; //zmienic na default jakis
        }


    }
}
