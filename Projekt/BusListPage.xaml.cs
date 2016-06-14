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
            ListBox.ItemsSource = Lists.Buses;
            TechComboBox.ItemsSource = Lists.TechConditions;
            BrandComboBox.ItemsSource = Lists.Brands;
            TypeComboBox.ItemsSource = Lists.Types;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DbConnect db = new DbConnect();
            Bus bus = (Bus)ListBox.SelectedItem;
            if (bus.Actualline!=null)
            {
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Usuwany autobus jest aktualnie na trasie, nie można usunąć","Błąd", mbb);
                return;
                
            }
            db.Delete("Bus",bus.Busid.ToString());
            Lists.Buses.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }

        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(Lists.Buses);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            var number = Int32.Parse(filtertxt.Text);
            View.Filter = delegate (object item)
            {
                var bus = item as Bus;
                if (bus != null)
                {
                    return bus.Busid == number;
                }
                return false;
            };
        }

        private void FilterNone(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }

        private void SortNone(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.CustomSort = null;
        }

        private class SortByNumber: System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Bus bus1 = (Bus) x;
                Bus bus2 = (Bus) y;

                return bus1.Busid.CompareTo(bus2.Busid);
            }
        }

        private void SortNumber(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByNumber();
        }

        private void GroupNone(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
        }

        private void GroupByBrand(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Busbrand"));
        }

        private void GroupByTechcondition(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Techcondition"));
        }

        private void GroupByType(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
        }
    }
}
