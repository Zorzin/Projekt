using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Projekt
{
    /// <summary>
    ///     Interaction logic for BusStopListPage.xaml
    /// </summary>
    public partial class BusStopListPage : Page
    {
        public BusStopListPage()
        {
            View.Filter = null;
            InitializeComponent();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            DataTemplate dt;
            switch (mainWindow.ActualTemplate)
            {
                case "main":
                    dt = (DataTemplate)this.FindResource("MainDataTemplate");
                    ListBox.ItemTemplate = dt;
                    break;
                case "less":
                    dt = (DataTemplate)this.FindResource("LessDataTemplate");
                    ListBox.ItemTemplate = dt;
                    break;
            }
            ListBox.ItemsSource = Lists.BusStops;
        }

        private ListCollectionView View
        {
            get { return (ListCollectionView) CollectionViewSource.GetDefaultView(Lists.BusStops); }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new DbConnect();
            var busstop = (BusStop) ListBox.SelectedItem;
            db.Delete("Busstop", busstop.Id.ToString());
            Lists.BusStops.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }

        private void SortNone(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.CustomSort = null;
        }

        private void SortName(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByName();
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            var number = int.Parse(filtertxt.Text);
            View.Filter = delegate(object item)
            {
                var bs = item as BusStop;
                if (bs != null)
                {
                    return bs.Id == number;
                }
                return false;
            };
        }

        private void FilterNone(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }

        private class SortByName : IComparer
        {
            public int Compare(object x, object y)
            {
                var bs1 = (BusStop) x;
                var bs2 = (BusStop) y;

                return bs1.Id.CompareTo(bs2.Id);
            }
        }
    }
}