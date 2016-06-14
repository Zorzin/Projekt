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
using Newtonsoft.Json.Linq;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for AddActualTrackWindow.xaml
    /// </summary>
    public partial class AddActualTrackWindow : Window
    {
        public AddActualTrackWindow()
        {
            InitializeComponent();
            LineComboBox.ItemsSource = Lists.Lines;
            DriverComboBox.ItemsSource = Lists.Drivers;
            StartBusStopComboBox.ItemsSource = Lists.BusStops;
            EndBusStopComboBox.ItemsSource = Lists.BusStops;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ActualTrack at = new ActualTrack();
            at.Driver = DriverComboBox.SelectedItem as Driver;
            at.Line = LineComboBox.SelectedItem as Line;
            
            try
            {
                DateTime dt = DateTime.Parse(StartDateTextBox.Text);
                at.StartHour = dt;
                dt = DateTime.Parse(EndDateTextBox.Text);
                at.EndHour = dt;
            }
            catch (Exception)
            {
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Niepoprawna data, wpisz według podanego formatu", "Błąd", mbb);
                return;
            }

            at.StartBusStop = StartBusStopComboBox.SelectedItem as BusStop;
            at.EndBusStop = EndBusStopComboBox.SelectedItem as BusStop;

            if (at.Driver !=null && at.Line!=null && at.StartBusStop !=null && at.EndBusStop!=null)
            {
                Lists.ActualTracks.Add(at);
                JObject obj = new JObject();
                obj["startHour"] = StartDateTextBox.Text;
                obj ["endHour"] = EndDateTextBox.Text;
                obj["startBusStop"] = at.StartBusStop.Id.ToString();
                obj["endBusStop"] = at.EndBusStop.Id.ToString();
                obj["driver"] = at.Driver.Id.ToString();
                obj["line"] = at.Line.Number.ToString();
                Lists.JArray.Add(obj);
                MessageBoxButton mbb = MessageBoxButton.OK;
                MessageBoxResult dr = MessageBox.Show("Dodano kurs", "Dodano", mbb);
                this.Close();
            }
        }
    }
}
