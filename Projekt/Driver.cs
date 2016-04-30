using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Driver
    {
        private string  _name;
        private string  _secondname;
        private int     _id;
        private string  _status;
        private int     _driverlicenseid;
        private string  _city;
        private int     _zipcode;
        private string  _address;
        private int     _actualline;

        public Driver(string name, string secondname, int id, string status, int driverlicenseid, string city, int zipcode, string address, int actualline)
        {
            _name = name;
            _secondname = secondname;
            _id = id;
            _status = status;
            _driverlicenseid = driverlicenseid;
            _city = city;
            _zipcode = zipcode;
            _address = address;
            _actualline = actualline;
        }

        public Driver()
        {
            _name = null;
            _secondname = null;
            _id = -1;
            _status = null;
            _driverlicenseid = -1;
            _city = null;
            _zipcode = -1;
            _address = null;
            _actualline = -1;
        }


    }
}
