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
    /// Interaction logic for BusStopListPage.xaml
    /// </summary>
    public partial class BusStopListPage : Page
    {
        public BusStopListPage()
        {
            InitializeComponent();
            Commands.List[AddButton] = Commands.BusStopAddFunction;
            ListBox.ItemsSource = Lists.BusStops;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DbConnect db = new DbConnect();
            BusStop busstop = (BusStop)ListBox.SelectedItem;
            db.Delete("Busstop", busstop.Id.ToString());
            Lists.BusStops.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }
    }
}
