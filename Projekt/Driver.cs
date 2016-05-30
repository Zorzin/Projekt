using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Driver
    {
        public string  Name             { get; set; }
        public string  Secondname       { get; set; }
        public int     Id               { get; set; }
        public string  Status           { get; set; }
        public int     Driverlicenseid  { get; set; }
        public string  City             { get; set; }
        public int     Zipcode          { get; set; }
        public string  Address          { get; set; }
        public Line    Actualline       { get; set; }
        public double  Salary           { get; set; }
        public double  Hoursworked      { get; set; }
        public string  Photopath        { get; set; }

        public Driver(string name, string secondname, int id, string status, int driverlicenseid, string city, int zipcode, string address, Line actualline, double salary, double hoursworked, string photopath)
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
            Actualline = null;
            Salary = 0;
            Hoursworked = 0;
            Photopath = "default.jpg"; //zmienic na default jakis
        }


    }
}
