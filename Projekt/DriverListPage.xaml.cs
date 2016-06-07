using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
                MessageBoxResult dr = MessageBox.Show("Usuwany kierowca ma aktualnie kurs. Usunąć kierowcę i zakończyć kurs?", "Usunąć?", mbb);
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
                /***
                Image image = new Image();
                Uri uri = new Uri(Path.Combine(Path.Combine(Environment.CurrentDirectory, "images"),
                    Path.GetFileName(driver.Photopath)));
                BitmapImage imagebitmap = new BitmapImage(uri);
                image.Source = imagebitmap;
                image.Height = 300;
                Grid grid = new Grid();
                grid.Width = 1654;
                grid.Height = 2339;
                RowDefinition mainrow1 = new RowDefinition();
                mainrow1.Height = new GridLength(20, GridUnitType.Star);
                RowDefinition mainrow2 = new RowDefinition();
                mainrow2.Height = new GridLength(80, GridUnitType.Star);
                ColumnDefinition maincolumn1 = new ColumnDefinition();
                ColumnDefinition maincolumn2 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(maincolumn1);
                grid.ColumnDefinitions.Add(maincolumn2);
                grid.RowDefinitions.Add(mainrow1);
                grid.RowDefinitions.Add(mainrow2);
                grid.Children.Add(image);
                Grid.SetColumn(image, 0);
                Grid.SetRow(image, 0);
                Label nameLabel = new Label();
                nameLabel.FontSize = 46;
                nameLabel.Margin = new Thickness(0,300,0,0);
                nameLabel.Content = driver.Name + " " + driver.Secondname;
                grid.Children.Add(nameLabel);
                Grid.SetColumn(nameLabel, 1);

                Grid infoGrid = new Grid();
                for (int i = 0; i < 7; i++)
                {
                    RowDefinition inforow = new RowDefinition();
                    infoGrid.RowDefinitions.Add(inforow);
                }
                infoGrid.Margin = new Thickness(50,0,0,0);
                grid.Children.Add(infoGrid);
                Grid.SetRow(infoGrid,1);

                Label idLabel = new Label();
                idLabel.FontSize = 35;
                idLabel.Content = "Id: " + driver.Id;
                infoGrid.Children.Add(idLabel);
                Grid.SetRow(idLabel, 0);
                Label salaryLabel = new Label();
                salaryLabel.FontSize = 35;
                salaryLabel.Content = "Zarobki: " + driver.Salary;
                infoGrid.Children.Add(salaryLabel);
                Grid.SetRow(salaryLabel, 1);
                Label driverlicenseLabel = new Label();
                driverlicenseLabel.FontSize = 35;
                driverlicenseLabel.Content = "Nr prawa jazdy: " + driver.Driverlicenseid;
                infoGrid.Children.Add(driverlicenseLabel);
                Grid.SetRow(driverlicenseLabel, 2);
                Label cityLabel = new Label();
                cityLabel.FontSize = 35;
                cityLabel.Content = "Miasto: " + driver.City;
                infoGrid.Children.Add(cityLabel);
                Grid.SetRow(cityLabel, 3);
                Label zipcodeLabel = new Label();
                zipcodeLabel.FontSize = 35;
                zipcodeLabel.Content = "Kod pocztowy: " + driver.Zipcode;
                infoGrid.Children.Add(zipcodeLabel);
                Grid.SetRow(zipcodeLabel, 4);
                Label addressLabel = new Label();
                addressLabel.FontSize = 35;
                addressLabel.Content = "Adres: " + driver.Address;
                infoGrid.Children.Add(addressLabel);
                Grid.SetRow(addressLabel, 5);
                Label hoursworkedLabel = new Label();
                hoursworkedLabel.FontSize = 35;
                hoursworkedLabel.Content = "Godziny przepracowane: " + driver.Hoursworked;
                infoGrid.Children.Add(hoursworkedLabel);
                Grid.SetRow(hoursworkedLabel, 6);
                // Size the Grid.
                grid.Measure(new Size(Double.PositiveInfinity,
                                      Double.PositiveInfinity));

                Size sizeGrid = grid.DesiredSize;

                // Determine point for centering Grid on page.
                var margin = 96*0.25;
                var point = new Point(
                        (printDialog.PrintableAreaWidth - grid.Width)/2 - margin,
                        (printDialog.PrintableAreaHeight - grid.Height)/2 - margin);

                // Layout pass.
                grid.Arrange(new Rect(point, sizeGrid));
                PrintWindow printWindow = new PrintWindow();
                printWindow.Content = grid;
                // Now print it.
                printDialog.PrintVisual(grid, Title);
                printWindow.Close();*/

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
    }
}