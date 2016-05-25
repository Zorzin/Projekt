using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        List<ActualTrack> actualTracks;
        public MainWindow()
        {
            actualTracks = new List<ActualTrack>();
            InitializeComponent();
            LoadJson();
            CheckSmallBus();
            /*DBConnect dbConnect = new DBConnect();
            DataTable DT = dbConnect.SelectQuery("Select * from Driver");*/
        }

        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEdit = new AddEditPage();
            
            addEdit.List = new Dictionary<object, Func<int>>();
            addEdit.List[DriversButton] = addEdit.DriverFunction;
            addEdit.List[BusStopsButton] = addEdit.BusStopFunction;
            addEdit.List[BussesButton] = addEdit.BusFunction;
            addEdit.List[LinesButton] = addEdit.LineFunction;
            addEdit.List[ActualTrackButton] = addEdit.ActualTrackFunction;
            addEdit.EventArgs = e;
            Button b = (Button)e.Source;
            addEdit.PageNameLabel.Content = b.Content.ToString();
            MainFrame.Navigate(addEdit);

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            MainFrame.Navigate(searchPage);
        }

        private void LoadJson()
        {
            JArray array = JArray.Parse(File.ReadAllText("schedule.json"));
            foreach (var obj in array.Children())
            {
                ActualTrack at = new ActualTrack();
                var itemProperties = obj.Children<JProperty>();
                at.StartBusStop = Lists.GetBusStop((int)itemProperties.First(x => x.Name == "startBusStop").Value);
                at.Driver = Lists.GetDriver((int)itemProperties.First(x=> x.Name == "driver").Value);
                at.EndBusStop = Lists.GetBusStop((int)itemProperties.First(x => x.Name == "endBusStop").Value);
                var date = (string)itemProperties.First(x => x.Name == "startHour").Value;
                at.StartHour = DateTime.ParseExact(date, "g",null);
                var enddate = (string) itemProperties.First(x => x.Name == "endHour").Value;
                at.EndHour = DateTime.ParseExact(enddate, "g", null);
                at.Line = Lists.GetLine((int) itemProperties.First(x => x.Name == "line").Value);
                actualTracks.Add(at);

            }
        }

        private void CheckSmallBus()
        {
            foreach (var tracks in actualTracks)
            {
                //pobrac z bazy danych czy dla takiej daty i takiej linii jest duzy czy maly
                // zmienic smallbus na true lub false
            }
        }
    }
}
