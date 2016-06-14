using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    static class CheckStrings
    {
        public static string CheckString(string value)
        {
            string output;
            if (!string.IsNullOrEmpty(value))
            {
                output = value;
            }
            else
            {
                return null;
            }
            return output;
        }

        public static string CheckId(string value)
        {
            string output;
            int _out;
            if (string.IsNullOrEmpty(value))
            {
                output = "null";
            }
            else if (Int32.TryParse(value, out _out))
            {
                if (_out < 1)
                {
                    output = "null";
                }
                else
                {
                    output = value;
                }
            }
            else
            {
                output = "null";
            }
            return output;
        }

        public static string CheckInt(string value)
        {
            string output;
            int _out;
            if (string.IsNullOrEmpty(value))
            {

                return null;
            }
            else if (Int32.TryParse(value, out _out))
            {
                if (_out < 0)
                {
                    return null;
                }
                else
                {
                    output = value;
                }
            }
            else
            {
                return null;
            }
            return output;
        }

        public static string CheckDouble(string value)
        {
            string output;
            double _out;
            if (string.IsNullOrEmpty(value))
            {

                return null;
            }
            else if (Double.TryParse(value.Replace('.', ','), out _out))
            {
                if (_out < 0)
                {
                    return null;
                }
                else
                {
                    output = value;
                }
            }
            else
            {
                return null;
            }
            return output;
        }
    }
}
