using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void DriverItem_OnSelected(object sender, RoutedEventArgs e)
        {
            ICollectionView View = CollectionViewSource.GetDefaultView(Lists.Drivers);
            View.Filter = null;
            ListComboBox.ItemsSource = Lists.Drivers;
            ListComboBox.IsEnabled = true;
        }

        private void BusItem_OnSelected(object sender, RoutedEventArgs e)
        {
            ICollectionView View = CollectionViewSource.GetDefaultView(Lists.Buses);
            View.Filter = null;
            ListComboBox.ItemsSource = Lists.Buses;
            ListComboBox.IsEnabled = true;
        }

        private void BusStopItem_OnSelected(object sender, RoutedEventArgs e)
        {
            ICollectionView View = CollectionViewSource.GetDefaultView(Lists.BusStops);
            View.Filter = null;
            ListComboBox.ItemsSource = Lists.BusStops;
            ListComboBox.IsEnabled = true;
        }

        private void LineItem_OnSelected(object sender, RoutedEventArgs e)
        {
            ICollectionView View = CollectionViewSource.GetDefaultView(Lists.Lines);
            View.Filter = null;
            ListComboBox.ItemsSource = Lists.Lines;
            ListComboBox.IsEnabled = true;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selecteditem = SelectComboBox.SelectedItem as ComboBoxItem;
            if (selecteditem!=null)
            {
                switch (selecteditem.Content.ToString())
                {
                    case "Kierowca":
                        DriverSelected();
                        break;
                    case "Autobus":
                        BusSelected();
                        break;
                    case "Przystanek":
                        BusStopSelected();
                        break;
                    case "Linia":
                        LineSelected();
                        break;
                    default:
                        WarningLabel.Content = "Wybierz jedną z opcji";
                        break;
                }
            }
            else
            {
                WarningLabel.Content = "Wybierz jedną z opcji";
            }
            
            
        }

        private void DriverSelected()
        {
            Driver driver = ListComboBox.SelectedItem as Driver;
            if (driver!=null)
            {
                var driverListPage = new DriverListPage();
                driverListPage.filtertxt.Text = driver.Driverlicenseid.ToString();
                ICollectionView View = CollectionViewSource.GetDefaultView(Lists.Drivers);

                View.Filter = delegate (object item)
                {
                    var driverfilter = item as Driver;
                    if (driverfilter != null)
                    {
                        return driverfilter.Driverlicenseid == driver.Driverlicenseid;
                    }
                    return false;
                };
                var mainWindow = (MainWindow) Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(driverListPage);
            }
            else
            {
                WarningLabel.Content = "Wybierz jednego z kierowców";
            }
            
        }

        private void BusSelected()
        {
            Bus bus = ListComboBox.SelectedItem as Bus;
            if (bus != null)
            {
                var busListPage = new BusListPage();
                busListPage.filtertxt.Text = bus.Busid.ToString();
                ICollectionView View = CollectionViewSource.GetDefaultView(Lists.Buses);

                View.Filter = delegate (object item)
                {
                    var busfilter = item as Bus;
                    if (busfilter != null)
                    {
                        return busfilter.Busid == bus.Busid;
                    }
                    return false;
                };
                var mainWindow = (MainWindow) Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(busListPage);
            }
            else
            {
                WarningLabel.Content = "Wybierz jednen z autobusów";
            }
            
        }

        private void BusStopSelected()
        {
            BusStop busstop = ListComboBox.SelectedItem as BusStop;
            if (busstop != null)
            {
                var busstopListPage = new BusStopListPage();
                busstopListPage.filtertxt.Text = busstop.Id.ToString();
                ICollectionView View = CollectionViewSource.GetDefaultView(Lists.BusStops);

                View.Filter = delegate (object item)
                {
                    var busstopfilter = item as BusStop;
                    if (busstopfilter != null)
                    {
                        return busstopfilter.Id == busstop.Id;
                    }
                    return false;
                };
                var mainWindow = (MainWindow) Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(busstopListPage);
            }
            else
            {
                WarningLabel.Content = "Wybierz jednen z przystanków";
            }
            
        }

        private void LineSelected()
        {
            Line line = ListComboBox.SelectedItem as Line;
            if (line != null)
            {
                var lineListPage = new LineListPage();
                lineListPage.linefiltertxt.Text = line.Number.ToString();
                ICollectionView View = CollectionViewSource.GetDefaultView(Lists.Lines);

                View.Filter = delegate (object item)
                {
                    var linefilter = item as Line;
                    if (linefilter != null)
                    {
                        return linefilter.Number == line.Number;
                    }
                    return false;
                };
                var mainWindow = (MainWindow) Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(lineListPage);
            }
            else
            {
                WarningLabel.Content = "Wybierz jedną z linii";
            }
            
        }
    }
}
