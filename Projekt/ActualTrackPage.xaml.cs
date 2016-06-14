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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for ActualTrackPage.xaml
    /// </summary>
    public partial class ActualTrackPage : Page
    {
        private bool _isexpended;
        public ActualTrackPage()
        {
            View.Filter = null;
            _isexpended = true;
            InitializeComponent();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            DataTemplate dt;
            switch (mainWindow.ActualTemplate)
            {
                case "main":
                    dt = (DataTemplate) this.FindResource("MainDataTemplate");
                    ListBox.ItemTemplate = dt;
                    break;
                case "less":
                    dt = (DataTemplate)this.FindResource("LessDataTemplate");
                    ListBox.ItemTemplate = dt;
                    break;
            }
            ListBox.ItemsSource = Lists.ActualTracks;
            DriverComboBox.ItemsSource = Lists.Drivers;
            StartBusStopComboBox.ItemsSource = Lists.BusStops;
            EndBusStopComboBox.ItemsSource = Lists.BusStops;
            BusComboBox.ItemsSource = Lists.Buses;
            /**Storyboard sb; //nie dziala
            if (_isexpended)
            {
                sb = this.FindResource("gridin") as Storyboard;
            }
            else
            {
                sb = this.FindResource("gridout") as Storyboard;
            }
            sb.Begin(this);
            _isexpended = !_isexpended;
            */
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var actualTrack = (ActualTrack) ListBox.SelectedItem;
            if (actualTrack.Driver.Actualbus != null)
            {
                MessageBoxButton mbb = MessageBoxButton.YesNo;
                MessageBoxResult dr = MessageBox.Show("Usuwany kurs jest aktualnie na trasie, usunąć?", "Usunąć?", mbb);
                if (dr == MessageBoxResult.Yes)
                {
                    actualTrack.Driver.Actualbus.Actualdriver = null;
                    actualTrack.Driver.Actualbus.Actualline = null;
                    actualTrack.Driver.Actualbus = null;
                }
                else
                {
                    return;
                }
            }
            JObject obj = Lists.GetActualTrackJObject(actualTrack);
            if (obj != null)
            {
                Lists.JArray.Remove(obj);
            }
            actualTrack.Driver = null;
            actualTrack.Line = null;
            Lists.ActualTracks.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }

        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(Lists.ActualTracks);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            var number = Int32.Parse(filtertxt.Text);
            View.Filter = delegate (object item)
            {
                var at = item as ActualTrack;
                var line = at.Line;
                if (line != null)
                {
                    return line.Number == number;
                }
                return false;
            };
        }

        private void FilterNone(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }

        private class SortByLine : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                ActualTrack at1 = (ActualTrack) x;
                ActualTrack at2 = (ActualTrack) y;

                return at1.Line.Number.CompareTo(at2.Line.Number);
            }
        }

        private void SortNone(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.CustomSort = null;
        }

        private void SortLine(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByLine();
        }

        private void GroupNone(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
        }

        private void GroupByLine(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Line.Number"));
        }

        private void GroupByBus(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Driver.Actualbus.Busid"));
        }

        private void GroupByDriver(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Driver.Id"));
        }
    }
}
