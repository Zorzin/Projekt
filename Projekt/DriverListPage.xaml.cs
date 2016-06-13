using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Button = System.Windows.Controls.Button;
using FlowDirection = System.Windows.FlowDirection;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;
using PrintDialog = System.Windows.Controls.PrintDialog;

namespace Projekt
{
    /// <summary>
    ///     Interaction logic for DriverListPage.xaml
    /// </summary>
    public partial class DriverListPage : Page
    {
        public DriverListPage()
        {
            View.Filter = null;
            InitializeComponent();
            Commands.List[AddButton] = Commands.DriverAddFunction;
            ListBox.ItemsSource = Lists.Drivers;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new DbConnect();
            var driver = (Driver) ListBox.SelectedItem;
            if (driver.Actualbus != null)
            {
                MessageBoxButton mbb = MessageBoxButton.YesNo;
                MessageBoxResult dr = MessageBox.Show("Usuwany kierowca ma aktualnie kurs. Usunąć kierowcę oraz kurs?", "Usunąć?", mbb);
                if (dr == MessageBoxResult.Yes)
                {
                    ActualTrack track = Lists.GetActualTrackByDriver(driver.Id);
                    track.Driver.Actualbus.Actualdriver = null;
                    track.Driver.Actualbus.Actualline = null;
                    track.Driver.Actualbus = null;
                    track.Driver = null;
                    track.Line = null;
                    Lists.ActualTracks.Remove(track);
                }
                else
                {
                    return;
                }
            }
            db.Delete("driver", driver.Id.ToString());
            Lists.Drivers.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }

        private void PathButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    PathTextBox.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf("\\") + 1);
                    if (!File.Exists(Path.Combine(Path.Combine(Environment.CurrentDirectory, "images"),
                        Path.GetFileName(dialog.FileName))))
                    {
                        File.Copy(dialog.FileName,
                            Path.Combine(Path.Combine(Environment.CurrentDirectory, "images"),
                                Path.GetFileName(dialog.FileName)));
                    }
                    PathTextBox.Focus();
                    break;
                default:
                    break;
            }
        }
        
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void Print()
        {
                Driver driver = (Driver) ListBox.SelectedItem;
                PrintWindow pw = new PrintWindow();
                Uri uri = new Uri(Path.Combine(Path.Combine(Environment.CurrentDirectory, "images"),
                    Path.GetFileName(driver.Photopath)));
                BitmapImage imagebitmap = new BitmapImage(uri);
                pw.Image.Source = imagebitmap;
                pw.nameLabel.Content = driver.Name + " " + driver.Secondname;
                pw.idLabel.Content += driver.Id.ToString();
                pw.addressLabel.Content += driver.Address;
                pw.cityLabel.Content += driver.City;
                pw.salaryLabel.Content += driver.Salary + " zł";
                pw.drivinglicenseLabel.Content += driver.Driverlicenseid.ToString();
                pw.hoursworkedLabel.Content += driver.Hoursworked.ToString();
                pw.zipcodeLabel.Content += driver.Zipcode.ToString();
                pw.ShowDialog();
                pw.Close();
            
        }
        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(Lists.Drivers);
            }
        }
        
        private void GroupByStatus(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Status"));
        }

        private void GroupByCity(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("City"));
        }

        private void GroupNone(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
        }

        private void SortNone(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.CustomSort = null;
        }

        private class SortByName: System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Driver driver1 = (Driver) x;
                Driver driver2 = (Driver) y;

                return driver1.Name.CompareTo(driver2.Name);
            }
        }

        private class SortByID: System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Driver driver1 = (Driver) x;
                Driver driver2 = (Driver) y;

                return driver1.Id.CompareTo(driver2.Id);
            }
        }

        private class SortByFirstLetterOfSecondName: System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Driver driver1 = (Driver) x;
                Driver driver2 = (Driver) y;

                string first = driver1.Secondname.Substring(0, 1);
                string second = driver2.Secondname.Substring(0, 1);
                return first.CompareTo(second);
            }
        }
        private void SortName(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByName();
        }

        private void SortID(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByID();
        }
        private void SortFirstLetterOfSecondName(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByFirstLetterOfSecondName();
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            var number = Int32.Parse(filtertxt.Text);
            View.Filter = delegate (object item)
            {
                var driver = item as Driver;
                if (driver != null)
                {
                    return driver.Driverlicenseid == number;
                }
                return false;
            };
        }

        private void FilterNone(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }
    }
}