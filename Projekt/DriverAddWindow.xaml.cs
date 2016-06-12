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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for DriverAddWindow.xaml
    /// </summary>
    public partial class DriverAddWindow : Window
    {
        private Driver driver;
        public DriverAddWindow()
        {
            driver = new Driver();
            this.DataContext = driver;
            InitializeComponent();
            Commands.BindCommandsToWindow(this);
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            string id, status;
            if (CheckBox.IsChecked == true)
            {
                id = CheckStrings.CheckId(IDTextBox.Text);
            }
            else
            {
                id = "null";
            }
            ComboBoxItem item;
            item = (ComboBoxItem)StatusComboBox.SelectedItem;
            if (item !=null)
            {
                switch (item.Content.ToString())
                {
                    case "aktywny":
                        status = "active";
                        break;
                    case "urlop":
                        status = "leave";
                        break;
                    case "nieaktywny":
                        status = "inactive";
                        break;
                    default:
                        status = "inactive";
                        break;
                }
            }
            else
            {
                status = null;
            }
            
            var name = CheckStrings.CheckString(NameTextBox.Text);
            var secondname = CheckStrings.CheckString(SecondnameTextBox.Text);
            var driverlicenseid = CheckStrings.CheckInt(DrivingIDTextBox.Text);
            var city = CheckStrings.CheckString(CityTextBox.Text);
            var zipcode = CheckStrings.CheckInt(ZipcodeTextBox.Text);
            var address = CheckStrings.CheckString(AddressTextBox.Text);
            var salary = CheckStrings.CheckInt(SalaryTextBox.Text);
            var hoursworked = CheckStrings.CheckInt(HoursworkedTextBox.Text);
            var photopath = CheckStrings.CheckString(PhotopathTextBox.Text);
            photopath = photopath.Substring(photopath.LastIndexOf("\\") + 1);
            if (zipcode!=null)
            {
                if (zipcode.Length > 5 || zipcode.Length < 5)
                {
                    zipcode = null;
                }
            }
            

            if (name == null || secondname ==null || driverlicenseid == null || city ==null || zipcode ==null || address ==null || salary ==null || hoursworked ==null || photopath ==null)
            {
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Błąd podczas walidacji danych", "Błąd", mbb);
                return;
            }
            
            driver.Name = name;
            driver.Secondname = secondname;
            driver.Driverlicenseid = Int32.Parse(driverlicenseid);
            driver.Status = status;
            driver.City = city;
            driver.Zipcode = Int32.Parse(zipcode);
            driver.Address = address;
            driver.Salary = Double.Parse(salary);
            driver.Hoursworked = Int32.Parse(hoursworked);
            driver.Photopath = photopath;
            

            DbConnect db = new DbConnect();
            if (db.AddDriver(id, name, secondname,status,driverlicenseid,city,zipcode,address,salary,hoursworked,photopath,driver))
            {
                Lists.Drivers.Add(driver);
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Pomyślnie dodano kierowcę", "Dodano", mbb);
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
