using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for BusStopAddWindow.xaml
    /// </summary>
    public partial class BusStopAddWindow : Window
    {
        private BusStop busstop;
        public BusStopAddWindow()
        {
            Commands.BindCommandsToWindow(this);
            busstop = new BusStop();
            InitializeComponent();
            MainGrid.DataContext = busstop;

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            string id, name;
            if (CheckBox.IsChecked==true)
            {
                id = CheckStrings.CheckId(NumberTextBox.Text);
            }
            else
            {
                id = "null";
            }

            name = CheckStrings.CheckString(NameTextBox.Text);

            if (id == null || name==null)
            {
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Błąd podczas walidacji danych!", "Błąd", mbb);
                return;
            }
            
            busstop.Name = name;
            
            DbConnect db = new DbConnect();
            if (db.AddBusStop(id, name,busstop))
            {
                Lists.BusStops.Add(busstop);
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Pomyślnie dodano przystanek", "Dodano", mbb);
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
