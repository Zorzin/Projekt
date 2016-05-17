using System;
using System.Collections.Generic;
using System.Data;
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
            /*DBConnect dbConnect = new DBConnect();
            DataTable DT = dbConnect.SelectQuery("Select * from Driver");*/
        }

        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEdit = new AddEditPage();
            
            addEdit.List = new Dictionary<object, Func<int>>();
            addEdit.List[DriversButton] = addEdit.DriverFunction;
            addEdit.List[BusStopsButton] = addEdit.BusStopFunction;
            addEdit.List[BussesButton] = addEdit.BusFunction;
            addEdit.List[LinesButton] = addEdit.LineFunction;
            addEdit.List[ActualTrackButton] = addEdit.ActualTrackFunction;
            addEdit.EventArgs = e;
            MainFrame.Navigate(addEdit);
            //var mainWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            //mainWindow.Close();
            //addEdit.Show();

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            MainFrame.Navigate(searchPage);
        }
    }
}
