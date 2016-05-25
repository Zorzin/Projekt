using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public Dictionary<Object, Func<int>> List;
        public RoutedEventArgs EventArgs;
        private bool _edit;
        public AddEdit()
        {
            InitializeComponent();

        }

        public int DriverFunction()
        {
            if (_edit)
            {
                DriverListWindow driverListWindow = new DriverListWindow();
                driverListWindow.Show();
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
            if (_edit)
            {
                BusStopListWindow busStopListWindow = new BusStopListWindow();
                busStopListWindow.Show();
            }
            else
            {
                //add or delete
            }
            return 1;
        }

        public int BusFunction()
        {
            if (_edit)
            {
                BusListWindow busListWindow = new BusListWindow();
                busListWindow.Show();
            }
            else
            {
                BusAddWindow busAddWindow= new BusAddWindow();
                busAddWindow.Show();
            }
            return 1;
        }

        public int LineFunction()
        {
            if (_edit)
            {
                LineListWindow lineListWindow = new LineListWindow();
                lineListWindow.Show();
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
            _edit = ReferenceEquals(e.Source, EditButton);
            List [EventArgs.Source].Invoke();
            this.Close();
        }

        private void ButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }
    }
}
