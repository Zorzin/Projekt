using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class BusBrand
    {
        private int     _busbrandid;
        private string  _brand;
        private int     _produtiondate;
        private string  _model;
        private string  _type;
        private string  _engine;
        private int     _enginepower;
        private double  _width;
        private double  _lenght;
        private double  _height;
        private double  _weight;
        private int     _numberofseats;

        public BusBrand(int busbrandid, string brand, int productiondate, string model, string type, string engine, int enginepower, double  width, double length, double height, double weight, int numberofseats)
        {
            _busbrandid = busbrandid;
            _brand = brand;
            _produtiondate = productiondate;
            _model = model;
            _type = type;
            _engine = engine;
            _enginepower = enginepower;
            _width = width;
            _lenght = length;
            _height = height;
            _weight = weight;
            _numberofseats = numberofseats;
        }

        public BusBrand()
        {
            _busbrandid = -1;
            _brand = null;
            _produtiondate = 1700;
            _model = null;
            _type = null;
            _engine = null;
            _enginepower = 0;
            _width = 0;
            _lenght = 0;
            _height = 0;
            _weight = 0;
            _numberofseats = 0;
        }

    }
}
