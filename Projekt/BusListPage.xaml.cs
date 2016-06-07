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
    /// Interaction logic for BusListPage.xaml
    /// </summary>
    public partial class BusListPage : Page
    {
        public BusListPage()
        {
            InitializeComponent();
            Commands.List[AddButton] = Commands.BusAddFunction;
            ListBox.ItemsSource = Lists.Buses;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DbConnect db = new DbConnect();
            Bus bus = (Bus)ListBox.SelectedItem;
            if (bus.Actualline!=null)
            {
                MessageBoxButton mbb = MessageBoxButton.YesNo;
                MessageBoxResult dr = MessageBox.Show("Usuwany autobus jest aktualnie na trasie, usunąć wraz z kursem?", "Usunąć?", mbb);
                if (dr == MessageBoxResult.Yes)
                {
                    ActualTrack actualTrack = Lists.GetActualTrackByDriver(bus.Actualdriver.Id);
                    bus.Actualdriver.Actualbus = null;
                    bus.Actualdriver = null;
                    bus.Actualline = null;
                    actualTrack.Driver = null;
                    actualTrack.Line = null;
                    Lists.ActualTracks.Remove(actualTrack);
                }
                else
                {
                    return;
                }
            }
            db.Delete("Bus",bus.Busid.ToString());
            Lists.Buses.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }
    }
}
