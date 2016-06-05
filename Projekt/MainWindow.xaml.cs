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
        private DbConnect dbConnect;
        public MainWindow()
        {
            dbConnect = new DbConnect();
            InitializeComponent();
            Commands.BindCommandsToWindow(this);
            LoadButtonFunctions();
            LoadDataFromDataBase();
            LoadJson();
            CheckSmallBus();
            RefreshData.Execute();
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

        private void LoadButtonFunctions()
        {
            Commands.List = new Dictionary<object, Func<int>>();
            Commands.List [DriversButton] = Commands.DriverFunction;
            Commands.List [BusStopsButton] = Commands.BusStopFunction;
            Commands.List [BussesButton] = Commands.BusFunction;
            Commands.List [LinesButton] = Commands.LineFunction;
            Commands.List [ActualTrackButton] = Commands.ActualTrackFunction;
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
                at.StartHour = DateTime.Parse(date);
                var enddate = (string) itemProperties.First(x => x.Name == "endHour").Value;
                at.EndHour = DateTime.Parse(enddate);
                at.Line = Lists.GetLine((int) itemProperties.First(x => x.Name == "line").Value);
                Lists.ActualTracks.Add(at);

            }
        }

        private void CheckSmallBus()
        {
            foreach (var tracks in Lists.ActualTracks)
            {
                string day = tracks.StartHour.DayOfWeek.ToString();
                switch (day)
                {
                    case "sunday":
                        day = "niedziela";
                        break;
                    case "saturday":
                        day = "sobota";
                        break;
                    default:
                        day = "roboczy";
                        break;
                }
                string date = tracks.StartHour.TimeOfDay.ToString().Substring(0,5);
                DataTable dt = dbConnect.SelectQuery("Select small from track_bus where startdate = '"+date+"' and day = '"+day+"' and lineid='"+tracks.Line.Number+"'");
                if (dt.Rows.Count!=0)
                {
                    string issmall = dt.Rows[0]["small"].ToString();
                    if (issmall == "0")
                    {
                        tracks.Smallbus = true;
                    }
                    else
                    {
                        tracks.Smallbus = false;
                    }
                }
            }
        }

        private void LoadDataFromDataBase()
        {
            LoadDriver();
            LoadBusStop();
            LoadLine();
            LoadBus();
        }

        private void LoadBus()
        {
            DataTable dt = dbConnect.SelectQuery("Select * from Bus");
            int dtcount = dt.Rows.Count;
            for (int i = 0; i < dtcount; i++)
            {
                try
                {
                    Bus bus = new Bus();
                    bus.Busid = Int32.Parse(dt.Rows[i]["idbus"].ToString());
                    bus.Actualdriver = Lists.GetDriver(Int32.Parse(dt.Rows[i]["actualdriver"].ToString()));
                    bus.Actualline = Lists.GetLine(Int32.Parse(dt.Rows[i]["actualline"].ToString()));
                    bus.Busbrand = dt.Rows[i]["busbrand"].ToString();
                    bus.Mileage = Double.Parse(dt.Rows[i]["mileage"].ToString());
                    bus.Techcondition = dt.Rows[i]["techcondition"].ToString();
                    bus.Type = dt.Rows[i]["type"].ToString();
                    Lists.Buses.Add(bus);
                }
                catch (Exception)
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBox.Show("Błąd bazy danych przy wczytywaniu autobusów", "Błąd", mbb);
                }
            }
        }

        private void LoadLine()
        {
            DataTable dt = dbConnect.SelectQuery("Select * from Line");
            int dtcount = dt.Rows.Count;
            for (int i = 0; i < dtcount; i++)
            {
                try
                {
                    Line line = new Line();
                    line.Number = Int32.Parse(dt.Rows [i] ["idline"].ToString());
                    line.Length = Double.Parse(dt.Rows [i] ["lenght"].ToString()); //tu
                    line.Firststop = Lists.GetBusStop(Int32.Parse(dt.Rows [i] ["firststop"].ToString()));
                    line.Laststop = Lists.GetBusStop(Int32.Parse(dt.Rows [i] ["laststop"].ToString()));
                    Lists.Lines.Add(line);
                }
                catch (Exception)
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBox.Show("Błąd bazy danych przy wczytywaniu linii", "Błąd", mbb);
                }
            }
        }

        private void LoadBusStop()
        {
            DataTable dt = dbConnect.SelectQuery("Select * from BusStop");
            int dtcount = dt.Rows.Count;
            for (int i = 0; i < dtcount; i++)
            {
                BusStop bs = new BusStop();
                bs.Id = Int32.Parse(dt.Rows[i]["idBusStop"].ToString());
                bs.Name = dt.Rows[i]["busstopname"].ToString();
                //bs.Area = Int32.Parse(dt.Rows[i]["area"].ToString());
                Lists.BusStops.Add(bs);
            }
        }

        private void LoadDriver()
        {
            DataTable dt = dbConnect.SelectQuery("Select * from Driver");
            int dtcount = dt.Rows.Count;
            for (int i = 0; i < dtcount; i++)
            {
                try
                {
                    Driver driver = new Driver();
                    driver.Id = Int32.Parse(dt.Rows [i] ["iddriver"].ToString());
                    driver.Name = dt.Rows [i] ["name"].ToString();
                    driver.Secondname = dt.Rows [i] ["secondname"].ToString();
                    driver.Status = dt.Rows [i] ["status"].ToString();
                    driver.Driverlicenseid = Int32.Parse(dt.Rows [i] ["driverlicenceid"].ToString());
                    driver.City = dt.Rows [i] ["city"].ToString();
                    driver.Zipcode = Int32.Parse(dt.Rows [i] ["zipcode"].ToString());
                    driver.Address = dt.Rows [i] ["address"].ToString();
                    driver.Actualbus = Lists.GetBus(Int32.Parse(dt.Rows [i] ["actualbus"].ToString()));
                    driver.Salary = Double.Parse(dt.Rows [i] ["salary"].ToString());
                    driver.Hoursworked = Double.Parse(dt.Rows [i] ["hoursworked"].ToString());
                    driver.Photopath = dt.Rows [i] ["photopath"].ToString();
                    Lists.Drivers.Add(driver);
                }
                catch (Exception)
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBox.Show("Błąd bazy danych przy wczytywaniu kierowcow", "Błąd", mbb);
                }
                
            }
        }
    }
}
