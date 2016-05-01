using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Projekt
{
    class Commands
    {
        
        public static RoutedUICommand ButtonCommand { get; set; }

        static Commands()
        {
            ButtonCommand = new RoutedUICommand("Edit/Add existing record", "edit/add", typeof (Commands));
        }
    }
}
