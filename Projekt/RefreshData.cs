using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Projekt
{
    static class RefreshData
    {
        private static DbConnect _db = new DbConnect();

        public static void Execute()
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Tick += new EventHandler(Refresh);
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Start();
        }

        static void Refresh(object sender, EventArgs e)
        {
            RefreshList();
        }

        static void RefreshList()
        {
            int count = Lists.ActualTracks.Count;
            for(int i =count-1;i>=0;i--)
            {
                var tracks = Lists.ActualTracks[i];
                if (tracks.EndHour < DateTime.Now)
                {
                    if (tracks.Driver!=null)
                    {
                        tracks.Driver.Actualbus = null;
                    }
                    Lists.ActualTracks.Remove(tracks);
                }
                if (tracks.StartHour < DateTime.Now && tracks.EndHour > DateTime.Now)
                {
                    if (tracks.Driver.Actualbus == null)
                    {
                        if (tracks.Smallbus)
                        {
                            tracks.Driver.Actualbus =
                                Lists.Buses.First(
                                    x => x.Actualdriver.Id < 1 && x.Actualline.Number < 1 && x.Type == "small");
                        }
                        else
                        {
                            tracks.Driver.Actualbus =
                                Lists.Buses.First(x => x.Actualdriver == null && x.Actualline == null && x.Type == "big");
                        }
                        tracks.Driver.Actualbus.Actualline = tracks.Line;
                    }
                }
            }
        }
    }
}
