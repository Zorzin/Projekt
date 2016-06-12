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
    /// Interaction logic for LineAddWindow.xaml
    /// </summary>
    public partial class LineAddWindow : Window
    {
        private Line line;
        public LineAddWindow()
        {
            line = new Line();
            this.DataContext = line;
            InitializeComponent();
            FirstStopComboBox.ItemsSource = Lists.BusStops;
            LastStopComboBox.ItemsSource = Lists.BusStops;
            Commands.BindCommandsToWindow(this);
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            string id, length =null, firststop=null, laststop=null;

            if (CheckBox.IsChecked==true)
            {
                id = CheckStrings.CheckId(NumberTextBox.Text);
            }
            else
            {
                id = "null";
            }

            length = CheckStrings.CheckInt(LengthTextBox.Text);

            BusStop first = (BusStop)FirstStopComboBox.SelectedItem;
            if (first != null)
            {
                firststop = first.Id.ToString();
            }

            BusStop last = (BusStop) LastStopComboBox.SelectedItem;
            if (last!=null)
            {
                laststop = last.Id.ToString();
            }

            if (id == null || length == null || firststop == null || laststop == null)
            {
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Błąd podczas walidacji danych", "Błąd", mbb);
                return;
            }

            line.Length = Double.Parse(length);
            line.Firststop = first;
            line.Laststop = last;

            DbConnect db = new DbConnect();
            if (db.AddLine(id,length,firststop,laststop,line))
            {
                Lists.Lines.Add(line);
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Pomyślnie dodano linię", "Dodano", mbb);
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
