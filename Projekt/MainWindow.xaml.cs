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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString());
            AddEdit addEdit = new AddEdit();
            addEdit.List = new Dictionary<object, Func<int>>();
            addEdit.List [DriversButton] = addEdit.DriverFunction;
            addEdit.List [BusStopsButton] = addEdit.BusStopFunction;
            addEdit.List [BussesButton] = addEdit.BusFunction;
            addEdit.List [LinesButton] = addEdit.LineFunction;
            Commands commands = new Commands();
            addEdit.EventArgs = e;
            MainWindow mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.Close();
            addEdit.Show();
            
        }
    }
}
