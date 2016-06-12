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
    /// Interaction logic for BusAddWindow.xaml
    /// </summary>
    public partial class BusAddWindow : Window
    {
        private Bus bus;
        public BusAddWindow()
        {
            bus = new Bus();
            InitializeComponent();
            this.DataContext = bus;
            Commands.BindCommandsToWindow(this);
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            string id;
            string type=null, busbrand=null,techcondition = null;
            if (CheckBox.IsChecked == true)
            {
                id = CheckStrings.CheckId(NumberTextBox.Text);
            }
            else
            {
                id = "null";
            }

            ComboBoxItem item;
            item = (ComboBoxItem)TypeComboBox.SelectedItem;
            if (item != null)
            {
                switch (item.Content.ToString())
                {
                    case "Duży":
                        type = "big";
                        break;
                    case "Mały":
                        type = "small";
                        break;
                    default:
                        type = "undefined";
                        break;
                }
            }

            item = (ComboBoxItem)BrandComboBox.SelectedItem;
            if (item != null)
            {
                busbrand = item.Content.ToString();
            }

            item = (ComboBoxItem)TechConditionComboBox.SelectedItem;
            if (item!=null)
            {
                switch (item.Content.ToString())
                {
                    case "Zły":
                        techcondition = "bad";
                        break;
                    case "Dobry":
                        techcondition = "good";
                        break;
                    default:
                        techcondition = "undefined";
                        break;
                }
            }
            
            var mileage = CheckStrings.CheckInt(MileageTextBox.Text);

            if (mileage==null || type ==null || busbrand == null || techcondition ==null)
            {
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Błąd podczas walidacji danych!", "Błąd", mbb);
            }
            
            bus.Mileage = Int32.Parse(mileage);
            bus.Type = type;
            bus.Busbrand = busbrand;
            bus.Techcondition = techcondition;


            DbConnect db = new DbConnect();
            if (db.AddBus(id,type,mileage,busbrand,techcondition,bus))
            {
                Lists.Buses.Add(bus);
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Pomyślnie dodano przystanek", "Dodano", mbb);
                this.Close();
            }
            
        }
    }
}
