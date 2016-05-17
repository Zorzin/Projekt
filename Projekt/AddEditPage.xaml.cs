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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for AddEditPAge.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public Dictionary<Object, Func<int>> List;
        public RoutedEventArgs EventArgs;
        private bool edit;
        public AddEditPage()
        {
            InitializeComponent();

        }

        public int DriverFunction()
        {
            if (edit)
            {
                DriverListPage driverListPage = new DriverListPage();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(driverListPage);
            }
            else
            {
                DriverAddWindow driverAddWindow = new DriverAddWindow();
                driverAddWindow.Show();
            }
            return 1;
        }

        public int BusStopFunction()
        {
            if (edit)
            {
                BusStopListPage busStopListPage = new BusStopListPage();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(busStopListPage);
            }
            else
            {
                //add or delete
            }
            return 1;
        }

        public int BusFunction()
        {
            if (edit)
            {
                BusListPage busListPage = new BusListPage();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(busListPage);
            }
            else
            {
                BusAddWindow busAddWindow= new BusAddWindow();
                busAddWindow.Show();
            }
            return 1;
        }

        public int ActualTrackFunction()
        {
            if (edit)
            {
                ActualTrackPage actualTrackPage = new ActualTrackPage();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(actualTrackPage);
            }
            else
            {
                ///
            }
            return 1;
        }

        public int LineFunction()
        {
            if (edit)
            {
                LineListPage lineListPage = new LineListPage();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(lineListPage);
            }
            else
            {
                LineAddWindow lineAddWindow = new LineAddWindow();
                lineAddWindow.Show();
            }
            return 1;
        }
        private void ButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            edit = ReferenceEquals(e.Source, EditButton);
            List [EventArgs.Source].Invoke();
        }

        private void ButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
