using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for KierowcaMain.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        public RoutedEventArgs EventArgs;
        public AddEdit()
        {
            InitializeComponent();
        }
        private void ButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
            bool edit = ReferenceEquals(e.Source, EditButton);
            MainWindow mainWindow = (MainWindow) Application.Current.MainWindow;
            if (Object.ReferenceEquals(EventArgs.Source, mainWindow.DriversButton))
            {
                if (edit)
                {
                    DriverListWindow driverListWindow = new DriverListWindow();
                    driverListWindow.ShowDialog();
                }
                else
                {
                    DriverAddWindow driverAddWindow = new DriverAddWindow();
                    driverAddWindow.ShowDialog();
                }
            }
            else if (Object.ReferenceEquals(EventArgs.Source, mainWindow.BusStopsButton))
            {
                if (edit)
                {
                    BusStopListWindow busStopListWindow = new BusStopListWindow();
                    busStopListWindow.ShowDialog();
                }
                else
                {
                    //add or delete
                }
            }
            else if (Object.ReferenceEquals(EventArgs.Source, mainWindow.BussesButton))
            {
                if (edit)
                {
                    BusListWindow busListWindow = new BusListWindow();
                    busListWindow.ShowDialog();
                }
                else
                {
                    BusAddWindow busAddWindow= new BusAddWindow();
                    busAddWindow.ShowDialog();
                }
            }
            else if (Object.ReferenceEquals(EventArgs.Source, mainWindow.LinesButton))
            {
                if (edit)
                {
                    LineListWindow lineListWindow = new LineListWindow();
                    lineListWindow.ShowDialog();
                }
                else
                {
                    LineAddWindow lineAddWindow = new LineAddWindow();
                    lineAddWindow.ShowDialog();
                }
            }
        }
    }
}
